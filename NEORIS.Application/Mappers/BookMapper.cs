using NEORIS.Application.DTOs;
using NEORIS.Application.Interfaces;
using NEORIS.Domain.Entities;

namespace NEORIS.Application.Mappers
{
    /// <summary>
    /// Maps Book entities to BookDto.
    /// </summary>
    public class BookMapper : IBookMapper
    {
        public BookDto ToDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Year = book.Year,
                Genre = book.Genre,
                PageCount = book.PageCount,
                AuthorId = book.AuthorId,
                AuthorFullName = book.Author?.FullName
            };
        }
    }
}
