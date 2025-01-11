
using System.IdentityModel.Claims;
using System.Text;

namespace MVC.Models
{
    public class CustomHttpClientHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomHttpClientHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null && httpContext.User.Identity.IsAuthenticated)
            {
                var userName = httpContext.User.FindFirst(ClaimTypes.Name)?.Value;
                var mail = httpContext.User.FindFirst(ClaimTypes.Email)?.Value;
                var sicilNo = httpContext.User.FindFirst("preferred_username")?.Value;
                sicilNo = sicilNo?.Split('@')[0];
                var role = httpContext.User.Claims.FirstOrDefault(c => c.Type == "supply_qr_roles" && (c.Value == "User" || c.Value == "SupplyAdmin"))?.Value;

                // Ensure headers contain only ASCII characters
                request.Headers.Add("fullname", EncodeToAscii(userName));
                request.Headers.Add("mail", EncodeToAscii(mail));
                request.Headers.Add("sicilno", EncodeToAscii(sicilNo));
                request.Headers.Add("role", EncodeToAscii(role));
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private string EncodeToAscii(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var asciiBytes = Encoding.ASCII.GetBytes(value);
            return Encoding.ASCII.GetString(asciiBytes);
        }
    }
}
