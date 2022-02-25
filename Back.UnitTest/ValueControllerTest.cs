using Back.Controllers;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Back.UnitTest
{
    public class ValueControllerTest
    {
        private readonly ValuesController _controller;

        public ValueControllerTest()
        {
            _controller = new ValuesController();
        }

        [Fact]
        public async Task Get_AppelerLaMethode_ReturneOkResult()
        {
            _controller.GetStarWars().ReturnsAsync(Task.FromResult("Result string"));
            // Act
            var okResult = await _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async Task Get_AppelerLaMethode_ReturneToutLesEntites()
        {
            // Act
            var okResult = await _controller.Get() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Starwar>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
