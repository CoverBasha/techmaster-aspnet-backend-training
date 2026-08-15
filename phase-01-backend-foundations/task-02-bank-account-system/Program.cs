using task_02_bank_account_system.BankAccountSystem.UI;

public class MainClass
{
    public static void Main(string[] args)
    {
        ConsoleMenu menu = new ConsoleMenu();

        while (true)
        {
            try
            {
                menu.DisplayMenu();
                menu.HandleUserInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}
