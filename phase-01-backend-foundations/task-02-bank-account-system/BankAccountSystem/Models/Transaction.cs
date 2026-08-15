namespace task_02_bank_account_system.BankAccountSystem.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
