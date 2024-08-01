namespace BudgetMeNot.Core.Models
{
    /// <summary>
    /// Represents a financial transaction in the budgeting system.
    /// This class captures the details of individual financial activities.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date when the transaction occurred.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// Positive values typically represent income or credits, while negative values represent expenses or debits.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a description of the transaction.
        /// This can include details like the payee, purpose, or any notes about the transaction.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ID of the account associated with this transaction.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the Account object associated with this transaction.
        /// This property enables navigation to the full account details.
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Gets or sets the ID of the category associated with this transaction.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Category object associated with this transaction.
        /// This property enables navigation to the full category details.
        /// </summary>
        public Category Category { get; set; }
    }
}
