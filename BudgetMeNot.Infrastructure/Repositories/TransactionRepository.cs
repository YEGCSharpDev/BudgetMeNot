using BudgetMeNot.Core.Interfaces;
using BudgetMeNot.Core.Models;
using BudgetMeNot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetMeNot.Infrastructure.Repositories
{
    /// <summary>
    /// Implements the ITransactionRepository interface to provide data access operations for Transaction entities.
    /// This class uses Entity Framework Core to interact with the database.
    /// </summary>
    public class TransactionRepository : ITransactionRepository
    {
        // The database context
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the TransactionRepository class.
        /// </summary>
        /// <param name="context">The database context to be used for data operations.</param>
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all transactions from the database asynchronously.
        /// </summary>
        /// <returns>A collection of all Transaction entities.</returns>
        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            // ToListAsync() executes the query asynchronously and returns the results as a List
            return await _context.Transactions.ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific transaction by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction to retrieve.</param>
        /// <returns>The Transaction entity if found; otherwise, null.</returns>
        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            // FindAsync is an efficient way to find an entity by its primary key
            return await _context.Transactions.FindAsync(id);
        }

        /// <summary>
        /// Adds a new transaction to the database asynchronously.
        /// </summary>
        /// <param name="transaction">The Transaction entity to be added.</param>
        public async Task AddTransactionAsync(Transaction transaction)
        {
            // Add the new transaction to the DbSet
            _context.Transactions.Add(transaction);
            // SaveChangesAsync commits the changes to the database
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing transaction in the database asynchronously.
        /// </summary>
        /// <param name="transaction">The Transaction entity with updated information.</param>
        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            // Mark the entity as modified so EF Core knows to update it
            _context.Entry(transaction).State = EntityState.Modified;
            // SaveChangesAsync commits the changes to the database
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a transaction from the database asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction to be deleted.</param>
        public async Task DeleteTransactionAsync(int id)
        {
            // Find the transaction by id
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                // Remove the transaction from the DbSet
                _context.Transactions.Remove(transaction);
                // SaveChangesAsync commits the changes to the database
                await _context.SaveChangesAsync();
            }
            // If transaction is null, no action is taken
        }
    }
}
