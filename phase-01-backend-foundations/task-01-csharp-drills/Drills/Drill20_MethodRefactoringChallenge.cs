namespace task_01_csharp_drills.Drills
{
    public class Drill20_MethodRefactoringChallenge
    {
        public static List<int> ParseListInput()
        {
            // This refactor takes an input as numbers separated by commas and returns a list of those numbers
            // The logic here is repeated across multiple drills

            Console.WriteLine("Enter a list of numbers separated by commas:");
            string input = Console.ReadLine();
            string[] numberStrings = input.Split(',');
            List<int> numbers = new List<int>();
            foreach (string numberString in numberStrings)
            {
                if (int.TryParse(numberString.Trim(), out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"'{numberString}' is not a valid number.");
                    return null;
                }
            }
            return numbers;
        }

        public static void ShowATMMenu()
        {
            //This refactor shows the ATM menu in Drill 10

            Console.WriteLine("ATM Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
        }

        public static void DepositMoney(ref decimal balance)
        {
            //This refactor provides the option to deposit money in Drill 10
            //It does so by taking the balance as a reference parameter and adds the new amount to it

            Console.Write("Enter amount to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal deposit) && deposit > 0)
            {
                balance += deposit;
                Console.WriteLine($"Deposited: {deposit}. New balance: {balance}");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        public static void WithdrawMoney(ref decimal balance)
        {
            //This refactor provides the option to withdraw money in Drill 10
            //It does so by taking the balance as a reference parameter and subtracts the new amount from it

            Console.Write("Enter amount to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal withdraw) && withdraw > 0)
            {
                if (withdraw <= balance)
                {
                    balance -= withdraw;
                    Console.WriteLine($"Withdrew: {withdraw}. New balance: {balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }



        public static bool IsValidGrade(decimal grade)
        {
            //This refactor is validates the boundaries of the grade in Drill 02

            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("Grade must be between 0 and 100.");
                Console.WriteLine();
                return false;
            }

            return true;
        }

        public static string CalculateGrade(decimal grade)
        {
            //This refactor calculates the grade letter in Drill 02

            switch (grade)
            {
                case > 89:
                    return "Grade: A";
                case > 79:
                    return "Grade: B";
                case > 69:
                    return "Grade: C";
                case > 59:
                    return "Grade D";
                default: return "Grade: F";
            }
        }
    }
}
