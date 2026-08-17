using task_02_bank_account_system.BankAccountSystem.Services;

namespace task_02_bank_account_system.BankAccountSystem.UI
{
    public class ConsoleMenu
    {
        private readonly BankService bankService;

        public ConsoleMenu(BankService bankService)
        {
            this.bankService = bankService;
        }

        public void run()
        {
            while (true)
            {
                try
                {
                    DisplayMenu();
                    HandleMenuInput();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                Console.WriteLine();
            }
        }


        private void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Bank Account System");
            Console.WriteLine("1. Create Customer Account");
            Console.WriteLine("2. Deposit funds");
            Console.WriteLine("3. Withdraw funds");
            Console.WriteLine("4. Transfer Money");
            Console.WriteLine("5. View Account Details");
            Console.WriteLine("6. View Transaction History");
            Console.WriteLine("7. View All Accounts");
            Console.WriteLine("8. Exit");
            Console.WriteLine();
        }

        private void HandleMenuInput()
        {
            Console.Write("Please select an option: ");
            var input = Console.ReadLine();
            Console.WriteLine();

            input = input.Trim();

            switch (input)
            {
                case "1":
                    // Handle account creation
                    HandleCreateAccount();
                    break;
                case "2":
                    // Handle depositing funds
                    HandleDepositFunds();
                    break;
                case "3":
                    // Handle withdrawing funds
                    HandleWithdrawFunds();
                    break;
                case "4":
                    // Handle Transferring funds
                    HandleTransferFunds();
                    break;
                case "5":
                    //view account details
                    HandleViewAccountDetails();
                    break;
                case "6":
                    // View Transaction History
                    HandleViewTransactionHistory();
                    break;
                case "7":
                    // View All Accounts
                    HandleViewAllAccounts();
                    break;
                case "8":
                    Console.WriteLine("Exiting the application.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private void HandleCreateAccount()
        {
            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter initial balance: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            Console.Write("Enter account type (1.Checking 2.Savings): ");
            int accountTypeInput = int.Parse(Console.ReadLine());

            bankService.CreateAccount(fullName, email, phone, initialBalance, accountTypeInput);

            Console.WriteLine("Account created successfully!");
        }

        private void HandleDepositFunds()
        {
            Console.Write("Enter account number: ");
            uint accountNumber = uint.Parse(Console.ReadLine());

            Console.Write("Enter deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            bankService.Deposit(accountNumber, amount, description);

            Console.WriteLine("Deposit successful!");
        }

        private void HandleWithdrawFunds()
        {
            Console.Write("Enter account number: ");
            uint accountNumber = uint.Parse(Console.ReadLine());

            Console.Write("Enter withdrawal amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            bankService.Withdraw(accountNumber, amount, description);

            Console.WriteLine("Withdrawal successful!");
        }

        private void HandleTransferFunds()
        {
            Console.Write("Enter source account number: ");
            uint fromAccountNumber = uint.Parse(Console.ReadLine());

            Console.Write("Enter destination account number: ");
            uint toAccountNumber = uint.Parse(Console.ReadLine());

            Console.Write("Enter transfer amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            bankService.Transfer(fromAccountNumber, toAccountNumber, amount, description);

            Console.WriteLine("Transfer successful!");
        }

        private void HandleViewAccountDetails()
        {
            Console.Write("Enter account number: ");
            uint accountNumber = uint.Parse(Console.ReadLine());
            var account = bankService.GetAccount(accountNumber);

            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Customer Name: {account.Customer.FullName}");
            Console.WriteLine($"Email: {account.Customer.Email}");
            Console.WriteLine($"Phone: {account.Customer.Phone}");
            Console.WriteLine($"Balance: {account.Balance}");
            Console.WriteLine($"Account Type: {account.AccountType}");
            Console.WriteLine($"Is Active: {account.IsActive}");
        }

        private void HandleViewTransactionHistory()
        {
            Console.Write("Enter account number: ");
            uint accountNumber = uint.Parse(Console.ReadLine());
            var account = bankService.GetAccount(accountNumber);

            if(account.Transactions.Count == 0)
            {
                Console.WriteLine("No transactions yet");
                return;
            }

            var transactions = account.Transactions.OrderByDescending(t => t.CreatedAt).ToList();

            Console.WriteLine($"Transaction History for Account Number: {account.AccountNumber}");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"ID: {transaction.Id}");
                Console.WriteLine($"Type: {transaction.TransactionType}");
                Console.WriteLine($"Amount: {transaction.Amount}");
                Console.WriteLine($"Balance After Transaction: {transaction.BalanceAfterTransaction}");
                Console.WriteLine($"Description: {transaction.Description}");
                Console.WriteLine($"Date: {transaction.CreatedAt}");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine();
            }
        }

        private void HandleViewAllAccounts()
        {
            var accounts = bankService.Accounts.Values.ToList();

            if (accounts.Count() == 0)
            {
                Console.WriteLine("No Accounts");
                return;
            }

            Console.WriteLine("All Accounts:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}");
                Console.WriteLine($"Customer Name: {account.Customer.FullName}");
                Console.WriteLine($"Account Type: {account.AccountType}");
                Console.WriteLine($"Balance: {account.Balance}");
                Console.WriteLine($"Account Status: {(account.IsActive ? "Active" : "Inactive")}");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine();
            }
        }
    }
}