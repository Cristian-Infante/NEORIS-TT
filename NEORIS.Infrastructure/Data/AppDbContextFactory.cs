using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NEORIS.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=localhost,1434;Database=NeorisLibraryDB;User Id=sa;Password=Neoris@12345;TrustServerCertificate=True")
                .Options;

            return new AppDbContext(options);
        }
    }
}
