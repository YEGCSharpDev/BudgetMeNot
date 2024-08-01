namespace BudgetMeNot.Core.Models
{
    /// <summary>
    /// Represents a budget category in the financial management system.
    /// This class supports a hierarchical structure of categories and subcategories.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the parent category, if this is a subcategory.
        /// Null if this is a top-level category.
        /// </summary>
        public int? ParentCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the parent category object.
        /// Null if this is a top-level category.
        /// </summary>
        public Category ParentCategory { get; set; }

        /// <summary>
        /// Gets or sets the list of subcategories under this category.
        /// Empty if this is a leaf category.
        /// </summary>
        public List<Category> Subcategories { get; set; }

        /// <summary>
        /// Gets or sets the target budget amount for this category.
        /// </summary>
        /// <remarks>
        /// For parent categories, this might represent the sum of subcategory targets
        /// or an overall target for the entire category group.
        /// </remarks>
        public decimal TargetAmount { get; set; }
    }
}
