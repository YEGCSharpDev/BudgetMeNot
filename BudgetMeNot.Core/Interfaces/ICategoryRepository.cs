using BudgetMeNot.Core.Models;

namespace BudgetMeNot.Core.Interfaces
{
    /// <summary>
    /// Defines the contract for category-related data operations.
    /// This interface provides methods for managing budget categories asynchronously.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Retrieves all categories asynchronously.
        /// </summary>
        /// <returns>A collection of all categories.</returns>
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        /// <summary>
        /// Retrieves a specific category by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>The category with the specified ID, or null if not found.</returns>
        Task<Category> GetCategoryByIdAsync(int id);

        /// <summary>
        /// Adds a new category to the repository asynchronously.
        /// </summary>
        /// <param name="category">The category to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddCategoryAsync(Category category);

        /// <summary>
        /// Updates an existing category in the repository asynchronously.
        /// </summary>
        /// <param name="category">The category with updated information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateCategoryAsync(Category category);

        /// <summary>
        /// Deletes a category from the repository asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the category to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteCategoryAsync(int id);
    }
}
