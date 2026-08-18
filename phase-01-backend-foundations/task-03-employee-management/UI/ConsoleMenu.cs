using Task_03_Employee_Management_Console_App.Services;

namespace Task_03_Employee_Management_Console_App.UI
{
    public static class ConsoleMenu
    {

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Deactivate Employee");
                Console.WriteLine("4. Search employees");
                Console.WriteLine("5. filter employees by department");
                Console.WriteLine("6. Sort Employees");
                Console.WriteLine("7. Show Salary Reports");
                Console.WriteLine("8. Show All Employees");
                Console.WriteLine("9. Exit");
                Console.WriteLine();

                Console.Write("Select an option: ");
                string option = Console.ReadLine();
                option = option.Trim();
                Console.WriteLine();

                switch(option)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        UpdateEmployee();
                        break;
                    case "3":
                        DeactivateEmployee();
                        break;
                    case "4":
                        SearchEmployees();
                        break;
                    case "5":
                        FilterEmployeesByDepartment();
                        break;
                    case "6":
                        SortEmployees();
                        break;
                    case "7":
                        ShowSalaryReports();
                        break;
                    case "8":
                        ShowAllEmployees();
                        break;
                    case "9":
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        private static void DeactivateEmployee()
        {
            Console.Write("Enter Employee ID to deactivate: ");
            int id = int.Parse(Console.ReadLine());

            EmployeeService.DeactivateEmployee(id);
            Console.WriteLine("Employee deactivated successfully.");

        }

        private static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());
            EmployeeService.GetEmployee(id);

            Console.Write("Enter new Email (type 'skip' to skip this info): ");
            string email = Console.ReadLine();
            email = email.Trim() == "skip" ? EmployeeService.GetEmployee(id).Email : email;

            Console.Write("Enter new Department (type 'skip' to skip this info): ");
            string department = Console.ReadLine();
            department = department.Trim() == "skip" ? EmployeeService.GetEmployee(id).Department : department;

            Console.Write("Enter new Position (type 'skip' to skip this info): ");
            string position = Console.ReadLine();
            position = position.Trim() == "skip" ? EmployeeService.GetEmployee(id).Position : position;

            Console.Write("Enter new Salary (type 'skip' to skip this info): ");
            decimal salary;
            var salaryInput = Console.ReadLine().Trim();
            if (salaryInput == "skip")
                salary = EmployeeService.GetEmployee(id).Salary;
            else
                salary = decimal.Parse(salaryInput);

            EmployeeService.UpdateEmployee(id, email, department, position, salary);

            Console.WriteLine("Employee updated successfully.");
        }

        private static void AddEmployee()
        {
            Console.Write("Enter Full Name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Department: ");
            string department = Console.ReadLine();

            Console.Write("Enter Position: ");
            string position = Console.ReadLine();

            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Hire Date (yyyy-MM-dd): ");
            DateTime hireDate = DateTime.Parse(Console.ReadLine());

            EmployeeService.AddEmployee(fullName, email, department, position, salary, hireDate);

            Console.WriteLine("Employee added successfully.");
        }

        private static void SearchEmployees()
        {
            Console.WriteLine("Search Employees");
            Console.WriteLine("1. Search by ID");
            Console.WriteLine("2. Search by Name");
            Console.WriteLine("3. Back to Main Menu");
            Console.WriteLine();
            Console.Write("Select an option: ");
            string option = Console.ReadLine();
            option = option.Trim();
            Console.WriteLine();
            switch (option)
            {
                case "1":
                    SearchEmployeeById();
                    break;
                case "2":
                    SearchEmployeeByName();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static void SearchEmployeeById()
        {
            Console.Write("Enter Employee ID to search: ");
            int id = int.Parse(Console.ReadLine());
            var employee = EmployeeService.GetEmployee(id);
            Console.WriteLine();
            Console.WriteLine("Employee Details:");

            Console.WriteLine($"ID: {employee.EmployeeId}");
            Console.WriteLine($"Name: {employee.FullName}");
            Console.WriteLine($"Email: {employee.Email}");
            Console.WriteLine($"Department: {employee.Department}");
            Console.WriteLine($"Position: {employee.Position}");
            Console.WriteLine($"Salary: {employee.Salary}");
            Console.WriteLine($"Hire Date: {employee.HireDate.ToShortDateString()}");
            Console.WriteLine($"Active: {employee.IsActive}");
        }

        private static void SearchEmployeeByName()
        {
            Console.Write("Enter Employee Name to search: ");
            string name = Console.ReadLine();
            var employees = EmployeeReportService.GetEmployee(name);
            Console.WriteLine();

            foreach (var employee in employees)
            {
                
                Console.WriteLine("Employee Details:");
                Console.WriteLine();
                Console.WriteLine($"ID: {employee.EmployeeId}");
                Console.WriteLine($"Name: {employee.FullName}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"Department: {employee.Department}");
                Console.WriteLine($"Position: {employee.Position}");
                Console.WriteLine($"Salary: {employee.Salary}");
                Console.WriteLine($"Hire Date: {employee.HireDate.ToShortDateString()}");
                Console.WriteLine($"Active: {employee.IsActive}");
                Console.WriteLine();
            }
        }

        private static void FilterEmployeesByDepartment()
        {
            Console.Write("Enter Department to filter: ");
            string department = Console.ReadLine();
            Console.Write("Do you want to filter by active status? (y/n): ");
            string filterActive = Console.ReadLine();
            bool? isActive = null;
            if (filterActive.ToLower() == "y")
            {
                Console.Write("Enter active status (true/false): ");
                isActive = bool.Parse(Console.ReadLine());
            }
            var employees = EmployeeReportService.GetEmployeesByDepartment(department, isActive);
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}");
                Console.WriteLine($"Name: {employee.FullName}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"Department: {employee.Department}");
                Console.WriteLine($"Position: {employee.Position}");
                Console.WriteLine($"Salary: {employee.Salary}");
                Console.WriteLine($"Hire Date: {employee.HireDate.ToShortDateString()}");
                Console.WriteLine($"Active: {employee.IsActive}");
                Console.WriteLine();
            }
        }

        private static void SortEmployees()
        {
            Console.Write("Enter sort by (name/salary/hiredate): ");
            string sortBy = Console.ReadLine();
            Console.Write("Enter sort order (asc/desc): ");
            string sortOrder = Console.ReadLine();
            bool ascending = sortOrder.ToLower() == "asc";
            var employees = EmployeeReportService.SortEmployees(sortBy, ascending);
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}");
                Console.WriteLine($"Name: {employee.FullName}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"Department: {employee.Department}");
                Console.WriteLine($"Position: {employee.Position}");
                Console.WriteLine($"Salary: {employee.Salary}");
                Console.WriteLine($"Hire Date: {employee.HireDate.ToShortDateString()}");
                Console.WriteLine($"Active: {employee.IsActive}");
                Console.WriteLine();
            }
        }

        private static void ShowSalaryReports()
        {
            Console.WriteLine("Salary Reports");
            Console.WriteLine(EmployeeReportService.GetAverageSalary());
            Console.WriteLine(EmployeeReportService.GetHighestSalary());
            Console.WriteLine(EmployeeReportService.GetLowestSalary());
            Console.WriteLine(EmployeeReportService.GetTotalPayroll);
            Console.Write("Enter department name to count employees: ");
            Console.WriteLine(EmployeeReportService.GetEmployeesCountByDepartment(Console.ReadLine()));
            Console.WriteLine(EmployeeReportService.GetCountByAccountStatus());

        }

        private static void ShowAllEmployees()
        {
            var employees = EmployeeReportService.GetAllEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}");
                Console.WriteLine($"Name: {employee.FullName}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"Department: {employee.Department}");
                Console.WriteLine($"Position: {employee.Position}");
                Console.WriteLine($"Salary: {employee.Salary}");
                Console.WriteLine($"Hire Date: {employee.HireDate.ToShortDateString()}");
                Console.WriteLine($"Active: {employee.IsActive}");
                Console.WriteLine();
            }
        }
    }
}
