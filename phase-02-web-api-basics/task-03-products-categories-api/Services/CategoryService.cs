using task_03_products_categories_api.DTOs;
using task_03_products_categories_api.Models;

namespace task_03_products_categories_api.Services
{
    public class CategoryService : ICategoryService
    {
        ServiceResponse<Category> ICategoryService.Create(CreateCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Category> ICategoryService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
