using BudgetMeNot.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using BudgetMeNot.Core.Models;
using BudgetMeNot.Infrastructure.Data;

namespace BudgetMeNot.Infrastructure.Repositories
{
    /// <summary>
    /// Implements the IAccountRepository interface to provide data access operations for Account entities.
    /// This class uses Entity Framework Core to interact with the database.
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        // The database context
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the AccountRepository class.
        /// </summary>
        /// <param name="context">The database context to be used for data operations.</param>
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all accounts from the database asynchronously.
        /// </summary>
        /// <returns>A collection of all Account entities.</returns>
        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            // ToListAsync() executes the query asynchronously and returns the results as a List
            return await _context.Accounts.ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific account by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the account to retrieve.</param>
        /// <returns>The Account entity if found; otherwise, null.</returns>
        public async Task<Account> GetAccountByIdAsync(int id)
        {
            // FindAsync is an efficient way to find an entity by its primary key
            return await _context.Accounts.FindAsync(id);
        }

        /// <summary>
        /// Adds a new account to the database asynchronously.
        /// </summary>
        /// <param name="account">The Account entity to be added.</param>
        public async Task AddAccountAsync(Account account)
        {
            // Add the new account to the DbSet
            _context.Accounts.Add(account);
            // SaveChangesAsync commits the changes to the database
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing account in the database asynchronously.
        /// </summary>
        /// <param name="account">The Account entity with updated information.</param>
        public async Task UpdateAccountAsync(Account account)
        {
            // Mark the entity as modified so EF Core knows to update it
            _context.Entry(account).State = EntityState.Modified;
            // SaveChangesAsync commits the changes to the database
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an account from the database asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the account to be deleted.</param>
        public async Task DeleteAccountAsync(int id)
        {
            // Find the account by id
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                // Remove the account from the DbSet
                _context.Accounts.Remove(account);
                // SaveChangesAsync commits the changes to the database
                await _context.SaveChangesAsync();
            }
            // If account is null, no action is taken
        }
    }
}
