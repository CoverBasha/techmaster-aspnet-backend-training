namespace task_01_csharp_drills.Drills
{
    public class Drill16_FrequencyCounter
    {
        public static void Count()
        {
            var numbers = Drill20_MethodRefactoringChallenge.ParseListInput();

            if (numbers == null)
                return;
            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers entered");
                return;
            }

            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach (int number in numbers)
            {
                if (frequency.ContainsKey(number))
                {
                    frequency[number]++;
                }
                else
                {
                    frequency[number] = 1;
                }
            }


            foreach (var kvp in frequency)
            {
                Console.Write($"{kvp.Key}=>{kvp.Value}, ");
            }
        }
    }
}
