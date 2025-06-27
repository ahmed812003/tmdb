namespace tmdb_cl.Services.Interfaces
{
    public interface IServiceStrategyManager
    {
        Task InvokeStrategy(IServiceStrategy serviceStrategy, string apiKey, string apiUrl);
    }
}
