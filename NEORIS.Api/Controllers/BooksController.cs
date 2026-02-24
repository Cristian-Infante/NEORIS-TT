using System;
using System.Threading.Tasks;
using System.Web.Http;
using NEORIS.Application.DTOs;
using NEORIS.Application.Interfaces;

namespace NEORIS.Api.Controllers
{
    /// <summary>
    /// Manages book registration and retrieval.
    /// </summary>
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Returns all registered books.
        /// </summary>
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        /// <summary>
        /// Returns a book by its identifier.
        /// </summary>
        [HttpGet, Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        /// <summary>
        /// Creates a new book.
        /// </summary>
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create([FromBody] CreateBookDto dto)
        {
            var created = await _bookService.CreateAsync(dto);
            return Created(new Uri(Request.RequestUri, created.Id.ToString()), created);
        }
    }
}
