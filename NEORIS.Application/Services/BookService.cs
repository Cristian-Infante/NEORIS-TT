using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NEORIS.Application.DTOs;
using NEORIS.Application.Exceptions;
using NEORIS.Application.Interfaces;
using NEORIS.Domain.Entities;
using NEORIS.Domain.Interfaces;

namespace NEORIS.Application.Services
{
    /// <summary>
    /// Implements book use cases: retrieval and creation with business rule enforcement.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IAppSettings _appSettings;
        private readonly IBookValidator _validator;
        private readonly IBookMapper _mapper;

        public BookService(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IAppSettings appSettings,
            IBookValidator validator,
            IBookMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _appSettings = appSettings;
            _validator = validator;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all books with their author information.
        /// </summary>
        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(_mapper.ToDto);
        }

        /// <summary>
        /// Returns a book by its identifier, or null if not found.
        /// </summary>
        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return book == null ? null : _mapper.ToDto(book);
        }

        /// <summary>
        /// Creates a new book after validating fields and enforcing business rules.
        /// </summary>
        public async Task<BookDto> CreateAsync(CreateBookDto dto)
        {
            _validator.Validate(dto);

            var count = await _bookRepository.CountAsync();
            if (count >= _appSettings.MaxBooksAllowed)
                throw new BookLimitExceededException(
                    "No es posible registrar el libro, se alcanz\u00f3 el m\u00e1ximo permitido.");

            var authorExists = await _authorRepository.ExistsAsync(dto.AuthorId);
            if (!authorExists)
                throw new AuthorNotFoundException("El autor no est\u00e1 registrado");

            var book = new Book
            {
                Title = dto.Title,
                Year = dto.Year,
                Genre = dto.Genre,
                PageCount = dto.PageCount,
                AuthorId = dto.AuthorId
            };

            var created = await _bookRepository.CreateAsync(book);
            var author = await _authorRepository.GetByIdAsync(created.AuthorId);
            created.Author = author;

            return _mapper.ToDto(created);
        }
    }
}
