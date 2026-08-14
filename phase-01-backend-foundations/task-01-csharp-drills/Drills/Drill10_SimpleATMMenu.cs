namespace task_01_csharp_drills.Drills
{
    public class Drill10_SimpleATMMenu
    {
        public static void Start()
        {
            decimal balance = 0;
            while (true)
            {
                Drill20_MethodRefactoringChallenge.ShowATMMenu();

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Your balance is: {balance}"); // printing doesn't need a refactor
                        break;
                    case "2":
                        Drill20_MethodRefactoringChallenge.DepositMoney(ref balance);
                        break;
                    case "3":
                        Drill20_MethodRefactoringChallenge.WithdrawMoney(ref balance);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
