using NEORIS.Application.DTOs;

namespace NEORIS.Application.Interfaces
{
    /// <summary>
    /// Validates the required fields of an author creation request.
    /// </summary>
    public interface IAuthorValidator
    {
        /// <summary>
        /// Throws <see cref="System.ArgumentException"/> if any required field is missing or invalid.
        /// </summary>
        void Validate(CreateAuthorDto dto);
    }
}
