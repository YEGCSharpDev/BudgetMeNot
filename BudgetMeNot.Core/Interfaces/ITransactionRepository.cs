using BudgetMeNot.Core.Models;

namespace BudgetMeNot.Core.Interfaces
{
    /// <summary>
    /// Defines the contract for transaction-related data operations.
    /// This interface provides methods for managing financial transactions asynchronously.
    /// </summary>
    public interface ITransactionRepository
    {
        /// <summary>
        /// Retrieves all transactions asynchronously.
        /// </summary>
        /// <returns>A collection of all transactions.</returns>
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();

        /// <summary>
        /// Retrieves a specific transaction by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction.</param>
        /// <returns>The transaction with the specified ID, or null if not found.</returns>
        Task<Transaction> GetTransactionByIdAsync(int id);

        /// <summary>
        /// Adds a new transaction to the repository asynchronously.
        /// </summary>
        /// <param name="transaction">The transaction to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddTransactionAsync(Transaction transaction);

        /// <summary>
        /// Updates an existing transaction in the repository asynchronously.
        /// </summary>
        /// <param name="transaction">The transaction with updated information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateTransactionAsync(Transaction transaction);

        /// <summary>
        /// Deletes a transaction from the repository asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Caution: Deleting transactions can affect budget calculations and historical records.
        /// Consider implementing a soft delete or archiving mechanism instead of permanent deletion.
        /// </remarks>
        Task DeleteTransactionAsync(int id);
    }
}
