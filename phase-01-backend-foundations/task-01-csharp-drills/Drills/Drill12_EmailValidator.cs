namespace task_01_csharp_drills.Drills
{
    public class Drill12_EmailValidator
    {
        public static void Validate()
        {
            Console.WriteLine("Enter an email address:");
            string email = Console.ReadLine();

            email = email.Trim();

            if (string.IsNullOrWhiteSpace(email) ||
                !email.Contains('@') ||
                !email.Contains('.') ||
                email.Contains(' ') ||
                email.StartsWith('@') ||
                email.EndsWith('@') ||
                !email.EndsWith(".com") ||
                email.Count(c => c == '@') > 1)
            {
                Console.WriteLine("Invalid");
                return;
            }

            Console.WriteLine("Valid");
        }
    }
}
