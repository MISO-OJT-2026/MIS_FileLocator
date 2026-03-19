using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MIS_FileLocator.Services;
using System.IO;


namespace MIS_FileLocator.Data
{
    public class ApplicationDbContextFactory
        : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
            var dummyUserService = new DummyUserService();

            return new ApplicationDbContext(optionsBuilder.Options, dummyUserService);
        }

        class DummyUserService : ICurrentUserService
        {
            // If you named this GetCurrentFullNameAsync earlier, use that instead!
            public Task<string> GetCurrentFullNameAsync()
            {
                return Task.FromResult("System Migration");
            }

            public Task<string> GetCurrentUserIdAsync()
            {
                return Task.FromResult("System Migration");
            }
        }
    }
}