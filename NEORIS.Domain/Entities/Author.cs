using System.Collections.Generic;

namespace NEORIS.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string OriginCity { get; set; }
        public string Email { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
