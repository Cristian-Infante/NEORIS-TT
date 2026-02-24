using NEORIS.Web.Models;
using NEORIS.Web.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NEORIS.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorApiClient _authorApiClient;

        public AuthorsController(IAuthorApiClient authorApiClient)
        {
            _authorApiClient = authorApiClient;
        }

        /// <summary>
        /// Lists all authors.
        /// </summary>
        public async Task<ActionResult> Index()
        {
            var authors = await _authorApiClient.GetAllAsync();
            return View(authors);
        }

        /// <summary>
        /// Displays the details of a single author.
        /// </summary>
        public async Task<ActionResult> Details(int id)
        {
            var author = await _authorApiClient.GetByIdAsync(id);
            if (author == null)
                return HttpNotFound();

            return View(author);
        }

        /// <summary>
        /// Displays the create author form.
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateAuthorViewModel());
        }

        /// <summary>
        /// Handles the create author form submission.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAuthorViewModel model)
        {
            ModelState.Clear();
            try
            {
                await _authorApiClient.CreateAsync(model);
                return RedirectToAction("Index");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }
    }
}
