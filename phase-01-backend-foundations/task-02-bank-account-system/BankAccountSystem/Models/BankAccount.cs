using System.ComponentModel.DataAnnotations;

namespace task_02_bank_account_system.BankAccountSystem.Models
{
    public class BankAccount
    {
        [Required]
        public uint AccountNumber { get; set; } // didn't want to use Guid for account number, so I used uint instead
        public Customer Customer{ get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Balance cannot be negative.")]
        public decimal Balance { get; private set; }
        [Required]
        public AccountType AccountType { get; set; }
        public bool IsActive { get; set; }
        public List<Transaction> Transactions { get; set; }

        public BankAccount(uint accountNumber, Customer customer, decimal balance, AccountType accountType)
        {
            AccountNumber = accountNumber;
            Customer = customer;
            Balance = balance;
            AccountType = accountType;
            IsActive = true;
            Transactions = new List<Transaction>();
        }

        public void Deposit(decimal amount, string description)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");
            Balance += amount;
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                AccountNumber = AccountNumber.ToString(),
                TransactionType = TransactionType.Deposit,
                Amount = amount,
                Description = description,
                BalanceAfterTransaction = Balance,
                CreatedAt = DateTime.Now
            };
            Transactions.Add(transaction);
        }

        public void Withdraw(decimal amount, string description)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds for this withdrawal.");
            Balance -= amount;
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                AccountNumber = AccountNumber.ToString(),
                TransactionType = TransactionType.Withdrawal,
                Amount = amount,
                Description = description,
                BalanceAfterTransaction = Balance,
                CreatedAt = DateTime.Now
            };
            Transactions.Add(transaction);
        }
    }
}
