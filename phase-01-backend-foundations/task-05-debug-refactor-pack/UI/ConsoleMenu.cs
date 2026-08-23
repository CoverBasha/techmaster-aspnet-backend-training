using task_05_debug_refactor_pack.Models;
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
                    Console.Write("Enter customer name: ");
                    string customerName = Console.ReadLine();
                    Console.Write("Enter product name: ");
                    string productName = Console.ReadLine();
                    Console.Write("Enter product price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter customer type: ");
                    Console.WriteLine("1. Regular");
                    Console.WriteLine("2. Silver");
                    Console.WriteLine("3. Gold");
                    Console.WriteLine("4. VIP");
                    int customerType = int.Parse(Console.ReadLine());

                    var order = OrderCalculator.Calculate(customerName, productName, price, quantity, customerType);

                    PrintOutput(order);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void PrintOutput(Order order)
        {
            Console.Write(new string('=', 10) + " Order Reciept " + new string('=', 10) + "\n");
            Console.WriteLine("Customer: " + order.Customer.Name);
            Console.WriteLine("Product: " + order.Customer.ProductName);
            Console.WriteLine("Price: " + order.Customer.Price);
            Console.WriteLine("Quantity: " + order.Customer.Quantity);
            Console.WriteLine();
            Console.WriteLine("Subtotal: " + order.Total);
            Console.WriteLine("Discount: " + order.Discount);
            Console.WriteLine("Tax: " + order.Tax);
            Console.WriteLine("Shipping: " + order.Shipping + "\n");
            Console.WriteLine("Final Total: " + order.FinalPrice);
            Console.Write(new string('=', 36) + "\n \n");

        }
    }
}
