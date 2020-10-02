using Microsoft.AspNetCore.Mvc;
using Premium_Demo.Dto;
using Premium_Demo.Models;
using Premium_Demo.Services;
using System.Threading.Tasks;

namespace Premium_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricingController : ControllerBase
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculatePrice(PricingRequest pricingRequest)
        {
            var price = await _pricingService.CalculateMonthlyPremiumAsync(
                new PricingDto
                {
                    Age = pricingRequest.Age,
                    CoverAmount = pricingRequest.CoverAmount,
                    OccupationId = pricingRequest.OccupationId
                });
            return Ok(price);
        }
    }
}
