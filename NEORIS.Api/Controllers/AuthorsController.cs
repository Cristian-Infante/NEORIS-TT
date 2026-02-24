using System;
using System.Threading.Tasks;
using System.Web.Http;
using NEORIS.Application.DTOs;
using NEORIS.Application.Interfaces;


namespace NEORIS.Api.Controllers
{
    /// <summary>
    /// Manages author registration and retrieval.
    /// </summary>
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Returns all registered authors.
        /// </summary>
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAsync();
            return Ok(authors);
        }

        /// <summary>
        /// Returns an author by its identifier.
        /// </summary>
        [HttpGet, Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null)
                return NotFound();
            return Ok(author);
        }

        /// <summary>
        /// Creates a new author.
        /// </summary>
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create([FromBody] CreateAuthorDto dto)
        {
            var created = await _authorService.CreateAsync(dto);
            return Created(new Uri(Request.RequestUri, created.Id.ToString()), created);
        }
    }
}
