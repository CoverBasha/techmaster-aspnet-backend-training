using task_02_bank_account_system.BankAccountSystem.UI;
using task_02_bank_account_system.BankAccountSystem.Services;

public class MainClass
{
    public static void Main(string[] args)
    {
        ConsoleMenu menu = new ConsoleMenu(new BankService());

        menu.run();
    }
}
