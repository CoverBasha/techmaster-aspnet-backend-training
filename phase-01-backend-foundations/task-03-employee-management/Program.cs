using Task_03_Employee_Management_Console_App.DataAccess;
using Task_03_Employee_Management_Console_App.UI;

public class MainClass
{
    static void Main(string[] args)
    {
        Data.LoadCSV();

        try
        {
            ConsoleMenu.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

