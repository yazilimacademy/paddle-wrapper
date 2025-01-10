using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;
using System.Threading.Tasks;

namespace PaddleDemo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PricesController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrices()
        {
            var result = await _priceService.ListPricesAsync();
            return Ok(result);
        }

        [HttpGet("products/{productId}")]
        public async Task<IActionResult> GetProductPrices(string productId)
        {
            var result = await _priceService.ListProductPricesAsync(productId);
            return Ok(result);
        }
    }
}
