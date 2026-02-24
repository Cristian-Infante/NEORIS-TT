using System;

namespace NEORIS.Application.Exceptions
{
    /// <summary>
    /// Thrown when a referenced author does not exist.
    /// </summary>
    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException(string message) : base(message) { }
    }
}
