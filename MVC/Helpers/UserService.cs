using MVC.Models;
using System.Security.Claims;


namespace MVC.Helpers
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal GetUser()
        {
            return _httpContextAccessor.HttpContext.User;
        }

        public string GetUserName()
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public string GetUserEmail()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        }

        public IEnumerable<Claim> GetUserClaims()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }
        //kullanıcı rollerini, adını soyadını ve mail adresini döndüren metotlar yazılacak:
        
        public SessionUser GetSessionUser() {
            var user = new SessionUser();
			user.FullName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
			user.Email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
			var sicilNo = _httpContextAccessor.HttpContext.User.FindFirst("preferred_username")?.Value;
            user.SicilNo=sicilNo.Split('@')[0];
			user.Role = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "supply_qr_roles" && (c.Value == "User" || c.Value == "SupplyAdmin"))?.Value;
			return user;
		}
       
    }
}
