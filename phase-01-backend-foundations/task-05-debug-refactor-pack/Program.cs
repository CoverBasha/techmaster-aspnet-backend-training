using task_05_debug_refactor_pack.UI;

class Program
{
    static void Main(string[] args)
    {
        ConsoleMenu.Run();

        /*
        Console.WriteLine("Enter customer name:");
        string customerName = Console.ReadLine();
        Console.WriteLine("Enter product name:");
        string productName = Console.ReadLine();
        Console.WriteLine("Enter product price:");
        double price = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter quantity:");
        int quantity = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter customer type Regular/Silver/Gold/VIP:");
        string customerType = Console.ReadLine();


        double total = price * quantity;
        double discount = 0;
        if (customerType == "Regular")
        {
            discount = 0;
        }
        else if (customerType == "Silver")
        {
            discount = total * 0.05;
        }
        else if (customerType == "Gold")
        {
            discount = total * 0.10;
        }
        else if (customerType == "VIP")
        {
            discount = total * 0.15;
        }
        double afterDiscount = total - discount;
        double tax = afterDiscount * 0.14;
        double shipping = 50;

        if (afterDiscount >= 1000)
        {
            shipping = 0;
        }
        double finalTotal = afterDiscount + tax + shipping;
        Console.WriteLine("Customer: " + customerName);
        Console.WriteLine("Product: " + productName);
        Console.WriteLine("Price: " + price);
        Console.WriteLine("Quantity: " + quantity);
        Console.WriteLine("Subtotal: " + total);
        Console.WriteLine("Discount: " + discount);
        Console.WriteLine("Tax: " + tax);
        Console.WriteLine("Shipping: " + shipping);
        Console.WriteLine("Final Total: " + finalTotal);
        */
    }
}