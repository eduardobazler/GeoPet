using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Services
{
    public interface IGeoPetService
    {
        Task<Object> FindGeoPet(string latitude, string longitude);
    }
}