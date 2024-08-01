using Microsoft.EntityFrameworkCore;
using BudgetMeNot.Core.Models;

namespace BudgetMeNot.Infrastructure.Data
{
    /// <summary>
    /// Represents the database context for the BudgetMeNot application.
    /// This class is responsible for coordinating Entity Framework functionality for a given data model.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationDbContext.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        /// <remarks>
        /// The options parameter is typically configured in the Startup.cs or Program.cs file
        /// and includes database provider information, connection string, etc.
        /// </remarks>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the DbSet of Accounts. This property is used to query and save instances of Account.
        /// </summary>
        /// <remarks>
        /// DbSet represents the collection of all entities in the context, or that can be queried from the database, of a given type.
        /// DbSet is used to perform CRUD operations on the Accounts table.
        /// </remarks>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of Transactions. This property is used to query and save instances of Transaction.
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of Categories. This property is used to query and save instances of Category.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but before the model has been locked down and used to initialize the context.
        /// The default implementation does nothing, but it can be overridden to further configure the model that was discovered by convention.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Calls the base class implementation of OnModelCreating.
            // This ensures that any configuration in the base DbContext class is applied.
            base.OnModelCreating(modelBuilder);

            // Configure the Account entity
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18,2)");
            // This specifies that the Balance property should be stored as a decimal
            // with a precision of 18 and a scale of 2 (i.e., 16 digits before the decimal point and 2 after)

            // Configure the Category entity
            modelBuilder.Entity<Category>()
                .Property(c => c.TargetAmount)
                .HasColumnType("decimal(18,2)");
            // Similar configuration for the TargetAmount property of Category

            // Configure the Transaction entity
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");
            // Similar configuration for the Amount property of Transaction
        }
    }
}
