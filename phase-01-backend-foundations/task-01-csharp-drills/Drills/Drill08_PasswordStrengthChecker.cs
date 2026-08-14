namespace task_01_csharp_drills.Drills
{
    public class Drill08_PasswordStrengthChecker
    {
        public static void Check()
        {
            while (true)
            {
                Console.Write("Enter a password to check its strength: ");
                string password = Console.ReadLine();

                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Password cannot be empty.");
                    return;
                }

                var list = new List<string>();
                bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

                // checking for every weakness
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpper = true;
                    else if (char.IsLower(c)) hasLower = true;
                    else if (char.IsDigit(c)) hasDigit = true;
                    else hasSpecial = true;
                }

                if (hasUpper && hasLower && hasDigit && hasSpecial)
                {
                    Console.WriteLine("Strong");
                    Console.WriteLine();
                    return;
                }

                // adding every weakness to the list

                if (!hasUpper)
                    list.Add("no uppercase letter");
                if (!hasLower)
                    list.Add("no lowercase letter");
                if (!hasDigit)
                    list.Add("no digits");
                if (!hasSpecial)
                    list.Add("no special characters");

                Console.WriteLine($"Weak: {string.Join(", ", list)}"); // printing list of weaknesses
                Console.WriteLine();
            }
        }
    }
}
