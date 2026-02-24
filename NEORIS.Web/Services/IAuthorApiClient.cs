using System.Collections.Generic;
using System.Threading.Tasks;
using NEORIS.Web.Models;

namespace NEORIS.Web.Services
{
    /// <summary>
    /// Contract for HTTP communication with the Authors endpoint of the API.
    /// </summary>
    public interface IAuthorApiClient
    {
        /// <summary>
        /// Returns all registered authors.
        /// </summary>
        Task<IEnumerable<AuthorViewModel>> GetAllAsync();

        /// <summary>
        /// Returns a single author by id, or null if not found.
        /// </summary>
        Task<AuthorViewModel> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new author via the API.
        /// </summary>
        Task<AuthorViewModel> CreateAsync(CreateAuthorViewModel model);
    }
}
