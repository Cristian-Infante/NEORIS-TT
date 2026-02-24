using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NEORIS.Domain.Entities;
using NEORIS.Domain.Interfaces;
using NEORIS.Infrastructure.Data;

namespace NEORIS.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Authors.AnyAsync(a => a.Id == id);
        }

        public async Task<Author> CreateAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }
    }
}
