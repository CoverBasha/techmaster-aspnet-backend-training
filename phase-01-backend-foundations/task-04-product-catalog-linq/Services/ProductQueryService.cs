using task_04_product_catalog_linq.Models;
using task_04_product_catalog_linq.Models.DTOs;

namespace task_04_product_catalog_linq.Services
{
    public static class ProductQueryService
    {
        private static readonly List<Product> _products = [];
        public static void LoadCSV()
        {
            var lines = File.ReadLines("../../../Services/products_seed_data.csv").Skip(1);

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                var product = new Product
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Category = parts[2],
                    Price = decimal.Parse(parts[3]),
                    Stock = int.Parse(parts[4]),
                    CreatedAt = DateTime.Parse(parts[5]),
                    IsAvailable = bool.Parse(parts[6]),
                    Supplier = parts[7]
                };
                _products.Add(product);
            }
        }

        public static List<Product> GetAllAvailableProducts()
        {
            return _products.Where(p => p.IsAvailable && p.Stock != 0).ToList();
        }

        public static List<Product> GetProductsByCategory(string category)
        {
            return _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        }

        public static List<Product> SearchbyProductName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be null or empty.");

            return _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Product> SortbyPriceAscending()
        {
            return _products.OrderBy(p => p.Price).ToList();
        }

        public static List<Product> SortbyPriceDescending()
        {
            return _products.OrderByDescending(p => p.Price).ToList();
        }

        public static List<IGrouping<string, Product>> GroupbyCategory()
        {
            return _products.GroupBy(p => p.Category).ToList();
        }

        public static List<ProductCountPerCategory> GetProductCountPerCategory()
        {
            return _products.GroupBy(p => p.Category)
                .Select(g => new ProductCountPerCategory { Category = g.Key, Count = g.Count() }).ToList();
        }

        public static decimal TotalStockValue()
        {
            return _products.Sum(p => p.Price * p.Stock);
        }

        public static List<StockValuePerCategory> StockValuePerCategory()
        {
            return _products.GroupBy(p => p.Category)
                .Select(g => new StockValuePerCategory { Category = g.Key, StockValue = g.Sum(p => p.Price * p.Stock) }).ToList();
        }

        public static List<Product> Top5MostExpensiveProducts()
        {
            return _products.OrderByDescending(p => p.Price).Take(5).ToList();
        }

        public static List<Product> LowStockProducts()
        {
            return _products.Where(p => p.Stock <= 5).ToList();
        }

        public static List<Product> OutOfStockProducts()
        {
            return _products.Where(p => p.Stock == 0 || !p.IsAvailable).ToList();
        }

        public static List<ProductSummary> productSummaries()
        {
            return _products.Select(p => new ProductSummary
            {
                Name = p.Name,
                Stock = p.Stock,
                IsAvailable = p.IsAvailable
            }).ToList();
        }

        public static List<SupplierReport> SupplierReport()
        {
            return _products.GroupBy(p => p.Supplier)
                .Select(g => new SupplierReport
                {
                    Supplier = g.Key,
                    Count = g.Count(),
                    StockValue = g.Sum(p => p.Price * p.Stock),
                    AveragePrice = g.Average(p => p.Price)
                }).ToList();
        }

        public static List<Product> GetProductsAddedInLastNDays()
        {
            return _products.Where(p => p.CreatedAt >= DateTime.Now.AddDays(-60)).ToList();
        }

        public static List<CategoryStatistics> CategoryStatistics()
        {
            return _products.GroupBy(p => p.Category)
                .Select(g => new CategoryStatistics
                {
                    Count = g.Count(),
                    average = g.Average(p => p.Price),
                    Max = g.Max(p => p.Price),
                    Min = g.Min(p => p.Price),
                    TotalStockValue = g.Sum(p => p.Price * p.Stock)
                }).ToList();
        }

        public static List<Product> ProductsAboveAveragePrice()
        {
            var averagePrice = _products.Average(p => p.Price);
            return _products.Where(p => p.Price > averagePrice).ToList();
        }

        public static List<Product> Filter(string? category, decimal? minPrice, decimal? maxPrice, bool? isAvailable)
        {
            var query = _products.AsEnumerable();

            if(category != null)
                query = query.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

            if (minPrice != null)
                query = query.Where(p => p.Price >= minPrice);

            if (maxPrice != null)
                query = query.Where(p => p.Price <= maxPrice);

            if (isAvailable != null)
                query = query.Where(p => p.IsAvailable == isAvailable);

            return query.ToList();
        }

        public static List<Product> Paginate(int  page, int pageSize)
        {
            page = page > 0 ? page : 1;

            return _products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
