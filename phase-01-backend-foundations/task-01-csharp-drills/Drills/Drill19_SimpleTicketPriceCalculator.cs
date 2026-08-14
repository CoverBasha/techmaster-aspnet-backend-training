namespace task_01_csharp_drills.Drills
{
    public class Drill19_SimpleTicketPriceCalculator
    {
        public static void Calculate()
        {
            Console.Write("Enter Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid input. Please enter a valid age.");
                return;
            }
            decimal ticketPrice = 100m;
            decimal discount = 0;
            if (age < 12)
            {
                discount = 0.5m;
            }
            else if (age > 60)
            {
                discount = 0.3m;
            }
            else
            {
                Console.Write("Are you a student? y/n: ");
                var isStudent = Console.ReadLine()?.Trim().ToLower() == "y";
                if (isStudent)
                {
                    discount = 0.2m;
                }
            }

            Console.WriteLine($"Ticket Price: ${ticketPrice * (1 - discount)}");
        }
    }
}
