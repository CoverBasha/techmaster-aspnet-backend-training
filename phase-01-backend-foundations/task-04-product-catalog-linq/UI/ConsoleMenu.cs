using task_04_product_catalog_linq.Models;
using task_04_product_catalog_linq.Services;

namespace task_04_product_catalog_linq.UI
{
    public class ConsoleMenu
    {
        public static void Run()
        {
            ProductQueryService.LoadCSV();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("====== Product Catalog LINQ System ======");
                Console.WriteLine("1. View Available Products");
                Console.WriteLine("2. Filter by Category");
                Console.WriteLine("3. Filter by Price Range");
                Console.WriteLine("4. Search by Name");
                Console.WriteLine("5. Sort by Price");
                Console.WriteLine("6. Group by Category");
                Console.WriteLine("7. Stock Value Reports");
                Console.WriteLine("8. Low Stock Products");
                Console.WriteLine("9. Supplier Report");
                Console.WriteLine("10. Pagination Demo");
                Console.WriteLine("11. Exit");
                Console.Write("Choose an option: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAvailableProducts();
                        break;

                    case "2":
                        FilterByCategory();
                        break;

                    case "3":
                        FilterByPriceRange();
                        break;

                    case "4":
                        SearchByName();
                        break;

                    case "5":
                        SortByPrice();
                        break;

                    case "6":
                        GroupByCategory();
                        break;

                    case "7":
                        StockValueReports();
                        break;

                    case "8":
                        PrintProducts(ProductQueryService.LowStockProducts());
                        break;

                    case "9":
                        SupplierReport();
                        break;

                    case "10":
                        PaginationDemo();
                        break;

                    case "11":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }


            // -------------------------
            // Menu Handlers
            // -------------------------

            static void ViewAvailableProducts()
            {
                var products = ProductQueryService.GetAllAvailableProducts();

                PrintProducts(products);
            }


            static void FilterByCategory()
            {
                Console.Write("Enter category: ");
                string? category = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(category))
                {
                    Console.WriteLine("Category cannot be empty.");
                    return;
                }

                var products = ProductQueryService.GetProductsByCategory(category);

                PrintProducts(products);
            }


            static void FilterByPriceRange()
            {
                Console.Write("Enter minimum price: ");

                if (!decimal.TryParse(Console.ReadLine(), out decimal minPrice))
                {
                    Console.WriteLine("Invalid minimum price.");
                    return;
                }

                Console.Write("Enter maximum price: ");

                if (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
                {
                    Console.WriteLine("Invalid maximum price.");
                    return;
                }

                if (minPrice < 0 || maxPrice < 0)
                {
                    Console.WriteLine("Prices cannot be negative.");
                    return;
                }

                if (minPrice > maxPrice)
                {
                    Console.WriteLine("Minimum price cannot be greater than maximum price.");
                    return;
                }

                var products =
                    ProductQueryService.GetProductsByPriceRange(minPrice, maxPrice);

                PrintProducts(products);
            }


            static void SearchByName()
            {
                Console.Write("Enter product name: ");
                string? name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Product name cannot be empty.");
                    return;
                }

                var products = ProductQueryService.SearchbyProductName(name);

                PrintProducts(products);
            }


            static void SortByPrice()
            {
                Console.WriteLine("1. Ascending");
                Console.WriteLine("2. Descending");
                Console.Write("Choose sorting order: ");

                string? choice = Console.ReadLine();

                List<Product> products;

                switch (choice)
                {
                    case "1":
                        products = ProductQueryService.SortbyPriceAscending();
                        break;

                    case "2":
                        products = ProductQueryService.SortbyPriceDescending();
                        break;

                    default:
                        Console.WriteLine("Invalid sorting option.");
                        return;
                }

                PrintProducts(products);
            }


            static void GroupByCategory()
            {
                var groups = ProductQueryService.GroupbyCategory();

                foreach (var group in groups)
                {
                    Console.WriteLine($"\n=== {group.Key} ===");

                    foreach (var product in group)
                    {
                        Console.WriteLine(
                            $"{product.Id,-4} {product.Name,-30} {product.Price,10:C}");
                    }
                }
            }


            static void StockValueReports()
            {
                Console.WriteLine("=== Total Stock Value ===");

                decimal totalValue = ProductQueryService.TotalStockValue();

                Console.WriteLine($"Total stock value: {totalValue:C}");

                Console.WriteLine("\n=== Stock Value Per Category ===");

                var reports = ProductQueryService.StockValuePerCategory();

                foreach (var report in reports)
                {
                    Console.WriteLine(
                        $"{report.Category,-20} {report.StockValue,12:C}");
                }
            }


            static void SupplierReport()
            {
                var reports = ProductQueryService.SupplierReport();

                Console.WriteLine(
                    $"{"Supplier",-20} {"Products",-10} {"Stock Value",-15} {"Avg Price",-15}");

                Console.WriteLine(new string('-', 65));

                foreach (var report in reports)
                {
                    Console.WriteLine(
                        $"{report.Supplier,-20} " +
                        $"{report.Count,-10} " +
                        $"{report.StockValue,15:C} " +
                        $"{report.AveragePrice,15:C}");
                }
            }


            static void PaginationDemo()
            {
                Console.Write("Enter page number: ");

                if (!int.TryParse(Console.ReadLine(), out int page))
                {
                    Console.WriteLine("Invalid page number.");
                    return;
                }

                Console.Write("Enter page size: ");

                if (!int.TryParse(Console.ReadLine(), out int pageSize))
                {
                    Console.WriteLine("Invalid page size.");
                    return;
                }

                if (pageSize <= 0)
                {
                    Console.WriteLine("Page size must be greater than zero.");
                    return;
                }

                var products = ProductQueryService.Paginate(page, pageSize);

                PrintProducts(products);
            }


            // -------------------------
            // Output Helper
            // -------------------------

            static void PrintProducts(List<Product> products)
            {
                if (products.Count == 0)
                {
                    Console.WriteLine("No products found.");
                    return;
                }

                Console.WriteLine(
                    $"{"ID",-5}" +
                    $"{"Name",-30}" +
                    $"{"Category",-15}" +
                    $"{"Price",-12}" +
                    $"{"Stock",-8}" +
                    $"{"Available",-12}");

                Console.WriteLine(new string('-', 82));

                foreach (var product in products)
                {
                    Console.WriteLine(
                        $"{product.Id,-5}" +
                        $"{product.Name,-30}" +
                        $"{product.Category,-15}" +
                        $"{product.Price,-12:C}" +
                        $"{product.Stock,-8}" +
                        $"{product.IsAvailable,-12}");
                }
            }
        }
    }
}
