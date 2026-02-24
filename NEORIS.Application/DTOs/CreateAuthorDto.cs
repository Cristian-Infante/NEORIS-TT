using System;

namespace NEORIS.Application.DTOs
{
    public class CreateAuthorDto
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string OriginCity { get; set; }
        public string Email { get; set; }
    }
}
