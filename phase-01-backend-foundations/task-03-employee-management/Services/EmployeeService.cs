using Task_03_Employee_Management_Console_App.DataAccess;
using Task_03_Employee_Management_Console_App.Models;

namespace Task_03_Employee_Management_Console_App.Services
{
    public static class EmployeeService
    {
        public static Employee GetEmployee(int id)
        {
            if (!Data.Employees.ContainsKey(id))
                throw new KeyNotFoundException($"No employee with ID: {id}");
            return Data.Employees[id];
        }

        public static void AddEmployee(string fullName, string email, string department, string position, decimal salary, DateTime hireDate)
        {
            if (hireDate > DateTime.Now)
                throw new Exception("Hire date can't be in the future");

            int id = Data.Employees.Last().Key + 1;
            while (Data.Employees.ContainsKey(id))
                id++;

            Employee employee = new Employee(id, fullName, email, department, position, salary, hireDate);

            Data.Employees.Add(employee.EmployeeId, employee);
        }

        public static void UpdateEmployee(int id, string email, string department, string position, decimal salary)
        {
            var employee = GetEmployee(id);
            employee.Email = email;
            employee.Department = department;
            employee.Position = position;
            employee.Salary = salary;
        }

        public static void DeactivateEmployee(int id)
        {
            var employee = GetEmployee(id);

            if (!employee.IsActive)
                throw new Exception("Employee already deactived");

            employee.IsActive = false;
        }
    }
}
