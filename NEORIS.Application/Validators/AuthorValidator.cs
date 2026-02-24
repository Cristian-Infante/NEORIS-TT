using System;
using NEORIS.Application.DTOs;
using NEORIS.Application.Interfaces;

namespace NEORIS.Application.Validators
{
    /// <summary>
    /// Validates required fields for author creation.
    /// </summary>
    public class AuthorValidator : IAuthorValidator
    {
        public void Validate(CreateAuthorDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("El nombre completo es obligatorio.");

            if (dto.BirthDate == default)
                throw new ArgumentException("La fecha de nacimiento es obligatoria.");

            if (string.IsNullOrWhiteSpace(dto.OriginCity))
                throw new ArgumentException("La ciudad de procedencia es obligatoria.");

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentException("El correo electr\u00f3nico es obligatorio.");
        }
    }
}
