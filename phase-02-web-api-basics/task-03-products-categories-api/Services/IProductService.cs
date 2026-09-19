using task_03_products_categories_api.DTOs;

namespace task_03_products_categories_api.Services;

public interface IProductService
{
    ServiceResponse<IEnumerable<ProductResponse>> GetAll(
        string? search,
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        bool? isAvailable,
        bool? lowStock);

    ServiceResponse<ProductResponse> GetById(int id);
    ServiceResponse<ProductResponse> Create(CreateProductRequest request);
    ServiceResponse<ProductResponse> Update(int id,UpdateProductRequest request);
    ServiceResponse<ProductResponse> UpdateStock(int id,int stockQuantity);
    ServiceResponse<ProductResponse> Delete(int id);
    IEnumerable<ProductResponse> GetLowStock();
    object GetStockValueReport();
}