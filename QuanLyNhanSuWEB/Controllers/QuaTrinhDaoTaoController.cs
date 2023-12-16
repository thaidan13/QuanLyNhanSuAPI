using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Models;
using System.Reflection;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class QuaTrinhDaoTaoController : Controller
    {
        private readonly HttpClient _http;

        public QuaTrinhDaoTaoController(HttpClient http)
        {
            _http = http;
        }

        #region Tạo Biến 
        public IEnumerable<TbQuaTrinhDaoTao> DaoTaos { get; set; } = new List<TbQuaTrinhDaoTao>();
        public TbQuaTrinhDaoTao DaoTao = new TbQuaTrinhDaoTao();
        public TbThongTinNgoaiNgu NgoaiNgu = new TbThongTinNgoaiNgu();
        public TbThongTinViTinh ViTinh = new TbThongTinViTinh();
        public TbThongTinChinhTri ChinhTri = new TbThongTinChinhTri();
        #endregion

        #region Hiển thị danh sách       
        public async Task<ActionResult<ServiceResponse<QuaTrinhDaoTaoDTO>>> Index(int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");
            
            var daotao = await _http.GetFromJsonAsync<ServiceResponse<List<TbQuaTrinhDaoTao>>>($"http://10.0.0.4:5259/api/QuaTrinhDaoTao/nhanviendaotao/{nhanvienId}");
            var ngoaingu = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNgoaiNgu>>>($"http://10.0.0.4:5259/api/ThongTinNgoaiNgu/nhanvienngoaingu/{nhanvienId}");
            var vitinh = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinViTinh>>>($"http://10.0.0.4:5259/api/ThongTinViTinh/vitinhnhanvien/{nhanvienId}");
            var chinhtri = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinChinhTri>>>($"http://10.0.0.4:5259/api/ThongTinChinhTri/nhanvienchinhtri/{nhanvienId}");

            var QuaTrinhDaoTaoModel = new QuaTrinhDaoTaoDTO
            {
                QuaTrinhDaoTaos = daotao.Data,
                NgoaiNgus = ngoaingu.Data,
                ViTinhs = vitinh.Data,
                ChinhTris = chinhtri.Data,
                NhanVien = nhanvien.Data
            };

            return View(QuaTrinhDaoTaoModel);
        }
        #endregion

        #region Thêm mới
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<QuaTrinhDaoTaoDTO>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<QuaTrinhDaoTaoDTO>>> Create(QuaTrinhDaoTaoDTO daotao)
        {
            var createdaotao = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/QuaTrinhDaoTao", daotao.QuaTrinhDaoTao);
            if (createdaotao.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = daotao.QuaTrinhDaoTao.IdNv });
            }
            
            var createngoaingu = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/ThongTinNgoaiNgu", daotao.NgoaiNgu);
            if (createngoaingu.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = daotao.NgoaiNgu.IdNv });
            }

            var createvitinh = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/ThongTinViTinh", daotao.ViTinh);
            if (createvitinh.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = daotao.ViTinh.IdNv });
            }

            var createchinhtri = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/ThongTinChinhTri", daotao.ChinhTri);
            if (createchinhtri.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = daotao.ChinhTri.IdNv });
            }

            return RedirectToAction("ErrorAction");

        }
        #endregion

        #region Cập Nhật Cũ
        //[HttpGet]
        //public async Task<ActionResult<ServiceResponse<QuaTrinhDaoTaoDTO>>> Update(int Id)
        //{
        //    var daotao = await _http.GetFromJsonAsync<ServiceResponse<TbQuaTrinhDaoTao>>($"http://10.0.0.4:5259/api/QuaTrinhDaoTao/{Id}");

        //    if (daotao != null)
        //    {
        //        DaoTao = daotao.Data;
        //        return View(DaoTao);
        //    }

        //    var QuaTrinhDaoTaoModel = new QuaTrinhDaoTaoDTO
        //    {
        //        QuaTrinhDaoTao = daotao.Data
        //    };

        //    return View();

        //}

        //[HttpPost]
        //public async Task<ActionResult<ServiceResponse<QuaTrinhDaoTaoDTO>>> Update(QuaTrinhDaoTaoDTO daotao)
        //{
        //    var updatedaotao = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/QuaTrinhDaoTao", daotao.QuaTrinhDaoTao);
        //    if (updatedaotao.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", new { nhanvienId = daotao.QuaTrinhDaoTao.IdNv });
        //    }

        //    return RedirectToAction("Index");
        //}
        #endregion

        #region Cập nhật Đào Tạo
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTao>>> Update(int daotaoId)
        {
            var daotao = await _http.GetFromJsonAsync<ServiceResponse<TbQuaTrinhDaoTao>>($"http://10.0.0.4:5259/api/QuaTrinhDaoTao/{daotaoId}");
            DaoTao = daotao.Data;
            return View(DaoTao);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTao>>> Update(TbQuaTrinhDaoTao daotao)
        {
            var updatedaotao = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/QuaTrinhDaoTao", daotao);
            return RedirectToAction("Index", new { nhanvienId = daotao.IdNv });
        }
        #endregion

        #region Cập nhật ngoại ngữ

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinNgoaiNgu>>> UpdateNgoaiNgu(int ngoainguId)
        {
            var ngoaingu = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNgoaiNgu>>($"http://10.0.0.4:5259/api/ThongTinNgoaiNgu/{ngoainguId}");
            NgoaiNgu = ngoaingu.Data;
            return View(NgoaiNgu);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinNgoaiNgu>>> UpdateNgoaiNgu(TbThongTinNgoaiNgu thongtin)
        {

            var updatengoaingu = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/ThongTinNgoaiNgu", thongtin);
            return RedirectToAction("Index", new { nhanvienId = thongtin.IdNv });

        }


        #endregion

        #region Cập nhật Vi Tính

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinViTinh>>> UpdateViTinh(int vitinhId)
        {
            var vitinh = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinViTinh>>($"http://10.0.0.4:5259/api/ThongTinViTinh/{vitinhId}");
            ViTinh = vitinh.Data;
            return View(ViTinh);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinViTinh>>> UpdateViTinh(TbThongTinViTinh thongtinvitinh)
        {
            var updatevitinh = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/ThongTinViTinh", thongtinvitinh);
            return RedirectToAction("Index", new { nhanvienId = thongtinvitinh.IdNv });
        }

        #endregion

        #region Cập nhật chính trị

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinChinhTri>>> UpdateChinhTri(int chinhtriId)
        {
            var chinhtri = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinChinhTri>>($"http://10.0.0.4:5259/api/ThongTinChinhTri/{chinhtriId}");
            ChinhTri = chinhtri.Data;
            return View(chinhtri);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinChinhTri>>> UpdateChinhTri(TbThongTinChinhTri thongtinchinhtri)
        {
            var updatechinhtri = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/ThongTinChinhTri", thongtinchinhtri);
            return RedirectToAction("Index", new { nhanvienId = thongtinchinhtri.IdNv });
        }

        #endregion

        #region Xoá đào tạo

        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbQuaTrinhDaoTao>>($"http://10.0.0.4:5259/api/QuaTrinhDaoTao/{Id}");
            DaoTao = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/QuaTrinhDaoTao/{Id}");
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

        #region Xoá ngoại ngữ
        [HttpGet]
        public async Task<ActionResult> DeleteNgoaiNgu(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNgoaiNgu>>($"http://10.0.0.4:5259/api/ThongTinNgoaiNgu/{Id}");
            NgoaiNgu = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/ThongTinNgoaiNgu/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = NgoaiNgu.IdNv });
            }
            else
            {
                return View("Error");
            }

        }
        #endregion

        #region Xoá vi tính

        [HttpGet]
        public async Task<ActionResult> DeleteViTinh(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinViTinh>>($"http://10.0.0.4:5259/api/ThongTinViTinh/{Id}");
            ViTinh = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/ThongTinViTinh/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = ViTinh.IdNv });
            }
            else
            {
                return View("Error");
            }

        }

        #endregion

        #region Xoá chính trị

        [HttpGet]
        public async Task<ActionResult> DeleteChinhTri(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinChinhTri>>($"http://10.0.0.4:5259/api/ThongTinChinhTri/{Id}");
            ChinhTri = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/ThongTinChinhTri/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = ChinhTri.IdNv });
            }
            else
            {
                return View("Error");
            }

        }

        #endregion
    }
}
