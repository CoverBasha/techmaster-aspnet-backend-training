using task_05_debug_refactor_pack.Models;

namespace task_05_debug_refactor_pack.Services
{
    public class OrderCalculator
    {
        public static Order Calculate(string customerName, string productName, decimal price, int quantity, int customerType)
        {
            float discount;
            switch (customerType)
            {
                case 1:
                    discount = 0;
                    break;
                case 2:
                    discount = 0.05f;
                    break;
                case 3:
                    discount = 0.1f;
                    break;
                case 4:
                    discount = 0.15f;
                    break;
                default:
                    throw new Exception("Invalid customer type");
            }
            
            Customer customer = new Customer(customerName, productName, price, quantity, (CustomerType)customerType);

            return new Order(customer, discount);
        }
    }
}
