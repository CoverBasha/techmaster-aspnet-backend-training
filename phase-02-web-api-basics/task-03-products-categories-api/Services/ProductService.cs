using task_03_products_categories_api.DTOs;

namespace task_03_products_categories_api.Services
{
    public class ProductService : IProductService
    {
        ServiceResponse<ProductResponse> IProductService.Create(CreateProductRequest request)
        {
            throw new NotImplementedException();
        }

        ServiceResponse<ProductResponse> IProductService.Delete(int id)
        {
            throw new NotImplementedException();
        }

        ServiceResponse<IEnumerable<ProductResponse>> IProductService.GetAll(string? search, int? categoryId, decimal? minPrice, decimal? maxPrice, bool? isAvailable, bool? lowStock)
        {
            throw new NotImplementedException();
        }

        ServiceResponse<ProductResponse> IProductService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ProductResponse> IProductService.GetLowStock()
        {
            throw new NotImplementedException();
        }

        object IProductService.GetStockValueReport()
        {
            throw new NotImplementedException();
        }

        ServiceResponse<ProductResponse> IProductService.Update(int id, UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }

        ServiceResponse<ProductResponse> IProductService.UpdateStock(int id, int stockQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
