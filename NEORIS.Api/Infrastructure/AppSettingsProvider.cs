using System.Configuration;
using NEORIS.Application.Interfaces;

namespace NEORIS.Api.Infrastructure
{
    /// <summary>
    /// Reads application configuration values from Web.config appSettings.
    /// </summary>
    public class AppSettingsProvider : IAppSettings
    {
        public int MaxBooksAllowed =>
            int.Parse(ConfigurationManager.AppSettings["MaxBooksAllowed"]);
    }
}
