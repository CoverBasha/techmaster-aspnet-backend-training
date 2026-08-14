namespace task_01_csharp_drills.Drills
{
    public class Drill04_EvenOddAnalyzer
    {
        public static void Analyze()
        {
            // Can be refactored using the list parser method in Drill 20, but this drill specifically asks for the count first and to loop after

            Console.WriteLine("Enter Count: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.WriteLine();
                return;
            }
            var evenNumbers = new List<int>();
            var oddNumbers = new List<int>();

            Console.WriteLine($"Enter the {count} numbers: ");
            for (int i = 0; i < count; i++)
            {

                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    i--;
                    continue;
                }

                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
                else
                {
                    oddNumbers.Add(number);
                }
            }

            if (evenNumbers.Count == 0)
            {
                Console.WriteLine("Even list should be empty");
                return;
            }

            if (oddNumbers.Count == 0)
            {
                Console.WriteLine("Odd list should be empty");
                return;
            }

            Console.WriteLine($"Even: {string.Join(", ", evenNumbers)} | Odd: {string.Join(", ", oddNumbers)}");
        }
    }
}
