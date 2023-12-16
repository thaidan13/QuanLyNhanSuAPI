using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Helper;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class ThongTinGiaDinhController : Controller
    {
        private readonly HttpClient _http;

        public ThongTinGiaDinhController(HttpClient http)
        {
            _http = http;
        }

        #region Tạo biến

        public TbThongTinGiaDinh GiaDinh { get; set; } = new TbThongTinGiaDinh();

        #endregion

        #region Hiển thị danh sách

        public async Task<ActionResult<ServiceResponse<GiaDinhDTO>>> Index(int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var giadinh = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinGiaDinh>>>($"http://10.0.0.4:5259/api/ThongTinGiaDinh/nhanviengiadinh/{nhanvienId}");

            var GiaDinhModel = new GiaDinhDTO
            {
                GiaDinhs = giadinh.Data,
                NhanVien = nhanvien.Data
            };

            return View(GiaDinhModel);
        }

        #endregion

        #region Thêm gia đình

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinGiaDinh>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinGiaDinh>>> Create(TbThongTinGiaDinh giadinh)
        {
            
            var creategiadinh = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/ThongTinGiaDinh", giadinh);
            if (creategiadinh.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = giadinh.IdNv });
            }

            return RedirectToAction("ErrorAction");
        }

        #endregion

        #region Cập nhật gia đình

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinGiaDinh>>> Update(int Id)
        {
            var giadinh = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinGiaDinh>>($"http://10.0.0.4:5259/api/ThongTinGiaDinh/{Id}");

            return View(giadinh);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinGiaDinh>>> Update(TbThongTinGiaDinh thongtingiadinh)
        {
            var updategiadinh = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/ThongTinGiaDinh", thongtingiadinh);
            if (updategiadinh.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = thongtingiadinh.IdNv });
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Xoá Giadđình

        [HttpGet]
        public async Task<ActionResult> DeleteGiaDinh(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinGiaDinh>>($"http://10.0.0.4:5259/api/ThongTinGiaDinh/{Id}");
            GiaDinh = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/ThongTinGiaDinh/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = GiaDinh.IdNv });
            }
            else
            {
                return View("Error");
            }
        }

        #endregion
    }
}
