using Microsoft.EntityFrameworkCore;
using NEORIS.Domain.Entities;

namespace NEORIS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.OriginCity).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(200);

                entity.HasMany(a => a.Books)
                      .WithOne(b => b.Author)
                      .HasForeignKey(b => b.AuthorId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Title).IsRequired().HasMaxLength(300);
                entity.Property(e => e.Genre).IsRequired().HasMaxLength(100);
            });
        }
    }
}
