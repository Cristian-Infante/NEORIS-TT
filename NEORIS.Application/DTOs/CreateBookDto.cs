namespace NEORIS.Application.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
    }
}
