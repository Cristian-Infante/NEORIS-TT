using NEORIS.Application.DTOs;

namespace NEORIS.Application.Interfaces
{
    /// <summary>
    /// Validates the required fields of a book creation request.
    /// </summary>
    public interface IBookValidator
    {
        /// <summary>
        /// Throws <see cref="System.ArgumentException"/> if any required field is missing or invalid.
        /// </summary>
        void Validate(CreateBookDto dto);
    }
}
