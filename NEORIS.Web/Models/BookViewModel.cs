namespace NEORIS.Web.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public string AuthorFullName { get; set; }
    }
}
