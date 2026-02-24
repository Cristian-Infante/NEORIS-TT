using System.Collections.Generic;
using System.Threading.Tasks;
using NEORIS.Domain.Entities;

namespace NEORIS.Domain.Interfaces
{
    /// <summary>
    /// Repository contract for author persistence operations.
    /// </summary>
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<Author> CreateAsync(Author author);
    }
}
