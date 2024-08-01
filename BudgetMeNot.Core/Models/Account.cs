namespace BudgetMeNot.Core.Models
{
    /// <summary>
    /// Represents a financial account in the budgeting system.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets the unique identifier for the account.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        public AccountType Type { get; set; }

        /// <summary>
        /// Gets or sets the current balance of the account.
        /// </summary>
        /// <remarks>
        /// This should be kept up-to-date with the sum of all transactions
        /// for performance reasons, rather than calculated on-the-fly.
        /// </remarks>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the list of transactions associated with this account.
        /// </summary>
        public List<Transaction> Transactions { get; set; }
    }

    /// <summary>
    /// Defines the types of accounts available in the system.
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// Represents a savings account, typically used for long-term savings and earning interest.
        /// </summary>
        Savings,

        /// <summary>
        /// Represents a checking account, used for day-to-day transactions and bill payments.
        /// </summary>
        Checking,

        /// <summary>
        /// Represents a credit account, such as a credit card, where money is borrowed.
        /// </summary>
        Credit,

        /// <summary>
        /// Represents a loan account, such as a mortgage or personal loan.
        /// </summary>
        Loan
    }
}
