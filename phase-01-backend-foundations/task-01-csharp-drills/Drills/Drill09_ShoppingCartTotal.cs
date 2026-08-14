namespace task_01_csharp_drills.Drills
{
    public class Drill09_ShoppingCartTotal
    {
        public static void Calculate()
        {
            Console.Write("Enter the number of items in the shopping cart: ");
            if(!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return;
            }

            List<Item> items = new List<Item>();

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter the price of item {i + 1}: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                    return;
                }
                Console.Write($"Enter the quantity of item {i + 1}: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    return;
                }
                items.Add(new Item(price, quantity));
            }

            for (int i = 0; i < items.Count; i++)
            {
                decimal subtotal = items[i].Price * items[i].Quantity;
                Console.WriteLine($"Item {i + 1}'s subtotal = {subtotal}");
            }

            var grandtotal = items.Sum(item => item.Price * item.Quantity);

            if(grandtotal > 1000)
            {
                var discount = grandtotal * 0.10m;
                Console.WriteLine($"Discount = {discount}, Final = {grandtotal - discount}");
            }
            else
            {
                Console.WriteLine("No Discount");
            }

        }
    }

    public class Item
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Item(decimal price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }
    }
}
