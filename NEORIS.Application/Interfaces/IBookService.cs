using System.Collections.Generic;
using System.Threading.Tasks;
using NEORIS.Application.DTOs;

namespace NEORIS.Application.Interfaces
{
    /// <summary>
    /// Use-case contract for book operations.
    /// </summary>
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto> GetByIdAsync(int id);
        Task<BookDto> CreateAsync(CreateBookDto dto);
    }
}
