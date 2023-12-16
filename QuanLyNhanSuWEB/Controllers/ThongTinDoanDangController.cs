using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class ThongTinDoanDangController : Controller
    {
        private readonly HttpClient _http;

        public ThongTinDoanDangController(HttpClient http)
        {
            _http = http;
        }

        #region Tạo Biến

        public IEnumerable<TbThongTinDoanDang> DoanDangs { get; set; } = new List<TbThongTinDoanDang>();

        public TbThongTinDoanDang DoanDang = new TbThongTinDoanDang();

        #endregion

        #region Hiển thị danh sách

        public async Task<ActionResult<ServiceResponse<TbThongTinDoanDangDTO>>> Index(int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var doandang = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinDoanDang>>($"http://10.0.0.4:5259/api/ThongTinDoanDang/{nhanvienId}");

            var DoanDangModel = new TbThongTinDoanDangDTO
            {
                DoanDang = doandang.Data,
                NhanVien = nhanvien.Data
            };

            return View(DoanDangModel);

        }

        #endregion

        #region Thêm đoàn đảng

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinDoanDang>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinDoanDang>>> Create(TbThongTinDoanDang doandang)
        {
            var createdoandang = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/ThongTinDoanDang", doandang);
            if (createdoandang.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = doandang.IdNv });
            }

            return RedirectToAction("ErrorAction");
        }

        #endregion

        #region Cập nhật đoàn đảng

        //[HttpGet]
        //public async Task<ActionResult<ServiceResponse<TbThongTinDoanDang>>> Update(int doandangId)
        //{
        //    var doandang = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinDoanDang>>($"http://10.0.0.4:5259/api/ThongTinDoanDang/{doandangId}");
        //    DoanDang = doandang.Data;
        //    return View(DoanDang);
        //}
        //[HttpPost]
        //public async Task<ActionResult<ServiceResponse<TbThongTinDoanDang>>> Update(TbThongTinDoanDang thongtindoandang)
        //{
        //    var updatedaotao = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/ThongTinDoanDang", thongtindoandang);
        //    return RedirectToAction("Index", new { nhanvienId = thongtindoandang.IdNv });
        //}

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinDoanDangDTO>>> Update(int Id)
        {
            var doandang = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinDoanDang>>($"http://10.0.0.4:5259/api/ThongTinDoanDang/{Id}");

            if (doandang != null)
            {
                DoanDang = doandang.Data;
                return View(DoanDang);
            }

            var DoanDangModel = new TbThongTinDoanDangDTO
            {
                DoanDang = doandang.Data
            };

            return View(DoanDangModel);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinDoanDangDTO>>> Update(TbThongTinDoanDangDTO thongtindoandang)
        {
            var updatedoandang = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/ThongTinDoanDang", thongtindoandang.DoanDang);
            if (updatedoandang.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = thongtindoandang.DoanDang.IdNv });
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}
