using tmdb_cl.Services.Interfaces;

namespace tmdb_cl.Services.Services
{
    public class ServiceStrategyManager : IServiceStrategyManager
    {
        public async Task InvokeStrategy(IServiceStrategy serviceStrategy, string apiKey, string apiUrl)
        {
            await serviceStrategy.CallApi(apiKey, apiUrl);
        }
    }
}
