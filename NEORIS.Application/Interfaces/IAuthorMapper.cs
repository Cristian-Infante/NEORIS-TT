using NEORIS.Application.DTOs;
using NEORIS.Domain.Entities;

namespace NEORIS.Application.Interfaces
{
    /// <summary>
    /// Maps between Author domain entities and DTOs.
    /// </summary>
    public interface IAuthorMapper
    {
        AuthorDto ToDto(Author author);
    }
}
