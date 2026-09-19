using task_03_products_categories_api.DTOs;
using task_03_products_categories_api.Models;

namespace task_03_products_categories_api.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();

        ServiceResponse<Category> Create(CreateCategoryRequest request);
            
    }
}
