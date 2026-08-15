using System.ComponentModel.DataAnnotations;

namespace task_02_bank_account_system.BankAccountSystem.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }

        public Customer(string fullName, string email, string phone)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            Phone = phone;
            CreatedAt = DateTime.Now;
        }
    }
}
