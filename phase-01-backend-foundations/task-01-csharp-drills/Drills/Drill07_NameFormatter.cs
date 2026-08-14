namespace task_01_csharp_drills.Drills
{
    public class Drill07_NameFormatter
    {
        public static void Format()
        {
            Console.Write("Enter a name to format: ");
            var input = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                return;
            }

            input = input.Trim();

            input = input.ToLower();

            var words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries); //creates an array of the name's words and removes spaces

            var formattedWords = new List<string>(); // new list for storing formatted names

            //
            foreach (var word in words)
            {
                var firstLetter = char.ToUpper(word[0]); // capitalizing first letter
                var restOfWord = word.Substring(1); // selecting the rest of the word
                formattedWords.Add(firstLetter + restOfWord); // concatinating them and adding them to the new list
            }

            Console.WriteLine(string.Join(" ", formattedWords));
        }
    }
}
