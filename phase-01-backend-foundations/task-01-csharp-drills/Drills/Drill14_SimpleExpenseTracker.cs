namespace task_01_csharp_drills.Drills
{
    public class Drill14_SimpleExpenseTracker
    {
        public static void Track()
        {
            List<Expense> expenses = new List<Expense>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter expense name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter expense amount:");
                decimal amount;
                while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 0)
                {
                    Console.WriteLine("Invalid amount. Please enter a positive number:");
                }
                expenses.Add(new Expense(name, amount));
                Console.WriteLine("Do you want to add another expense? (y/n)");
                string response = Console.ReadLine().ToLower();
                flag = response == "y";
            }

            decimal total = expenses.Sum(e => e.Amount);
            decimal avg = expenses.Average(e => e.Amount);
            var max = expenses.Max(e => e.Amount);
            var highest = expenses.Where(expenses => expenses.Amount == max).Select(e => e.Name).ToList();

            Console.WriteLine($"Total {total}, Average {avg}, Highest {string.Join(", ", highest)}");
        }
    }

    public class Expense
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Expense(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
