using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_03_products_categories_api.DTOs;
using task_03_products_categories_api.Services;

namespace task_03_products_categories_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();

            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryRequest request)
        {
            var result = _categoryService.Create(request);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    message = result.Message
                });
            }

            return CreatedAtAction(
                nameof(GetAll),
                null,
                result.Data);
        }
    }
}
