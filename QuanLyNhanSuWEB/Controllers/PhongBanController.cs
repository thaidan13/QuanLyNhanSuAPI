using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.Models;
using System.Collections.Generic;
using X.PagedList;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class PhongBanController : Controller
    {
        private readonly HttpClient _http;

        public PhongBanController(HttpClient http)
        {
            _http = http;
        }

        public List<TbPhongBan> PhongBans { get; set; } = new List<TbPhongBan>();
        public List<TbThongTinNhanVien> NhanViens { get; set; } = new List<TbThongTinNhanVien>();
        public TbPhongBan PhongBan = new TbPhongBan();

        public async Task<ActionResult<ServiceResponse<List<TbPhongBan>>>> Index(string searchString, int? page)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TbPhongBan>>>("http://10.0.0.4:5259/api/PhongBan");
            PhongBans = result.Data;
            //return View(PhongBans);

            var pageNumber = page ?? 1;
            int pageSize = 10;

            IPagedList<TbPhongBan> pagedData = PhongBans.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }

        public async Task<ActionResult<ServiceResponse<TbPhongBan>>> Details(int phongbanId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbPhongBan>>($"http://10.0.0.4:5259/api/PhongBan/{phongbanId}");
            PhongBan = result.Data;
            return View(PhongBan);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbPhongBan>>> Create()
        {
            var quanly = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            NhanViens = quanly.Data;
            ViewData["NhanVienResponse"] = NhanViens;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbPhongBan>>> Create(TbPhongBan phongban)
        {
            var result = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/PhongBan", phongban);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbPhongBan>>> Update(int phongbanId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbPhongBan>>($"http://10.0.0.4:5259/api/PhongBan/{phongbanId}");
            PhongBan = result.Data;

            var quanly = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            NhanViens = quanly.Data;
            ViewData["NhanVienResponse"] = NhanViens;

            return View(PhongBan);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbPhongBan>>> Update(TbPhongBan phongban)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(phongban.IdPb.ToString()), "IdPb");
            content.Add(new StringContent(phongban.TenPhongBan.ToString()), "TenPhongBan");
            content.Add(new StringContent(phongban.QuanLy.ToString()), "QuanLy");

            var result = await _http.PutAsync("http://10.0.0.4:5259/api/PhongBan", content);
            string apiRes = await result.Content.ReadAsStringAsync();
            ViewBag.Result = "Thành Công";
            PhongBan = JsonConvert.DeserializeObject<TbPhongBan>(apiRes);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int phongbanId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbPhongBan>>($"http://10.0.0.4:5259/api/PhongBan/{phongbanId}");
            PhongBan = result.Data;
            var respon = await _http.DeleteAsync($"http://10.0.0.4:5259/api/PhongBan/{phongbanId}");
            if (respon.IsSuccessStatusCode)
            {
                // Xóa thành công, thực hiện các hành động cần thiết
                return RedirectToAction("Index"); // Chuyển hướng sau khi xóa thành công
            }
            else
            {
                // Xóa không thành công, xử lý lỗi hoặc thông báo lỗi cho người dùng
                return View("Error"); // Chuyển hướng đến trang lỗi hoặc hiển thị thông báo lỗi
            }
        }
    }
}
