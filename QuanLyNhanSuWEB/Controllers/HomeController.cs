using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using QuanLyNhanSuWEB.Models;
using System.Diagnostics;

namespace QuanLyNhanSuWEB.Controllers
{
    
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [TypeFilter(typeof(AdminAuthorizationFilter))]
        public IActionResult Index()
        {
            //var email = HttpContext.Session.GetString("");
            var email = HttpContext.Session.GetString("Email");
            var Role = HttpContext.Session.GetString("Role");

            ViewData["Email"] = email;
            
            ViewData["Role"] = Role;

            return View();
        }

        [TypeFilter(typeof(NhanVienAuthorizationFilter))]
        public IActionResult IndexNhanVien()
        {
            //var email = HttpContext.Session.GetString("");
            var email = HttpContext.Session.GetString("Email");
            var Role = HttpContext.Session.GetString("Role");

            ViewData["Email"] = email;

            ViewData["Role"] = Role;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}