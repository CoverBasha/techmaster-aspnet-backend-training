namespace task_01_csharp_drills.Drills
{
    public class Drill18_NumberStatistics
    {
        public static void Show()
        {
            var numbers = Drill20_MethodRefactoringChallenge.ParseListInput();

            if(numbers == null)
                return;
            if(numbers.Count == 0)
            {
                Console.WriteLine("No numbers entered");
                return;
            }

            Console.WriteLine($"Count {numbers.Count} Sum {numbers.Sum()} Average {numbers.Average()} Positives {numbers.Count(n => n > 0)} Negatives {numbers.Count(n => n < 0)}");
        }
    }
}
