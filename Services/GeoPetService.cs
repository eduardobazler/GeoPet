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
            var _resp = await _client.GetAsync($"reverse?format=jsonV2&lat={latitude}&lon={longitude}");
            if(!_resp.IsSuccessStatusCode) return default!;
            var _res = await _resp.Content.ReadFromJsonAsync<object>();
            if (_res!.ToString() == "[]") return false;
            Console.WriteLine(_res);
            return _res;
        }
    }

    // https://nominatim.openstreetmap.org/ui/reverse.html?lat=-23.517506&lon=-47.443750&zoom=18
}