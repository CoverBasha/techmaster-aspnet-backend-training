using task_02_bank_account_system.BankAccountSystem.Models;

namespace task_02_bank_account_system.BankAccountSystem.Services
{
    public class BankService
    {
        public Dictionary<uint, BankAccount> Accounts { get; set; }
        public Dictionary<Guid, Customer> Customers { get; set; }

        public BankAccount CurrentAccount { get; private set; }

        public BankService()
        {
            Accounts = new Dictionary<uint, BankAccount>();
        }

        public void CreateAccount(string fullName, string email, string phone, decimal initialBalance, AccountType accountType)
        {
            uint accountNumber = Accounts.Count > 0 ? Accounts.Keys.Max() + 1 : 100000;
            while (Accounts.ContainsKey(accountNumber))
                accountNumber++;

            var customer = CreateCustomer(fullName, email, phone);
            var newAccount = new BankAccount(accountNumber, customer, initialBalance, accountType);
            Accounts.Add(accountNumber, newAccount);
            Customers.Add(customer.Id, customer);
        }

        private Customer CreateCustomer(string name, string email, string phoneNumber)
        {
            var newCustomer = new Customer(name, email, phoneNumber);
            return newCustomer;
        }
    }
}
