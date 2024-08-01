using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace BudgetMeNot.Infrastructure.Data
{
    /// <summary>
    /// Provides a way to create instances of ApplicationDbContext at design time,
    /// such as when running Entity Framework Core migrations.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        /// <summary>
        /// Creates a new instance of ApplicationDbContext.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time services.</param>
        /// <returns>A new instance of ApplicationDbContext.</returns>
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Try to get the connection string from environment variables
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

            // If not found in environment variables, use a default connection string
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Host=localhost;Database=BudgetMeNotDb;Username=postgres;Password=DummyPassword";
            }

            // Configure the context to use PostgreSQL
            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
