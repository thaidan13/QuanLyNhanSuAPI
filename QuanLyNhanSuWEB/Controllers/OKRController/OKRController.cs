using QuanLyNhanSuWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using System.Net;
using QuanLyNhanSuWEB.DTO;
using X.PagedList;

namespace QuanLyNhanSuWEB.Controllers
{
    public class OKRController : Controller
    {
        private readonly HttpClient _http;

        public OKRController(HttpClient http)
        {
            _http = http;
        }

        public List<TbOkr> OKRs { get; set; } = new List<TbOkr>();
        public TbOkr OKR { get; set; } = new TbOkr();
        public List<TbPhongBan> PhongBans { get; set; } = new List<TbPhongBan>();
        public List<TbThongTinNhanVien> NhanViens { get; set; } = new List<TbThongTinNhanVien>();
        public List<DiemThanhCongCuaOkr> Diems { get; set; } = new List<DiemThanhCongCuaOkr>();
        public DiemThanhCongCuaOkr Diem { get; set; } = new DiemThanhCongCuaOkr();

        [TypeFilter(typeof(AdminAuthorizationFilter))]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DiemThanhCongCuaOkr>>>> GetDiemThanhCong()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<DiemThanhCongCuaOkr>>>("http://10.0.0.4:5259/api/OKR/diemokr");
            Diems = result.Data;
            return View(Diems);
        }


        [TypeFilter(typeof(AdminAuthorizationFilter))]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbOkr>>>> GetOKRsAdmin(string searchString, int? page)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TbOkr>>>("http://10.0.0.4:5259/api/OKR/admin");
            OKRs = result.Data;
            //return View(OKRs);

            if (!string.IsNullOrEmpty(searchString))
            {
                OKRs = OKRs.Where(n => n.TieuDe.Contains(searchString) || n.MucTieu.Contains(searchString)
                || n.KieuOkr.Contains(searchString) || n.ChuSoHuu == searchString).ToList();
            }

            var pageNumber = page ?? 1;
            int pageSize = 10;

            ViewBag.SearchStringOkr = searchString;
            ViewBag.PageNumber = pageNumber;

            IPagedList<TbOkr> pagedData = OKRs.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }

        [TypeFilter(typeof(NhanVienAuthorizationFilter))]
        public async Task<ActionResult<ServiceResponse<OkrDTO>>> Index(string email)
        {
            var response = await _http.GetFromJsonAsync<List<PhongBanModelView>>("http://10.0.0.4:5259/api/PhongBan/PhongBanOkr");
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            var diemthanhcong = await _http.GetFromJsonAsync<ServiceResponse<DiemThanhCongCuaOkr>>("http://10.0.0.4:5259/api/OKR/diemthanhcongokr");
            var okrs = await _http.GetFromJsonAsync<ServiceResponse<List<TbOkr>>>("http://10.0.0.4:5259/api/OKR/admin");
            OKRs = okrs.Data;
            NhanViens = nhanvien.Data;
            Diem = diemthanhcong.Data;
            ViewData["NhanVienResponse"] = NhanViens;
            ViewData["PhongBanResponse"] = response;
            ViewData["DiemResponse"] = Diem;
            ViewData["OkrResponse"] = OKRs;

            email = HttpContext.Session.GetString("Email");
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TbOkr>>>($"http://10.0.0.4:5259/api/OKR/nhanvien/okr?email={email}");

            var OkrModel = new OkrDTO
            {
                Okrs = result.Data
            };

            //OKRs = result.Data;
            return View(OkrModel);
        }

        [TypeFilter(typeof(AdminAuthorizationFilter))]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> Create()
        {
            var response = await _http.GetFromJsonAsync<List<PhongBanModelView>>("http://10.0.0.4:5259/api/PhongBan/PhongBanOkr");
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            var diemthanhcong = await _http.GetFromJsonAsync<ServiceResponse<DiemThanhCongCuaOkr>>("http://10.0.0.4:5259/api/OKR/diemthanhcongokr");
            var okrs = await _http.GetFromJsonAsync<ServiceResponse<List<TbOkr>>>("http://10.0.0.4:5259/api/OKR/admin");
            OKRs = okrs.Data;

            NhanViens = result.Data;
            Diem = diemthanhcong.Data;

            ViewData["NhanVienResponse"] = NhanViens;
            ViewData["PhongBanResponse"] = response;
            ViewData["DiemResponse"] = Diem;
            ViewData["OkrResponse"] = OKRs;

            return View();
        }

        [TypeFilter(typeof(AdminAuthorizationFilter))]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> Create(TbOkr okr)
        {
            var result = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/OKR", okr);
            return RedirectToAction("GetOKRsAdmin");
        }

        

        [TypeFilter(typeof(NhanVienAuthorizationFilter))]
        [HttpGet]
        [Route("OKR/UpdateOKrNhanVien/{okrid}")]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> UpdateOKrNhanVien(int okrid)
        {
           
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbOkr>>($"http://10.0.0.4:5259/api/OKR/chitietokr?id={okrid}");
            var response = await _http.GetFromJsonAsync<List<PhongBanModelView>>("http://10.0.0.4:5259/api/PhongBan/PhongBanOkr");
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            var diemthanhcong = await _http.GetFromJsonAsync<ServiceResponse<DiemThanhCongCuaOkr>>("http://10.0.0.4:5259/api/OKR/diemthanhcongokr");
            var okrs = await _http.GetFromJsonAsync<ServiceResponse<List<TbOkr>>>("http://10.0.0.4:5259/api/OKR/admin");
            OKRs = okrs.Data;
            NhanViens = nhanvien.Data;
            Diem = diemthanhcong.Data;
            ViewData["NhanVienResponse"] = NhanViens;
            ViewData["PhongBanResponse"] = response;
            ViewData["DiemResponse"] = Diem;
            ViewData["OkrResponse"] = OKRs;

            OKR = result.Data;
            return View(OKR);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> UpdateOKrNhanVien(TbOkr okr)
        {
            var result = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/OKR/nhanvienupdateokr", okr);


            var chitietokr = await _http.GetFromJsonAsync<ServiceResponse<TbOkr>>($"http://10.0.0.4:5259/api/OKR/chitietokr?id={okr.IdOkr}");
            var response = await _http.GetFromJsonAsync<List<PhongBanModelView>>("http://10.0.0.4:5259/api/PhongBan/PhongBanOkr");
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            var diemthanhcong = await _http.GetFromJsonAsync<ServiceResponse<DiemThanhCongCuaOkr>>("http://10.0.0.4:5259/api/OKR/diemthanhcongokr");
            var okrs = await _http.GetFromJsonAsync<ServiceResponse<List<TbOkr>>>("http://10.0.0.4:5259/api/OKR/admin");
            OKRs = okrs.Data;
            NhanViens = nhanvien.Data;
            Diem = diemthanhcong.Data;
            ViewData["NhanVienResponse"] = NhanViens;
            ViewData["PhongBanResponse"] = response;
            ViewData["DiemResponse"] = Diem;
            ViewData["OkrResponse"] = OKRs;

            OKR = chitietokr.Data;


            return View(OKR);
        }

        #region UpdateNhanVien

        [TypeFilter(typeof(NhanVienAuthorizationFilter))]
        [HttpGet]
        [Route("OKR/UpdateOKr/{okrid}")]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> UpdateOKr(int okrid)
        {

            var result = await _http.GetFromJsonAsync<ServiceResponse<TbOkr>>($"http://10.0.0.4:5259/api/OKR/chitietokr?id={okrid}");
            var response = await _http.GetFromJsonAsync<List<PhongBanModelView>>("http://10.0.0.4:5259/api/PhongBan/PhongBanOkr");
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            var diemthanhcong = await _http.GetFromJsonAsync<ServiceResponse<DiemThanhCongCuaOkr>>("http://10.0.0.4:5259/api/OKR/diemthanhcongokr");
            var okrs = await _http.GetFromJsonAsync<ServiceResponse<List<TbOkr>>>("http://10.0.0.4:5259/api/OKR/admin");
            OKRs = okrs.Data;
            NhanViens = nhanvien.Data;
            Diem = diemthanhcong.Data;
            ViewData["NhanVienResponse"] = NhanViens;
            ViewData["PhongBanResponse"] = response;
            ViewData["DiemResponse"] = Diem;
            ViewData["OkrResponse"] = OKRs;

            OKR = result.Data;
            return View(OKR);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<OkrDTO>>> UpdateOKr(OkrDTO okr)
        {
            var result = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/OKR/nhanvienupdateokr", okr.Okr);


            //var chitietokr = await _http.GetFromJsonAsync<ServiceResponse<TbOkr>>($"http://10.0.0.4:5259/api/OKR/chitietokr?id={okr.IdOkr}");
            var response = await _http.GetFromJsonAsync<List<PhongBanModelView>>("http://10.0.0.4:5259/api/PhongBan/PhongBanOkr");
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            var diemthanhcong = await _http.GetFromJsonAsync<ServiceResponse<DiemThanhCongCuaOkr>>("http://10.0.0.4:5259/api/OKR/diemthanhcongokr");
            var okrs = await _http.GetFromJsonAsync<ServiceResponse<List<TbOkr>>>("http://10.0.0.4:5259/api/OKR/admin");
            OKRs = okrs.Data;
            NhanViens = nhanvien.Data;
            Diem = diemthanhcong.Data;
            ViewData["NhanVienResponse"] = NhanViens;
            ViewData["PhongBanResponse"] = response;
            ViewData["DiemResponse"] = Diem;
            ViewData["OkrResponse"] = OKRs;

            //OKR = chitietokr.Data;


            return RedirectToAction("Index");
        }

        #endregion

        #region Admin Cập Nhật

        [TypeFilter(typeof(AdminAuthorizationFilter))]
        [HttpGet]
        [Route("OKR/UpdateOKrAdmin/{okrid}")]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> UpdateOKrAdmin(int okrid)
        {

            var result = await _http.GetFromJsonAsync<ServiceResponse<TbOkr>>($"http://10.0.0.4:5259/api/OKR/chitietokr?id={okrid}");
            var response = await _http.GetFromJsonAsync<List<PhongBanModelView>>("http://10.0.0.4:5259/api/PhongBan/PhongBanOkr");
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            var diemthanhcong = await _http.GetFromJsonAsync<ServiceResponse<DiemThanhCongCuaOkr>>("http://10.0.0.4:5259/api/OKR/diemthanhcongokr");
            var okrs = await _http.GetFromJsonAsync<ServiceResponse<List<TbOkr>>>("http://10.0.0.4:5259/api/OKR/admin");
            OKRs = okrs.Data;
            NhanViens = nhanvien.Data;
            Diem = diemthanhcong.Data;
            ViewData["NhanVienResponse"] = NhanViens;
            ViewData["PhongBanResponse"] = response;
            ViewData["DiemResponse"] = Diem;
            ViewData["OkrResponse"] = OKRs;

            OKR = result.Data;
            return View(OKR);
        }

        [TypeFilter(typeof(AdminAuthorizationFilter))]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> UpdateOKrAdmin(TbOkr okr)
        {
            var result = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/OKR/adminupdateokr", okr);


            var chitietokr = await _http.GetFromJsonAsync<ServiceResponse<TbOkr>>($"http://10.0.0.4:5259/api/OKR/chitietokr?id={okr.IdOkr}");
            var response = await _http.GetFromJsonAsync<List<PhongBanModelView>>("http://10.0.0.4:5259/api/PhongBan/PhongBanOkr");
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            var diemthanhcong = await _http.GetFromJsonAsync<ServiceResponse<DiemThanhCongCuaOkr>>("http://10.0.0.4:5259/api/OKR/diemthanhcongokr");
            var okrs = await _http.GetFromJsonAsync<ServiceResponse<List<TbOkr>>>("http://10.0.0.4:5259/api/OKR/admin");
            OKRs = okrs.Data;
            NhanViens = nhanvien.Data;
            Diem = diemthanhcong.Data;
            ViewData["NhanVienResponse"] = NhanViens;
            ViewData["PhongBanResponse"] = response;
            ViewData["DiemResponse"] = Diem;
            ViewData["OkrResponse"] = OKRs;

            OKR = chitietokr.Data;


            return View(OKR);
        }
        #endregion


        [TypeFilter(typeof(AdminAuthorizationFilter))]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<DiemThanhCongCuaOkr>>> UpdateDiemOkr(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<DiemThanhCongCuaOkr>>($"http://10.0.0.4:5259/api/OKR/diemokr/{id}");
            Diem = result.Data;
            return View(Diem);
        }

        [TypeFilter(typeof(AdminAuthorizationFilter))]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<DiemThanhCongCuaOkr>>> UpdateDiemOkr(DiemThanhCongCuaOkr diemokr)
        {
            var result = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/OKR/updatediemokr", diemokr);
            return RedirectToAction("GetDiemThanhCong");
        }
    }
}
