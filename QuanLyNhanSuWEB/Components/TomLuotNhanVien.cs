using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.Models;
using static System.Net.WebRequestMethods;

namespace QuanLyNhanSuWEB.Components
{
    public class TomLuotNhanVien : ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
           return View();
        }
    }
}
