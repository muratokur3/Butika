using Application.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public OrderController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 10;
            var httpClient = _httpClientFactory.CreateClient("api");
            var response = await httpClient.GetAsync("Order/GetAllOrders");
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<IEnumerable<OrderVM>>(apiResponse);

                var paginatedOrders = orders.Reverse().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                ViewBag.PageNumber = pageNumber;
                ViewBag.TotalPages = (int)Math.Ceiling((double)orders.Count() / pageSize);

                return View(paginatedOrders);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Order bilgilerine erişilemedi.");
                return View("Error");
            }
        }
    }
}
