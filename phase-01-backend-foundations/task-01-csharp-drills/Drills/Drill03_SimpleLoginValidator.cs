namespace task_01_csharp_drills.Drills
{
    public class Drill03_SimpleLoginValidator
    {
        public static void Login()
        {
            int attempt = 1;
            const string CORRECT_USERNAME = "admin";
            const string CORRECT_PASSWORD = "123";

            while (attempt <= 3)
            {
                Console.WriteLine($"Attempt #{attempt}");
                Console.Write("Enter your username: ");
                var username = Console.ReadLine();

                Console.Write("Enter your password: ");
                var password = Console.ReadLine();

                if(username.ToLower() == CORRECT_USERNAME && password == CORRECT_PASSWORD) // case insensitive comparison for username
                {
                    Console.WriteLine("Login successful!");
                    return;
                }

                Console.WriteLine("Invalid username or password.");
                Console.WriteLine();
                attempt++;
            }

            Console.WriteLine("Account locked. Too many failed attempts.");
        }
    }
}
