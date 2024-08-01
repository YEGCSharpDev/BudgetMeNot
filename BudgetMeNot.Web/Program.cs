using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using BudgetMeNot.Core.Interfaces;
using BudgetMeNot.Infrastructure.Data;
using BudgetMeNot.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using Microsoft.Extensions.Logging;
using System;

/// <summary>
/// Entry point of the application. Configures and runs the web host.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

// Configure data protection
// This sets up encryption for sensitive data like cookies and tokens
builder.Services.AddDataProtection()
    // Persist encryption keys to a file system for consistency across app restarts
    .PersistKeysToFileSystem(new DirectoryInfo("/app/keys"))
    // Configure the encryption algorithms
    .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration()
    {
        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
    });

// Add services to the dependency injection container
// These services will be available throughout the application

// Add support for Razor Pages
builder.Services.AddRazorPages();
// Add support for Server-Side Blazor
builder.Services.AddServerSideBlazor();

// Configure the database context to use PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories for dependency injection
// This allows these repositories to be injected into controllers or other services
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Build the application
var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

// Configure the HTTP request pipeline
// This determines how the app responds to HTTP requests

// If not in development, use stricter error handling and HTTPS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();
// Serve static files (like CSS, JavaScript, and images)
app.UseStaticFiles();
// Enable routing
app.UseRouting();

// Map Blazor Hub
// This sets up the SignalR hub that Blazor uses for real-time communication
app.MapBlazorHub();
// Set up the fallback page for Blazor routing
app.MapFallbackToPage("/_Host");

// Ensure the database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

// Configure the app to listen on port 80
app.Urls.Add("http://0.0.0.0:80");

// Run the application
app.Run();
