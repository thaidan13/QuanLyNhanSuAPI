using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuanLyNhanSuWEB.Models
{
    public class AdminAuthorizationFilter: IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAdminLoggedIn = context.HttpContext.Session.GetString("IsAdminLoggedIn");

            if (string.IsNullOrEmpty(isAdminLoggedIn) || isAdminLoggedIn != "true")
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
