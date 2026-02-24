namespace NEORIS.Application.Interfaces
{
    /// <summary>
    /// Provides access to application-level configuration values.
    /// </summary>
    public interface IAppSettings
    {
        int MaxBooksAllowed { get; }
    }
}
