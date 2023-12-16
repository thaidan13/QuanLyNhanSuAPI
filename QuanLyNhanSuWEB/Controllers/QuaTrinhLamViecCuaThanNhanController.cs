using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Helper;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class QuaTrinhLamViecCuaThanNhanController : Controller
    {
        private readonly HttpClient _http;

        public QuaTrinhLamViecCuaThanNhanController(HttpClient http)
        {
            _http = http;
        }

        #region Tạo biến

        public TbQuaTrinhLamViecCuaThanNhan LamViec { get; set; } = new TbQuaTrinhLamViecCuaThanNhan();
        public TbThongTinNhanVien NhanVien { get; set; } = new TbThongTinNhanVien();

        #endregion

        #region Hiển thị danh sách

        public async Task<ActionResult<ServiceResponse<QuaTrinhLamViecCuaThanNhanDTO>>> Index(int nhanvienId, int Id)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var giadinh = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinGiaDinh>>($"http://10.0.0.4:5259/api/ThongTinGiaDinh/{Id}");

            var lamviec = await _http.GetFromJsonAsync<ServiceResponse<List<TbQuaTrinhLamViecCuaThanNhan>>>($"http://10.0.0.4:5259/api/QuaTrinhLamViecCuaThanNhan/thannhanlamviec/{Id}");

            var LamViecModel = new QuaTrinhLamViecCuaThanNhanDTO
            {
                LamViecs = lamviec.Data,
                GiaDinh = giadinh.Data,
                NhanVien = nhanvien.Data
            };

            return View(LamViecModel);
        }

        #endregion

        #region Thêm việc làm

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>>> Create(TbQuaTrinhLamViecCuaThanNhan lamviec, TbThongTinNhanVien nhanvien)
        {

            var createlamviec = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/QuaTrinhLamViecCuaThanNhan", lamviec);
            if (createlamviec.IsSuccessStatusCode)
            {
                int IdThanNhan = (int)lamviec.IdThanNhan;
                int nhanvienId = nhanvien.IdNv;

                var url = $"/QuaTrinhLamViecCuaThanNhan/Index/{IdThanNhan}?nhanvienId={nhanvienId}";
                return Redirect(url);
            }

            return RedirectToAction("ErrorAction");
        }

        #endregion

        #region Cập nhập việc làm

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>>> Update(int Id)
        {
            var lamviec = await _http.GetFromJsonAsync<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>>($"http://10.0.0.4:5259/api/QuaTrinhLamViecCuaThanNhan/{Id}");

            return View(lamviec);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>>> Update(TbQuaTrinhLamViecCuaThanNhan thongtinlamviec, TbThongTinNhanVien nhanvien)
        {
            var updatelamviec = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/QuaTrinhLamViecCuaThanNhan", thongtinlamviec);
            if (updatelamviec.IsSuccessStatusCode)
            {
                int IdThanNhan = (int)thongtinlamviec.IdThanNhan;
                int nhanvienId = nhanvien.IdNv;

                var url = $"/QuaTrinhLamViecCuaThanNhan/Index/{IdThanNhan}?nhanvienId={nhanvienId}";
                return Redirect(url);
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Xoá việc làm

        [HttpGet]
        public async Task<ActionResult> DeleteLamViec(int Id, int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var result = await _http.GetFromJsonAsync<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>>($"http://10.0.0.4:5259/api/QuaTrinhLamViecCuaThanNhan/{Id}");
            LamViec = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/QuaTrinhLamViecCuaThanNhan/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                int IdThanNhan = (int)LamViec.IdThanNhan;
                

                var url = $"/QuaTrinhLamViecCuaThanNhan/Index/{IdThanNhan}?nhanvienId={nhanvien.Data.IdNv}";
                return Redirect(url);
            }
            else
            {
                return View("Error");
            }
        }

        #endregion
    }
}
