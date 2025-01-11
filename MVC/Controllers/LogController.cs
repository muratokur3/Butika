using Application.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace MVC.Controllers
{
    [Authorize(Roles = "SupplyAdmin")]
    public class LogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LogController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient("api");
            var response = await httpClient.GetAsync("Log/GetLog");
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                var logs = JsonConvert.DeserializeObject<IEnumerable<LogTableVM>>(apiResponse);
                return View(logs.Reverse());
            }
            return View();
        }
    }
}
