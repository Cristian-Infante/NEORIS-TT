using System;

namespace NEORIS.Web.Models
{
    public class CreateAuthorViewModel
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string OriginCity { get; set; }
        public string Email { get; set; }
    }
}
