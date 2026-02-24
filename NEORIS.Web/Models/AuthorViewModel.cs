using System;

namespace NEORIS.Web.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string OriginCity { get; set; }
        public string Email { get; set; }
    }
}
