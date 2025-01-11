using Application.Models.VMs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public IActionResult ChangeLang(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient("api");
            var response = await httpClient.GetAsync("Supplier/GetActiveSuppliers");
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                var suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierVM>>(apiResponse);
                return View(suppliers);
            }
            return View();
        }


        public async Task<IActionResult> UserDetay()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.ReadJwtToken(accessToken);
            var claims = token.Claims.ToList();
            ViewBag.Claims = claims;

            var idToken = await HttpContext.GetTokenAsync("id_token");
            ViewBag.AccessToken = accessToken;
            ViewBag.IdToken = idToken;
            return View();

        }


    }
}
