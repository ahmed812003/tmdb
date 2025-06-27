using System.Reflection;
using System.Text.Json;

namespace tmdb_cl.Models.Configurations
{
    public class ConfigurationHelper
    {
        private static readonly Lazy<ConfigurationHelper> configurationHelper = new Lazy<ConfigurationHelper>(() => new ConfigurationHelper());
        private ConfigurationHelper() { }

        public static ConfigurationHelper Instance
        {
            get { return configurationHelper.Value; }
        }
        public MovieConfiguration LoadConfigurationFile()
        {
            try
            {
                string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string projectOutputDirectory = Path.GetFullPath(Path.Combine(assemblyDirectory, @"..\..\..\..\tmdb-cl"));
                string configurationFilePath = Path.Combine(projectOutputDirectory, "Configuration.json");
                if (!File.Exists(configurationFilePath))
                {
                    throw new FileNotFoundException($"Configuration file not found at: {configurationFilePath}");
                }
                string configurationJsonData = File.ReadAllText(configurationFilePath);
                if (string.IsNullOrEmpty(configurationJsonData))
                {
                    throw new FileNotFoundException();
                }
                else
                {
                    MovieConfiguration movieConfiguration = JsonSerializer.Deserialize<MovieConfiguration>(configurationJsonData);
                    return movieConfiguration;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the configuration file: {ex.Message}");
                throw;
            }
        }

    }
}
