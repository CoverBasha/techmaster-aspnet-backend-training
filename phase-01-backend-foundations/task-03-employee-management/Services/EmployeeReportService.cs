using Task_03_Employee_Management_Console_App.DataAccess;
using Task_03_Employee_Management_Console_App.Models;

namespace Task_03_Employee_Management_Console_App.Services
{
    public static class EmployeeReportService
    {
        public static IEnumerable<Employee> GetAllEmployees()
        {
            return Data.Employees.Values;
        }

        public static IEnumerable<Employee> GetEmployee(string name)
        {
            name = name.Trim();
            name = name.ToLower();

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Fullname cannot be empty");

            var employees = Data.Employees.Values.Where(e => e.FullName.ToLower().Contains(name.ToLower()));
            if (employees == null)
                throw new KeyNotFoundException($"No employee with name: {name}");

            return employees;
        }

        public static IEnumerable<Employee> GetEmployeesByDepartment(string department, bool? isactive)
        {
            department = department.Trim();
            department = department.ToLower();
            if (string.IsNullOrEmpty(department))
                throw new ArgumentException("Department cannot be empty");

            var employees = Data.Employees.Values.Where(e => e.Department.ToLower().Contains(department));
            if (employees == null)
                throw new KeyNotFoundException($"No employee in department: {department}");
            if (isactive != null)
                employees = employees.Where(e => e.IsActive == isactive);
            return employees;
        }

        public static IEnumerable<Employee> SortEmployees(IEnumerable<Employee> employees, string sortby, bool ascending = true)
        {
            if (employees == null || !employees.Any())
                return employees;

            switch (sortby.ToLower())
            {
                case "name":
                    employees = ascending ? employees.OrderBy(e => e.FullName) : employees.OrderByDescending(e => e.FullName);
                    break;
                case "salary":
                    employees = ascending ? employees.OrderBy(e => e.Salary) : employees.OrderByDescending(e => e.Salary);
                    break;
                case "hiredate":
                    employees = ascending ? employees.OrderBy(e => e.HireDate) : employees.OrderByDescending(e => e.HireDate);
                    break;
                default:
                    break;
            }
            return employees;
        }

        public static IEnumerable<Employee> SortEmployees(string sortby, bool ascending = true)
        {
            var employees = Data.Employees.Values.AsEnumerable();
            if (employees == null || !employees.Any())
                return employees;

            switch (sortby.ToLower())
            {
                case "name":
                    employees = ascending ? employees.OrderBy(e => e.FullName) : employees.OrderByDescending(e => e.FullName);
                    break;
                case "salary":
                    employees = ascending ? employees.OrderBy(e => e.Salary) : employees.OrderByDescending(e => e.Salary);
                    break;
                case "hiredate":
                    employees = ascending ? employees.OrderBy(e => e.HireDate) : employees.OrderByDescending(e => e.HireDate);
                    break;
                default:
                    break;
            }
            return employees;
        }


        public static decimal GetAverageSalary()
        {
            return Data.Employees.Average(e => e.Value.Salary);
        }
        public static decimal GetHighestSalary()
        {
            return Data.Employees.Max(e => e.Value.Salary);
        }
        public static decimal GetLowestSalary()
        {
            return Data.Employees.Min(e => e.Value.Salary);
        }
        public static decimal GetTotalPayroll()
        {
            return Data.Employees.Sum(e => e.Value.Salary);
        }
        public static int GetEmployeesCountByDepartment(string dept)
        {
            return Data.Employees.Count(e => e.Value.Department.ToLower() == dept.ToLower());
        }
        public static string GetCountByAccountStatus()
        {
            int activeCount = Data.Employees.Count(e => e.Value.IsActive);
            int inactiveCount = Data.Employees.Count(e => !e.Value.IsActive);
            return $"Active Employees: {activeCount}, Inactive Employees: {inactiveCount}";
        }

    }
}
