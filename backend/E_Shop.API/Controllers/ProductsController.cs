using E_Shop.API.Contracts.Products;
using E_Shop.Core.Interfaces;
using E_Shop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductsService productsService, ILogger<ProductsController> logger)
        {
            _productsService = productsService;
            _logger = logger;

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ProductResponse>>> GetAll()
        {
            var products = await _productsService.GetAllProducts();

            var response = products
                .Select(p => new ProductResponse(
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Price,
                    p.CategoryId,
                    p.Image,
                    p.IsAvailable));

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] ProductRequest request)
        {
            var product = Product.Create(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.Price,
                request.CategoryId,
                request.Image,
                request.IsAvailable);

            if (product.IsFailure)
            {
                _logger.LogError(product.Error);
                return BadRequest(product.Error);
            }
            var productId = await _productsService.CreateProduct(product.Value);

            if (productId.IsFailure)
            {
                _logger.LogError(productId.Error);
                return BadRequest(productId.Error);
            }

            return Ok(productId.Value);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Guid>> UpdateInfo(Guid id, [FromBody] UpdateProductRequest request)
        {
            var productId = await _productsService.UpdateInfo(
                id,
                request.Name,
                request.Description,
                request.Price,
                request.CategoryId,
                request.Image,
                request.IsAvailable);

            if (productId.IsFailure)
            {
                _logger.LogError(productId.Error);
                return BadRequest(productId.Error);
            }

            return Ok(productId.Value);       
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Guid>> DeleteProduct(Guid productId)
        {
            var result = await _productsService.DeleteProduct(productId);

            if (result.IsFailure)
            {
                _logger.LogError(result.Error);
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}
