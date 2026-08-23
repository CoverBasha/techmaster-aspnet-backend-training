using System.ComponentModel.DataAnnotations;

namespace task_05_debug_refactor_pack.Models
{
    public class Customer
    {
        public Customer(string name, string productName, decimal price, int quantity, CustomerType customerType)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Customer name cannot be empty");
            if (string.IsNullOrWhiteSpace(productName))
                throw new Exception("Product name cannot be empty");
            Name = name;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            CustomerType = customerType;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public CustomerType CustomerType { get; set; }
    }
    public enum CustomerType
    {
        Regular,
        Silver,
        Gold,
        VIP
    }
}
