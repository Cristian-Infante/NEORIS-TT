using System;
using NEORIS.Application.DTOs;
using NEORIS.Application.Interfaces;

namespace NEORIS.Application.Validators
{
    /// <summary>
    /// Validates required fields for book creation.
    /// </summary>
    public class BookValidator : IBookValidator
    {
        public void Validate(CreateBookDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ArgumentException("El t\u00edtulo es obligatorio.");

            if (string.IsNullOrWhiteSpace(dto.Genre))
                throw new ArgumentException("El g\u00e9nero es obligatorio.");

            if (dto.Year <= 0)
                throw new ArgumentException("El a\u00f1o es obligatorio.");

            if (dto.PageCount <= 0)
                throw new ArgumentException("El n\u00famero de p\u00e1ginas es obligatorio.");

            if (dto.AuthorId <= 0)
                throw new ArgumentException("El autor es obligatorio.");
        }
    }
}
