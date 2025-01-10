using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Product;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Lists all products
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaddleResponse<Product[]>>> ListProducts()
        {
            return await _productService.ListProductsAsync();
        }

        /// <summary>
        /// Gets a specific product by ID
        /// </summary>
        [HttpGet("{productId}")]
        public async Task<ActionResult<PaddleResponse<Product>>> GetProduct(int productId)
        {
            return await _productService.GetProductAsync(productId);
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PaddleResponse<Product>>> CreateProduct([FromBody] Product product)
        {
            return await _productService.CreateProductAsync(product);
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        [HttpPatch("{productId}")]
        public async Task<ActionResult<PaddleResponse<Product>>> UpdateProduct(int productId, [FromBody] Product product)
        {
            return await _productService.UpdateProductAsync(productId, product);
        }
    }
}