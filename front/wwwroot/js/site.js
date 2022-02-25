const uri = 'http://localhost:57212/api/values';

function getStrawars() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _afficherStars(data))
        .catch(error => console.error('Unable to get items.', error));
}

function loadJSON(path, success, error) {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                success(JSON.parse(xhr.responseText));
            }
            else {
                error(xhr);
            }
        }
    };
    xhr.open('GET', path, true);
    xhr.send();
}

function getData() {
    loadJSON(uri, myData, 'jsonp');
}

function myData(Data) {
    console.log(Data[0]);
    console.log("First three posts");
    for (var i = 0; i < 3; i = i + 1) {
        console.log(Data[i]);
    }
    console.log("First five ID");
    for (var i = 0; i < 5; i = i + 1) {
        console.log(Data[i].name);
    }
}

function _afficherStars(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    data.forEach(item => {

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.innerHTML = item.name;

        let td2 = tr.insertCell(1);
        td2.innerHTML = item.height;

        let td3 = tr.insertCell(2);
        td3.innerHTML = item.mass;

        let td4 = tr.insertCell(3);
        td4.innerHTML = item.films.length;
    });

}