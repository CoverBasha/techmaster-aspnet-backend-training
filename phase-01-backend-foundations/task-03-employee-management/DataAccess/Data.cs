using Task_03_Employee_Management_Console_App.Models;

namespace Task_03_Employee_Management_Console_App.DataAccess
{
    public class Data
    {
        public static Dictionary<int, Employee> Employees { get; set; } = [];

        public static void LoadCSV()
        {
            var data = File.ReadLines("../../../DataAccess/employees_seed_data.csv").Skip(1);

            foreach (var line in data)
            {
                var parts = line.Split(',');
                var id = int.Parse(parts[0][4..]);

                Employees.Add(id, new Employee(id, parts[1], parts[2], parts[3], parts[4], decimal.Parse(parts[5]), DateTime.Parse(parts[6]), bool.Parse(parts[7])));
            }
        }
    }
}
