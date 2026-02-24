using System;

namespace NEORIS.Application.Exceptions
{
    /// <summary>
    /// Thrown when the maximum number of allowed books has been reached.
    /// </summary>
    public class BookLimitExceededException : Exception
    {
        public BookLimitExceededException(string message) : base(message) { }
    }
}
