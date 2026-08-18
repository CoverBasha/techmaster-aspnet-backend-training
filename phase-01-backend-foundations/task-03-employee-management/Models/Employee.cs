using System.ComponentModel.DataAnnotations;

namespace Task_03_Employee_Management_Console_App.Models
{
    public class Employee
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int EmployeeId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }


        public Employee(int id, string fullName, string email, string department, string position, decimal salary, DateTime hireDate)
        {
            FullName = fullName;
            Email = email;
            Department = department;
            Position = position;
            Salary = salary;
            HireDate = hireDate;
            EmployeeId = id;
            IsActive = true;
        }

        public Employee(int id, string fullName, string email, string department, string position, decimal salary, DateTime hireDate, bool isActive)
        {
            FullName = fullName;
            Email = email;
            Department = department;
            Position = position;
            Salary = salary;
            HireDate = hireDate;
            EmployeeId = id;
            IsActive = isActive;
        }
    }
}
