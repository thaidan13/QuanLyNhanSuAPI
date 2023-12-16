using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.Helper;
using QuanLyNhanSuWEB.Models;
using System.Net.Http.Json;
using System.Net.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;
using X.PagedList;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class ThongTinNhanVienController : Controller
    {
        private readonly HttpClient _http;
        private readonly UploadHelper _uploadHelper;

        public ThongTinNhanVienController(HttpClient http, UploadHelper uploadHelper)
        {
            _http = http;
            _uploadHelper = uploadHelper;
        }

        public List<TbThongTinNhanVien> NhanViens { get; set; } = new List<TbThongTinNhanVien>();
        public TbThongTinNhanVien NhanVien = new TbThongTinNhanVien();
        public List<TbPhongBan> PhongBans { get; set; } = new List<TbPhongBan>();
        public List<TbChucVu> ChucVus { get; set; } = new List<TbChucVu>();

        public async Task<ActionResult<ServiceResponse<List<TbThongTinNhanVien>>>> Index(string searchString, int? page)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            NhanViens = result.Data;
            //return View(NhanViens);

            if (!string.IsNullOrEmpty(searchString))
            {
                NhanViens = NhanViens.Where(n => n.HoKhaiSinh.Contains(searchString) || n.TenKhaiSinh.Contains(searchString) || n.Dtdd.Contains(searchString)
                || n.Email.Contains(searchString) || n.BiDanh.Contains(searchString) || n.HoKhaiSinh + " " + n.TenKhaiSinh == searchString).ToList();
            }
            

            var pageNumber = page ?? 1;
            int pageSize = 10;

            ViewBag.SearchString = searchString;
            ViewBag.PageNumber = pageNumber;

            IPagedList<TbThongTinNhanVien> pagedData = NhanViens.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }

        public async Task<ActionResult<ServiceResponse<TbThongTinNhanVien>>> Details(int IdNV)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<TbPhongBan>>>("http://10.0.0.4:5259/api/PhongBan");
            PhongBans = response.Data;
            ViewBag.TenPhongBan = new SelectList(PhongBans, "IdPb", "TenPhongBan");

            var result = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{IdNV}");
            NhanVien = result.Data;
            return View(NhanVien);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinNhanVien>>> Create()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<TbPhongBan>>>("http://10.0.0.4:5259/api/PhongBan");
            PhongBans = response.Data;
            ViewBag.TenPhongBan = new SelectList(PhongBans, "IdPb", "TenPhongBan");

            var chucvu = await _http.GetFromJsonAsync<ServiceResponse<List<TbChucVu>>>("http://10.0.0.4:5259/api/ChucVu");
            ChucVus = chucvu.Data;
            ViewBag.TenChucVu = new SelectList(ChucVus, "IdCv", "TenChucVu");

            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinNhanVien>>> Create(TbThongTinNhanVien nhanvien, IFormFile imageFile)
        {
            //var result = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinNhanVien>>>("http://10.0.0.4:5259/api/ThongTinNhanVien");
            //NhanViens = result.Data;
            if (imageFile != null)
            {
                // Tải lên hình ảnh và lấy tên file
                string fileName = await _uploadHelper.UploadImage(imageFile);

                // Lưu tên file vào model 
                nhanvien.HinhAnh = fileName;
            }
            if (imageFile == null || imageFile.Length == 0)
            {
                // Thêm lỗi vào ModelState
                ModelState.AddModelError("ImageFile", "Vui lòng chọn hình ảnh.");

                // Trả về view với ModelState để hiển thị lỗi
                return View(nhanvien);
            }
            

            var result = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/ThongTinNhanVien", nhanvien);

           
            return RedirectToAction("Index");


        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinNhanVien>>> Update(int nhanvienId)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<TbPhongBan>>>("http://10.0.0.4:5259/api/PhongBan");
            PhongBans = response.Data;
            ViewBag.TenPhongBan = new SelectList(PhongBans, "IdPb", "TenPhongBan");

            var chucvu = await _http.GetFromJsonAsync<ServiceResponse<List<TbChucVu>>>("http://10.0.0.4:5259/api/ChucVu");
            ChucVus = chucvu.Data;
            ViewBag.TenChucVu = new SelectList(ChucVus, "IdCv", "TenChucVu");

            var result = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");
            NhanVien = result.Data;

            if(NhanVien != null)
            {
                DateTime dateFromDatabase = NhanVien.NgaySinh;
                string formattedDate = dateFromDatabase.ToString("dd-MM-yyyy");
                ViewBag.FormattedDate = formattedDate;
            }

            return View(NhanVien);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinNhanVien>>> Update(TbThongTinNhanVien nhanvien, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                // Tải lên hình ảnh và lấy tên file
                string fileName = await _uploadHelper.UploadImage(imageFile);

                // Lưu tên file vào model món ăn
                nhanvien.HinhAnh = fileName;
            }

            var result = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/ThongTinNhanVien", nhanvien);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<ActionResult> Delete(int nhanvienId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");
            NhanVien = result.Data;
            var respon = await _http.DeleteAsync($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");
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
