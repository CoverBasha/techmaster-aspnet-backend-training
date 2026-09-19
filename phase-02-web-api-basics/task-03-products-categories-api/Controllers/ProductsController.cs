using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_03_products_categories_api.DTOs;

namespace task_03_products_categories_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET /api/products
        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] string? search,
            [FromQuery] int? categoryId,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] bool? isAvailable,
            [FromQuery] bool? lowStock)
        {
            var products = _productService.GetAll(
                search,
                categoryId,
                minPrice,
                maxPrice,
                isAvailable,
                lowStock);

            return Ok(products);
        }

        // GET /api/products/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);

            if (!product.Success)
            {
                return NotFound(new
                {
                    message = product.Message
                });
            }

            return Ok(product.Data);
        }

        // POST /api/products
        [HttpPost]
        public IActionResult Create(CreateProductRequest request)
        {
            var result = _productService.Create(request);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    message = result.Message
                });
            }

            return StatusCode(
                StatusCodes.Status201Created,
                result.Data);
        }

        // PUT /api/products/{id}
        [HttpPut("{id:int}")]
        public IActionResult Update(
            int id,
            UpdateProductRequest request)
        {
            var result = _productService.Update(id, request);

            if (!result.Success)
            {
                if (result.NotFound)
                {
                    return NotFound(new
                    {
                        message = result.Message
                    });
                }

                return BadRequest(new
                {
                    message = result.Message
                });
            }

            return Ok(result.Data);
        }

        // PATCH /api/products/{id}/stock
        [HttpPatch("{id:int}/stock")]
        public IActionResult UpdateStock(
            int id,
            [FromQuery] int stockQuantity)
        {
            var result = _productService.UpdateStock(
                id,
                stockQuantity);

            if (!result.Success)
            {
                if (result.NotFound)
                {
                    return NotFound(new
                    {
                        message = result.Message
                    });
                }

                return BadRequest(new
                {
                    message = result.Message
                });
            }

            return Ok(result.Data);
        }

        // DELETE /api/products/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);

            if (!result.Success)
            {
                return NotFound(new
                {
                    message = result.Message
                });
            }

            return Ok(result.Data);
        }

        // GET /api/products/low-stock
        [HttpGet("low-stock")]
        public IActionResult GetLowStock()
        {
            var products = _productService.GetLowStock();

            return Ok(products);
        }

        // GET /api/products/reports/stock-value
        [HttpGet("reports/stock-value")]
        public IActionResult GetStockValueReport()
        {
            var report = _productService.GetStockValueReport();

            return Ok(report);
        }
    }
}
