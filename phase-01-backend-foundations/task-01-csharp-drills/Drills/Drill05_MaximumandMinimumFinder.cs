namespace task_01_csharp_drills.Drills
{
    public class Drill05_MaximumandMinimumFinder
    {
        public static void Find()
        {

            var numbers = Drill20_MethodRefactoringChallenge.ParseListInput();

            if (numbers == null)
                return;
            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers entered");
                return;
            }

            //Manual
            int max = int.MinValue;
            int min = int.MaxValue;
            
            foreach (var number in numbers)
            {
                max = number > max ? number : max;
                min = number < min ? number : min;
            }

            Console.WriteLine($"MANUAL:- Maximum: {max} | Minimum: {min}");

            max = numbers.Max();
            min = numbers.Min();

            Console.WriteLine($"LINQ:- Maximum: {max} | Minimum: {min}");
        }
    }
}
