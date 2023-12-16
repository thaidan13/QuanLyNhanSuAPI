using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuanLyNhanSuWEB.Models
{
    public class NhanVienAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isNhanVienLoggedIn = context.HttpContext.Session.GetString("IsNhanVienLoggedIn");

            if (string.IsNullOrEmpty(isNhanVienLoggedIn) || isNhanVienLoggedIn != "true")
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
