namespace task_01_csharp_drills.Drills
{
    public class Drill11_DuplicateNumberDetector
    {
        public static void Detect()
        {
            var numbers = Drill20_MethodRefactoringChallenge.ParseListInput();

            if (numbers == null)
                return;
            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers entered");
                return;
            }

            HashSet<int> seenNumbers = new HashSet<int>(); // hashset for fast look up on seen numbers
            List<int> duplicates = new List<int>(); // list to store duplicate numbers
            foreach (int number in numbers)
            {
                // if number exists in hashset, number is added to the duplicates list
                if (!seenNumbers.Add(number))
                {
                    duplicates.Add(number);
                }
            }
            if (duplicates.Count > 0)
            {
                Console.WriteLine("Duplicate: " + string.Join(", ", duplicates.Distinct())); // printing every duplicate once
            }
            else
            {
                Console.WriteLine("No duplicate found.");
            }
        }
    }
}
