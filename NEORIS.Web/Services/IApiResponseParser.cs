namespace NEORIS.Web.Services
{
    /// <summary>
    /// Extracts a human-readable error message from an API error response body.
    /// </summary>
    public interface IApiResponseParser
    {
        string ExtractMessage(string responseBody);
    }
}
