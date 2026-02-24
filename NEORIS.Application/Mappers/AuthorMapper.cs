using NEORIS.Application.DTOs;
using NEORIS.Application.Interfaces;
using NEORIS.Domain.Entities;

namespace NEORIS.Application.Mappers
{
    /// <summary>
    /// Maps Author entities to AuthorDto.
    /// </summary>
    public class AuthorMapper : IAuthorMapper
    {
        public AuthorDto ToDto(Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                FullName = author.FullName,
                BirthDate = author.BirthDate,
                OriginCity = author.OriginCity,
                Email = author.Email
            };
        }
    }
}
