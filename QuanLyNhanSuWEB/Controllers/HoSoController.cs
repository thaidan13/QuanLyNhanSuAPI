using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Helper;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class HoSoController : Controller
    {
        private readonly HttpClient _http;
        private readonly UploadFileHelper _uploadHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HoSoController(HttpClient http, UploadFileHelper uploadHelper, IWebHostEnvironment webHostEnvironment)
        {
            _http = http;
            _uploadHelper = uploadHelper;
            _webHostEnvironment = webHostEnvironment;
        }

        #region Download File

        public IActionResult DownloadFile(string fileName)
        {
            // Xác định đường dẫn đầy đủ đến tệp tin trong thư mục uploads
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploadfiles", fileName);

            // Kiểm tra xem tệp tin có tồn tại không
            if (System.IO.File.Exists(filePath))
            {
                // Đọc nội dung tệp tin vào một mảng byte
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                // Trả về tệp tin như một phản hồi
                return File(fileBytes, "application/octet-stream", fileName);
            }

            // Nếu tệp tin không tồn tại, trả về lỗi 404
            return NotFound();
        }


        #endregion

        #region Tạo biến

        public TbHoSo HoSo { get; set; } = new TbHoSo();

        #endregion

        #region Hiển thị danh sách

        public async Task<ActionResult<ServiceResponse<HoSoDTO>>> Index(int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var hoso = await _http.GetFromJsonAsync<ServiceResponse<List<TbHoSo>>>($"http://10.0.0.4:5259/api/HoSo/hosotuyendung/{nhanvienId}");

            var HoSoModel = new HoSoDTO
            {
                HoSos = hoso.Data,
                NhanVien = nhanvien.Data
            };

            return View(HoSoModel);
        }

        #endregion

        #region Thêm hồ sơ

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbHoSo>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbHoSo>>> Create(TbHoSo hoso, IFormFile File)
        {
            if (File != null)
            {
                // Tải lên hình ảnh và lấy tên file
                string fileName = await _uploadHelper.UploadFile(File);

                // Lưu tên file vào model 
                hoso.TapTin = fileName;
            }

            var createhoso = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/HoSo", hoso);
            if (createhoso.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = hoso.IdNv });
            }

            return RedirectToAction("ErrorAction");
        }

        #endregion

        #region Cập nhật hồ sơ

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbHoSo>>> Update(int Id)
        {
            var hoso = await _http.GetFromJsonAsync<ServiceResponse<TbHoSo>>($"http://10.0.0.4:5259/api/HoSo/{Id}");

            return View(hoso);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbHoSo>>> Update(TbHoSo thongtinhoso, IFormFile File)
        {
            if (File != null)
            {
                // Tải lên hình ảnh và lấy tên file
                string fileName = await _uploadHelper.UploadFile(File);

                // Lưu tên file vào model 
                thongtinhoso.TapTin = fileName;
            }
            var updatehoso = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/HoSo", thongtinhoso);
            if (updatehoso.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = thongtinhoso.IdNv });
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Xoá hồ sơ

        [HttpGet]
        public async Task<ActionResult> DeleteHoSo(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbHoSo>>($"http://10.0.0.4:5259/api/HoSo/{Id}");
            HoSo = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/HoSo/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = HoSo.IdNv });
            }
            else
            {
                return View("Error");
            }
        }

        #endregion

    }
}
