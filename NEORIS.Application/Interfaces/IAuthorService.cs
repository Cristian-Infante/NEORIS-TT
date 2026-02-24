using System.Collections.Generic;
using System.Threading.Tasks;
using NEORIS.Application.DTOs;

namespace NEORIS.Application.Interfaces
{
    /// <summary>
    /// Use-case contract for author operations.
    /// </summary>
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(int id);
        Task<AuthorDto> CreateAsync(CreateAuthorDto dto);
    }
}
