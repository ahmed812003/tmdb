using System.Text.Json.Serialization;

namespace tmdb_cl.Models.Configurations
{
    public record MovieConfiguration
    {
        [JsonPropertyName("ApiKey")]
        public string ApiKey { get; set; }

        [JsonPropertyName("Urls")]
        public MovieUrls Urls { get; set; }
    }

    public class MovieUrls
    {
        [JsonPropertyName("NowPlaying")]
        public string NowPlaying { get; set; }

        [JsonPropertyName("Popular")]
        public string Popular { get; set; }

        [JsonPropertyName("TopRated")]
        public string TopRated { get; set; }

        [JsonPropertyName("UpComming")]
        public string Upcoming { get; set; }
    }
}
