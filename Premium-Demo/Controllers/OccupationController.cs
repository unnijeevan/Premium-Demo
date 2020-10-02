using Microsoft.AspNetCore.Mvc;
using Premium_Demo.Models;
using Premium_Demo.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Premium_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationService _occupationService;

        public OccupationController(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var occupations = await _occupationService.GetOccupationsAsync();

            return Ok(occupations.Select(o => new Occupation { Id = o.Id, Name = o.Name }));
        }
    }
}
