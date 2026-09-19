namespace task_03_products_categories_api.DTOs
{
    public class UpdateProductRequest
    {
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string SupplierName { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }
    }
}
