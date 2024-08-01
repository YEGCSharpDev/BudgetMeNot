using BudgetMeNot.Core.Models;

namespace BudgetMeNot.Core.Interfaces
{
    /// <summary>
    /// Defines the contract for account-related data operations.
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Retrieves all accounts asynchronously.
        /// </summary>
        /// <returns>A collection of all accounts.</returns>
        Task<IEnumerable<Account>> GetAllAccountsAsync();

        /// <summary>
        /// Retrieves a specific account by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the account.</param>
        /// <returns>The account with the specified ID, or null if not found.</returns>
        Task<Account> GetAccountByIdAsync(int id);

        /// <summary>
        /// Adds a new account to the repository asynchronously.
        /// </summary>
        /// <param name="account">The account to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAccountAsync(Account account);

        /// <summary>
        /// Updates an existing account in the repository asynchronously.
        /// </summary>
        /// <param name="account">The account with updated information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAccountAsync(Account account);

        /// <summary>
        /// Deletes an account from the repository asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the account to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAccountAsync(int id);
    }
}
