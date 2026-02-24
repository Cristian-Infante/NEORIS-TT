using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using NEORIS.Application.Exceptions;

namespace NEORIS.Api.Filters
{
    /// <summary>
    /// Translates known domain exceptions into the appropriate HTTP error responses,
    /// keeping controllers free of exception-handling logic.
    /// </summary>
    public class DomainExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            switch (context.Exception)
            {
                case System.ArgumentException ex:
                    context.Response = context.Request.CreateResponse(
                        HttpStatusCode.BadRequest, new { message = ex.Message });
                    break;

                case BookLimitExceededException ex:
                    context.Response = context.Request.CreateResponse(
                        HttpStatusCode.BadRequest, new { message = ex.Message });
                    break;

                case AuthorNotFoundException ex:
                    context.Response = context.Request.CreateResponse(
                        HttpStatusCode.BadRequest, new { message = ex.Message });
                    break;
            }
        }
    }
}
