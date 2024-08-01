using BudgetMeNot.Core.Interfaces;
using BudgetMeNot.Core.Models;
using BudgetMeNot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetMeNot.Infrastructure.Repositories
{
    /// <summary>
    /// Implements the ICategoryRepository interface to provide data access operations for Category entities.
    /// This class uses Entity Framework Core to interact with the database.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        // The database context
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the CategoryRepository class.
        /// </summary>
        /// <param name="context">The database context to be used for data operations.</param>
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all categories from the database asynchronously.
        /// </summary>
        /// <returns>A collection of all Category entities.</returns>
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            // ToListAsync() executes the query asynchronously and returns the results as a List
            return await _context.Categories.ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific category by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the category to retrieve.</param>
        /// <returns>The Category entity if found; otherwise, null.</returns>
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            // FindAsync is an efficient way to find an entity by its primary key
            return await _context.Categories.FindAsync(id);
        }

        /// <summary>
        /// Adds a new category to the database asynchronously.
        /// </summary>
        /// <param name="category">The Category entity to be added.</param>
        public async Task AddCategoryAsync(Category category)
        {
            // Add the new category to the DbSet
            _context.Categories.Add(category);
            // SaveChangesAsync commits the changes to the database
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing category in the database asynchronously.
        /// </summary>
        /// <param name="category">The Category entity with updated information.</param>
        public async Task UpdateCategoryAsync(Category category)
        {
            // Mark the entity as modified so EF Core knows to update it
            _context.Entry(category).State = EntityState.Modified;
            // SaveChangesAsync commits the changes to the database
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a category from the database asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the category to be deleted.</param>
        public async Task DeleteCategoryAsync(int id)
        {
            // Find the category by id
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                // Remove the category from the DbSet
                _context.Categories.Remove(category);
                // SaveChangesAsync commits the changes to the database
                await _context.SaveChangesAsync();
            }
            // If category is null, no action is taken
        }
    }
}
