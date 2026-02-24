using Microsoft.EntityFrameworkCore;
using NEORIS.Infrastructure.Data;

namespace NEORIS.Api.Infrastructure
{
    /// <summary>
    /// Ensures the database schema exists on application startup.
    /// </summary>
    public class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Creates the database and all tables if they do not already exist.
        /// </summary>
        public void EnsureCreated()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(_connectionString)
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
