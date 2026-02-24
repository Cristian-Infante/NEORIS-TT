using System;

namespace NEORIS.Web.Services
{
    /// <summary>
    /// Represents an error response received from the API.
    /// </summary>
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }
    }
}
