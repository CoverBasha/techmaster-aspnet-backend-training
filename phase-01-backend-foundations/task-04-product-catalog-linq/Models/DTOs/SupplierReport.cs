namespace task_04_product_catalog_linq.Models.DTOs
{
    public class SupplierReport
    {
        public string Supplier { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }
        public decimal AveragePrice { get; set; }

    }
}
