namespace GeoPet.Services
{
    public interface IGeoPetService
    {
        Task<object> FindGeoPet(string latitude, string longitude);
    }
}