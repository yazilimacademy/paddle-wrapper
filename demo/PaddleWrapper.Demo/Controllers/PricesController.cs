using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Price;
using System.Threading.Tasks;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService _priceService;
        private readonly ILogger<PricesController> _logger;

        public PricesController(IPriceService priceService, ILogger<PricesController> logger)
        {
            _priceService = priceService;
            _logger = logger;
        }

        /// <summary>
        /// Lists all prices
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaddleResponse<Price[]>>> ListPrices()
        {
            return await _priceService.ListPricesAsync();
        }

        /// <summary>
        /// Gets a specific price by ID
        /// </summary>
        [HttpGet("{priceId}")]
        public async Task<ActionResult<PaddleResponse<Price>>> GetPrice(string priceId)
        {
            return await _priceService.GetPriceAsync(priceId);
        }

        /// <summary>
        /// Creates a new price
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PaddleResponse<Price>>> CreatePrice([FromBody] Price price)
        {
            return await _priceService.CreatePriceAsync(price);
        }

        /// <summary>
        /// Updates an existing price
        /// </summary>
        [HttpPatch("{priceId}")]
        public async Task<ActionResult<PaddleResponse<Price>>> UpdatePrice(string priceId, [FromBody] Price price)
        {
            return await _priceService.UpdatePriceAsync(priceId, price);
        }
    }
} 