namespace task_04_product_catalog_linq.Models.DTOs
{
    public class CategoryStatistics
    {
        public int Count { get; set; }
        public decimal average { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public decimal TotalStockValue { get; set; }
    }
}
