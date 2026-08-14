namespace task_01_csharp_drills.Drills
{
    public class Drill13_PalindromeChecker
    {
        public static void Check()
        {
            Console.WriteLine("Enter a string to check if it's a palindrome:");
            string input = Console.ReadLine();
            input = input.Replace(" ", "").ToLower();
            string reversed = new string(input.Reverse().ToArray());
            if (input.Equals(reversed))
            {
                Console.WriteLine($"Palindrome.");
            }
            else
            {
                Console.WriteLine($"Not palindrome.");
            }
        }
    }
}
