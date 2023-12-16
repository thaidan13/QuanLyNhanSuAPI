using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class DaoTaoMoiController : Controller
    {
        private readonly HttpClient _http;

        public DaoTaoMoiController(HttpClient http)
        {
            _http = http;
        }

        #region Tạo biến

        public TbQuaTrinhDaoTaoCuMoi DaoTao = new TbQuaTrinhDaoTaoCuMoi();

        #endregion

        #region Hiển thị danh sách

        public async Task<ActionResult<ServiceResponse<DaoTaoCuMoiDTO>>> Index(int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var daotao = await _http.GetFromJsonAsync<ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>>($"http://10.0.0.4:5259/api/QuaTrinhDaoTaoCuMoi/daotaomoi/{nhanvienId}");

            var DaoTaoModel = new DaoTaoCuMoiDTO
            {
                DaoTaos = daotao.Data,
                NhanVien = nhanvien.Data
            };

            return View(DaoTaoModel);

        }

        #endregion

        #region Thêm đào tạo

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>> Create(TbQuaTrinhDaoTaoCuMoi daotao)
        {
            var createdaotao = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/QuaTrinhDaoTaoCuMoi", daotao);
            if (createdaotao.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = daotao.IdNv });
            }

            return RedirectToAction("ErrorAction");
        }

        #endregion

        #region Cập nhật đào tạo

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>> Update(int Id)
        {
            var daotao = await _http.GetFromJsonAsync<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>($"http://10.0.0.4:5259/api/QuaTrinhDaoTaoCuMoi/{Id}");

            return View(daotao);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>> Update(TbQuaTrinhDaoTaoCuMoi thongtindaotao)
        {
            var updatedaotao = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/QuaTrinhDaoTaoCuMoi", thongtindaotao);
            if (updatedaotao.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = thongtindaotao.IdNv });
            }

            return RedirectToAction("Index");
        }


        #endregion

        #region Xoá đào tạo

        [HttpGet]
        public async Task<ActionResult> DeleteDaoTao(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>($"http://10.0.0.4:5259/api/QuaTrinhDaoTaoCuMoi/{Id}");
            DaoTao = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/QuaTrinhDaoTaoCuMoi/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = DaoTao.IdNv });
            }
            else
            {
                return View("Error");
            }
        }

        #endregion

    }
}
