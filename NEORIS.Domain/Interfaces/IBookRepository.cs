using System.Collections.Generic;
using System.Threading.Tasks;
using NEORIS.Domain.Entities;

namespace NEORIS.Domain.Interfaces
{
    /// <summary>
    /// Repository contract for book persistence operations.
    /// </summary>
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<int> CountAsync();
        Task<Book> CreateAsync(Book book);
    }
}
