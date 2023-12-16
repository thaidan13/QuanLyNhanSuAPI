using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class DiNuocNgoaiController : Controller
    {
        private readonly HttpClient _http;

        public DiNuocNgoaiController(HttpClient http)
        {
            _http = http;
        }

        #region Tạo biến

        public TbDiNuocNgoai NuocNgoai { get; set; }

        #endregion

        #region Hiện thị danh sách

        public async Task<ActionResult<ServiceResponse<DiNuocNgoaiDTO>>> Index(int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var nuocngoai = await _http.GetFromJsonAsync<ServiceResponse<List<TbDiNuocNgoai>>>($"http://10.0.0.4:5259/api/DiNuocNgoai/nhanviennuocngoai/{nhanvienId}");

            var NuocNgoaiModel = new DiNuocNgoaiDTO
            {
                NuocNgoais = nuocngoai.Data,
                NhanVien = nhanvien.Data
            };

            return View(NuocNgoaiModel);

        }

        #endregion

        #region Thêm Nước Ngoài

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbDiNuocNgoai>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbDiNuocNgoai>>> Create(TbDiNuocNgoai nuocngoai)
        {
            var createnuocngoai = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/DiNuocNgoai", nuocngoai);
            if (createnuocngoai.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = nuocngoai.IdNv });
            }

            return RedirectToAction("ErrorAction");
        }

        #endregion

        #region Cập nhật nước ngoài

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbDiNuocNgoai>>> Update(int Id)
        {
            var nuocngoai = await _http.GetFromJsonAsync<ServiceResponse<TbDiNuocNgoai>>($"http://10.0.0.4:5259/api/DiNuocNgoai/{Id}");

            return View(nuocngoai);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbDiNuocNgoai>>> Update(TbDiNuocNgoai thongtinnuocngoai)
        {
            var updatenuocngoai = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/DiNuocNgoai", thongtinnuocngoai);
            if (updatenuocngoai.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = thongtinnuocngoai.IdNv });
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Xoá nước ngoài

        [HttpGet]
        public async Task<ActionResult> DeleteNuocNgoai(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbDiNuocNgoai>>($"http://10.0.0.4:5259/api/DiNuocNgoai/{Id}");
            NuocNgoai = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/DiNuocNgoai/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = NuocNgoai.IdNv });
            }
            else
            {
                return View("Error");
            }
        }

        #endregion
    }
}
