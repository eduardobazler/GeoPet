using GeoPet.Data;

namespace GeoPet.Services
{
    public class GeoPetService : IGeoPetService
    {
        private readonly HttpClient _client;
        private const string _url = "https://nominatim.openstreetmap.org/";

        public GeoPetService(HttpClient client) 
        {
            _client = client;
            _client.BaseAddress = new Uri(_url);
        }

        public async Task<object> FindGeoPet(string latitude, string longitude)
        {
            _client.DefaultRequestHeaders.Add("User-Agent", "WHATEVER VALUE");
            var _resp = await _client.GetAsync($"reverse?format=json&lat={latitude}&lon={longitude}");
            if(!_resp.IsSuccessStatusCode) return default!;
            var _res = await _resp.Content.ReadFromJsonAsync<object>();
            if (_res!.ToString() == "[]") return false;
            return _res;
        }
    }

    // https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat=-23.517506&lon=-47.443750
    // https://nominatim.openstreetmap.org/ui/reverse.html?lat=-23.517506&lon=-47.443750&zoom=18
}