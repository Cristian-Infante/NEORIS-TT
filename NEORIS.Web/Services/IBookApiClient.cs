using System.Collections.Generic;
using System.Threading.Tasks;
using NEORIS.Web.Models;

namespace NEORIS.Web.Services
{
    /// <summary>
    /// Contract for HTTP communication with the Books endpoint of the API.
    /// </summary>
    public interface IBookApiClient
    {
        /// <summary>
        /// Returns all registered books.
        /// </summary>
        Task<IEnumerable<BookViewModel>> GetAllAsync();

        /// <summary>
        /// Returns a single book by id, or null if not found.
        /// </summary>
        Task<BookViewModel> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new book via the API.
        /// </summary>
        Task<BookViewModel> CreateAsync(CreateBookViewModel model);
    }
}
