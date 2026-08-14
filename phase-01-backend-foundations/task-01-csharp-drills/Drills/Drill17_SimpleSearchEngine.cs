namespace task_01_csharp_drills.Drills
{
    public class Drill17_SimpleSearchEngine
    {
        public static void Search()
        {
            Console.WriteLine("Enter a list of words separated by commas:");
            string input = Console.ReadLine();
            string[] words = input.Split(',');
            Console.WriteLine("Enter a word to search for:");
            string searchWord = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchWord))
            {
                Console.WriteLine("Search word cannot be empty.");
                return;
            }

            var foundWords = words.Where(word => word.Trim().ToLower().Contains(searchWord.Trim().ToLower())).ToList();

            if (foundWords.Count > 0)
            {
                Console.WriteLine($"Found {foundWords.Count} occurrence(s) of '{searchWord}': " + string.Join(", ", foundWords));
            }
            else
            {
                Console.WriteLine($"No occurrences of '{searchWord}' found.");
            }
        }
    }
}
