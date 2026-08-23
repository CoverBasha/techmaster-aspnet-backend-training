using task_02_bank_account_system.BankAccountSystem.Models;

namespace task_02_bank_account_system.BankAccountSystem.Services
{
    public class BankService
    {
        public Dictionary<uint, BankAccount> Accounts { get; set; }

        public BankService()
        {
            Accounts = [];
        }

        public void CreateAccount(string fullName, string email, string phone, decimal initialBalance, int accountType)
        {
            uint accountNumber = Accounts.Count > 0 ? Accounts.Keys.Max() + 1 : 1;
            while (Accounts.ContainsKey(accountNumber))
                accountNumber++;

            var customer = new Customer(fullName, email, phone);
            var newAccount = new BankAccount(accountNumber, customer, initialBalance, (AccountType)accountType);
            Accounts.Add(accountNumber, newAccount);
        }

        public BankAccount GetAccount(uint accountNumber)
        {
            if (Accounts.TryGetValue(accountNumber, out var account))
                return account;
            throw new KeyNotFoundException("Account not found.");
        }

        public void Deposit(uint accountNumber, decimal amount, string description)
        {
            var account = GetAccount(accountNumber);
            account.Deposit(amount, description);
        }

        public void Withdraw(uint accountNumber, decimal amount, string description)
        {
            var account = GetAccount(accountNumber);
            account.Withdraw(amount, description);
        }

        public void Transfer(uint fromAccountNumber, uint toAccountNumber, decimal amount, string description)
        {
            if (fromAccountNumber == toAccountNumber)
                throw new Exception("Can't transfer to oneself");

            var fromAccount = GetAccount(fromAccountNumber);
            var toAccount = GetAccount(toAccountNumber);
            fromAccount.Withdraw(amount, $"Transfer to {toAccountNumber}: {description}");
            toAccount.Deposit(amount, $"Transfer from {fromAccountNumber}: {description}");
        }


    }
}
