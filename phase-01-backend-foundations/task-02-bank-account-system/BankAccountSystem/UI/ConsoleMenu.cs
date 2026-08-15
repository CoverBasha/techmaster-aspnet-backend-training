namespace task_02_bank_account_system.BankAccountSystem.UI
{
    public class ConsoleMenu
    {
        virtual public void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Bank Account System");
            Console.WriteLine("1. Create a new bank account");
            Console.WriteLine("2. View account details");
            Console.WriteLine("3. Deposit funds");
            Console.WriteLine("4. Withdraw funds");
            Console.WriteLine("5. Exit");
        }

        virtual public void HandleUserInput()
        {
            Console.Write("Please select an option: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    // Handle account creation
                    break;
                case "2":
                    // Handle viewing account details
                    break;
                case "3":
                    // Handle depositing funds
                    break;
                case "4":
                    // Handle withdrawing funds
                    break;
                case "5":
                    Console.WriteLine("Exiting the application.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }


    }
}
