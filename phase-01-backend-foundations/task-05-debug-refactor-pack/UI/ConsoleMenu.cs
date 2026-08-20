using task_05_debug_refactor_pack.Services;

namespace task_05_debug_refactor_pack.UI
{
    public class ConsoleMenu
    {
        public static void Run()
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter customer name:");
                    string customerName = Console.ReadLine();
                    Console.WriteLine("Enter product name:");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Enter product price:");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter quantity:");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter customer type:");
                    Console.WriteLine("1. Regular");
                    Console.WriteLine("2. Silver");
                    Console.WriteLine("3. Gold");
                    Console.WriteLine("4. VIP");
                    int customerType = int.Parse(Console.ReadLine());

                    var order = OrderCalculator.Calculate(customerName, productName, price, quantity, customerType);

                    Console.WriteLine("Customer: " + customerName);
                    Console.WriteLine("Product: " + productName);
                    Console.WriteLine("Price: " + price);
                    Console.WriteLine("Quantity: " + quantity);
                    Console.WriteLine("Subtotal: " + order.Total);
                    Console.WriteLine("Discount: " + order.Discount);
                    Console.WriteLine("Tax: " + order.Tax);
                    Console.WriteLine("Shipping: " + order.Shipping);
                    Console.WriteLine("Final Total: " + order.FinalPrice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
