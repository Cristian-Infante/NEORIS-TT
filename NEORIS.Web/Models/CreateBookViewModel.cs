using System.Collections.Generic;
using System.Web.Mvc;

namespace NEORIS.Web.Models
{
    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}
