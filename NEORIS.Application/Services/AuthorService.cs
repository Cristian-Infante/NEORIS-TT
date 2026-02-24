using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NEORIS.Application.DTOs;
using NEORIS.Application.Interfaces;
using NEORIS.Domain.Entities;
using NEORIS.Domain.Interfaces;

namespace NEORIS.Application.Services
{
    /// <summary>
    /// Implements author use cases: retrieval and creation with field validation.
    /// </summary>
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorValidator _validator;
        private readonly IAuthorMapper _mapper;

        public AuthorService(
            IAuthorRepository authorRepository,
            IAuthorValidator validator,
            IAuthorMapper mapper)
        {
            _authorRepository = authorRepository;
            _validator = validator;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all registered authors.
        /// </summary>
        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return authors.Select(_mapper.ToDto);
        }

        /// <summary>
        /// Returns an author by its identifier, or null if not found.
        /// </summary>
        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            return author == null ? null : _mapper.ToDto(author);
        }

        /// <summary>
        /// Creates a new author after validating required fields.
        /// </summary>
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto dto)
        {
            _validator.Validate(dto);

            var author = new Author
            {
                FullName = dto.FullName,
                BirthDate = dto.BirthDate,
                OriginCity = dto.OriginCity,
                Email = dto.Email
            };

            var created = await _authorRepository.CreateAsync(author);
            return _mapper.ToDto(created);
        }
    }
}
