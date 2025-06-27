namespace tmdb_cl.Services.Interfaces
{
    public interface IServiceStrategy
    {
        Task CallApi(string apiKey, string apiUrl);
    }
}
