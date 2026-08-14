namespace task_01_csharp_drills.Drills
{
    public class Drill06_WordCounter
    {
        public static void Count()
        {
            Console.WriteLine("Enter a sentence:");
            string input = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Please enter a valid sentence.");
                return;
            }    

            var words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"Words Count: {words.Length}");

        }
    }
}
