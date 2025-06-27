using tmdb_cl.Models.Configurations;
using tmdb_cl.Services.Interfaces;
using tmdb_cl.Services.Services;

namespace tmdb_app
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                ConfigurationHelper configurationHelper = ConfigurationHelper.Instance;
                MovieConfiguration configuration = configurationHelper.LoadConfigurationFile();

                IServiceStrategyManager serviceStrategyManager = new ServiceStrategyManager();

                string apiType = Console.ReadLine();
                switch (apiType)
                {
                    case "playing":
                        await serviceStrategyManager.InvokeStrategy(new NowPlayingServiceStrategy(), configuration.ApiKey, configuration.Urls.NowPlaying);
                        break;
                    case "popular":
                        await serviceStrategyManager.InvokeStrategy(new PopularServiceStrategy(), configuration.ApiKey, configuration.Urls.Popular);
                        break;
                    case "top":
                        await serviceStrategyManager.InvokeStrategy(new PopularServiceStrategy(), configuration.ApiKey, configuration.Urls.TopRated);
                        break;
                    case "upcoming":
                        await serviceStrategyManager.InvokeStrategy(new PopularServiceStrategy(), configuration.ApiKey, configuration.Urls.Upcoming);
                        break;
                    default:
                        Console.WriteLine("wrong");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
            
        }
    }
}
