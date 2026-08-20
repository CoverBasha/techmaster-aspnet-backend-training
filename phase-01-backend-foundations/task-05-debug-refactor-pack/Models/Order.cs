namespace task_05_debug_refactor_pack.Models
{
    public class Order
    {
        public Customer Customer { get; private set; }

        public decimal  Total { get; private set; }
        public decimal Discount { get; set; }
        public decimal PriceAfterDiscount { get; private set; }
        public decimal Tax { get; private set; }
        public decimal Shipping { get; private set; }
        public decimal FinalPrice { get; private set; }

        public Order(Customer customer, float discount)
        {
            Customer = customer;

            Total = customer.Quantity * customer.Price;
            Discount = Total * (decimal)discount;
            PriceAfterDiscount = Total - Discount;
            Tax = PriceAfterDiscount * 0.14m;
            Shipping = PriceAfterDiscount >= 1000 ? 0 : 50;
            FinalPrice = PriceAfterDiscount + Tax + Shipping;
        }
    }
}
