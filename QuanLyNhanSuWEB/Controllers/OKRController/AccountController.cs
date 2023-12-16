using QuanLyNhanSuWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using X.PagedList;

namespace QuanLyNhanSuWEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _http;

        public AccountController(HttpClient http)
        {
            _http = http;
        }

        public List<TbTaiKhoan> TaiKhoans { get; set; } = new List<TbTaiKhoan>();
        public List<TbThongTinNhanVien> NhanViens { get; set; } = new List<TbThongTinNhanVien>();

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbTaiKhoan>>>> Index(string searchString, int? page)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TbTaiKhoan>>>("http://10.0.0.4:5259/api/Auth");
            TaiKhoans = result.Data;
            //return View(TaiKhoans);
            if (!string.IsNullOrEmpty(searchString))
            {
                TaiKhoans = TaiKhoans.Where(n => n.Email.Contains(searchString) || n.Role.Contains(searchString)).ToList();
            }
            var pageNumber = page ?? 1;
            int pageSize = 10;

            ViewBag.SearchString = searchString;
            ViewBag.PageNumber = pageNumber;
            IPagedList<TbTaiKhoan> pagedData = TaiKhoans.ToPagedList(pageNumber, pageSize);
            return View(pagedData);

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<LoginTaiKhoan>>> Login(LoginTaiKhoan login)
        {
            var admin = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/Auth/login", login);
            if (admin.IsSuccessStatusCode)
            {
                var responseContent = await admin.Content.ReadAsStringAsync();
                //var role = JsonConvert.DeserializeObject<string>(responseContent);
                HttpContext.Session.SetString("Role", responseContent);

                if (responseContent == "Admin")
                {
                    // Xử lý khi đăng nhập với vai trò Admin
                    // Đăng nhập thành công
                    HttpContext.Session.SetString("IsAdminLoggedIn", "true");
                    HttpContext.Session.SetString("Email", login.Email);
                    return RedirectToAction("Index", "Home");
                }
                else if(responseContent == "NhanVien")
                {
                    // Xử lý khi đăng nhập không có quyền Admin
                    HttpContext.Session.SetString("IsNhanVienLoggedIn", "true");
                    HttpContext.Session.SetString("Email", login.Email);
                    return RedirectToAction("IndexNhanVien", "Home");
                    //return RedirectToAction("Details", "ThongTinNhanVien");
                }
            }
           
            // Xử lý trường hợp không thành công (ví dụ: hiển thị thông báo lỗi)
            ModelState.AddModelError(string.Empty, "Đăng nhập không thành công.");
            return View(login);
            
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<RegisterTaiKhoan>>> Register()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            NhanViens = result.Data;
            ViewData["NhanVienResponse"] = NhanViens;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterTaiKhoan registerTaiKhoan)
        {
            var result = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/Auth/register", registerTaiKhoan);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<bool>>> DoiMatKhau()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> DoiMatKhau(DoiMatKhau doiMatKhau)
        {
            string email = HttpContext.Session.GetString("Email");
            //ViewData["Email"] = email;
            doiMatKhau.Email = email;
            var result = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/Auth/change-password", doiMatKhau);
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Logout()
        {
            //HttpContext.Session.Remove("IsAdminLoggedIn");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");

        }
    }
}
