using NEORIS.Web.Models;
using NEORIS.Web.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NEORIS.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookApiClient _bookApiClient;
        private readonly IAuthorApiClient _authorApiClient;

        public BooksController(IBookApiClient bookApiClient, IAuthorApiClient authorApiClient)
        {
            _bookApiClient = bookApiClient;
            _authorApiClient = authorApiClient;
        }

        /// <summary>
        /// Lists all books.
        /// </summary>
        public async Task<ActionResult> Index()
        {
            var books = await _bookApiClient.GetAllAsync();
            return View(books);
        }

        /// <summary>
        /// Displays the details of a single book.
        /// </summary>
        public async Task<ActionResult> Details(int id)
        {
            var book = await _bookApiClient.GetByIdAsync(id);
            if (book == null)
                return HttpNotFound();

            return View(book);
        }

        /// <summary>
        /// Displays the create book form.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var authors = await _authorApiClient.GetAllAsync();
            var model = new CreateBookViewModel
            {
                Authors = authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.FullName
                })
            };
            return View(model);
        }

        /// <summary>
        /// Handles the create book form submission.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookViewModel model)
        {
            ModelState.Clear();
            try
            {
                await _bookApiClient.CreateAsync(model);
                return RedirectToAction("Index");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            var authors = await _authorApiClient.GetAllAsync();
            model.Authors = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FullName
            });
            return View(model);
        }
    }
}
