using Newtonsoft.Json.Linq;

namespace NEORIS.Web.Services
{
    /// <summary>
    /// Parses the body of an API error response to extract a user-facing message.
    /// </summary>
    public class ApiResponseParser : IApiResponseParser
    {
        public string ExtractMessage(string responseBody)
        {
            if (string.IsNullOrWhiteSpace(responseBody))
                return "Error al procesar la solicitud.";

            try
            {
                var obj = JObject.Parse(responseBody);

                var msg = obj["message"]?.ToString() ?? obj["Message"]?.ToString();
                if (!string.IsNullOrWhiteSpace(msg))
                    return msg;

                var modelState = obj["modelState"] ?? obj["ModelState"];
                if (modelState != null)
                {
                    foreach (var prop in modelState.Children<JProperty>())
                    {
                        var first = prop.Value.First?.ToString();
                        if (!string.IsNullOrWhiteSpace(first))
                            return first;
                    }
                }

                return responseBody;
            }
            catch
            {
                return responseBody.Trim('"');
            }
        }
    }
}
