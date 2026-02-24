using NEORIS.Application.DTOs;
using NEORIS.Domain.Entities;

namespace NEORIS.Application.Interfaces
{
    /// <summary>
    /// Maps between Book domain entities and DTOs.
    /// </summary>
    public interface IBookMapper
    {
        BookDto ToDto(Book book);
    }
}
