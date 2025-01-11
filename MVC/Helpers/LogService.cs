
namespace MVC.Helpers
{
    public class LogService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LogService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task LoginAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("api");
            var response = await httpClient.GetAsync("Log/LoginLog");
        }
        public async Task LogoutAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("api");
            var response = await httpClient.GetAsync("Log/LogoutLog");

        }
    }
}
