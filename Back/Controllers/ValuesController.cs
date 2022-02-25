using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet, Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            var json = await GetStarWars();
            List<Starwar> Starwars = JsonConvert.DeserializeObject<List<Starwar>>(json);
            return Ok( Starwars);
        }
        public async Task<string> GetStarWars()
        {
            var assembly = Assembly.GetEntryAssembly();
            var resourceStream = assembly.GetManifestResourceStream("Back.Data.starwars.json");
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
