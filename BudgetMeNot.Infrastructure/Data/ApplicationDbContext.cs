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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the DbSet of Accounts. This property is used to query and save instances of Account.
        /// </summary>
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
        /// Configures the model that was discovered by convention from the entity types
        /// exposed in DbSet properties on your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Account entity
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18,2)");

            // Configure the Category entity
            modelBuilder.Entity<Category>()
                .Property(c => c.TargetAmount)
                .HasColumnType("decimal(18,2)");

            // Configure the Transaction entity
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
