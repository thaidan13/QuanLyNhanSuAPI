using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Helper;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class LichSuBanThanNhanVienController : Controller
    {
        private readonly HttpClient _http;

        public LichSuBanThanNhanVienController(HttpClient http)
        {
            _http = http;
        }

        #region Tạo biến

        public TbLichSuBanThanNhanVien LichSuNhanVien { get; set; } = new TbLichSuBanThanNhanVien();

        #endregion

        #region Hiển thị danh sách

        public async Task<ActionResult<ServiceResponse<LichSuBanThanNhanVienDTO>>> Index(int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var lichsu = await _http.GetFromJsonAsync<ServiceResponse<List<TbLichSuBanThanNhanVien>>>($"http://10.0.0.4:5259/api/LichSuBanThanNhanVien/lichsunhanvien/{nhanvienId}");

            var LichSuModel = new LichSuBanThanNhanVienDTO
            {
                LichSuNhanViens = lichsu.Data,
                NhanVien = nhanvien.Data
            };

            return View(LichSuModel);
        }

        #endregion

        #region Thêm lịch sử

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<LichSuBanThanNhanVienDTO>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<LichSuBanThanNhanVienDTO>>> Create(LichSuBanThanNhanVienDTO lichsu)
        {
            
            var createlichsu = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/LichSuBanThanNhanVien", lichsu.LichSuNhanVien);
            if (createlichsu.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = lichsu.LichSuNhanVien.IdNv });
            }

            return RedirectToAction("ErrorAction");
        }

        #endregion

        #region Cập nhật lịch sử

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbLichSuBanThanNhanVien>>> Update(int Id)
        {
            var lichsu = await _http.GetFromJsonAsync<ServiceResponse<TbLichSuBanThanNhanVien>>($"http://10.0.0.4:5259/api/LichSuBanThanNhanVien/{Id}");
            LichSuNhanVien = lichsu.Data;
            return View(LichSuNhanVien);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbLichSuBanThanNhanVien>>> Update(TbLichSuBanThanNhanVien lichsu)
        {
            var updatelichsu = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/LichSuBanThanNhanVien", lichsu);
            return RedirectToAction("Index", new { nhanvienId = lichsu.IdNv });
        }

        #endregion

        #region Xoá lịch sử

        [HttpGet]
        public async Task<ActionResult> DeleteLichSu(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbLichSuBanThanNhanVien>>($"http://10.0.0.4:5259/api/LichSuBanThanNhanVien/{Id}");
            LichSuNhanVien = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/LichSuBanThanNhanVien/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = LichSuNhanVien.IdNv });
            }
            else
            {
                return View("Error");
            }
        }

        #endregion
    }
}
