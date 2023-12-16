using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Helper;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class KyLuatController : Controller
    {
        private readonly HttpClient _http;
        private readonly UploadFileHelper _uploadHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public KyLuatController(HttpClient http, UploadFileHelper uploadHelper, IWebHostEnvironment webHostEnvironment)
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

        public TbKhenThuongKyLuat KhenThuongKyLuat { get; set; } = new TbKhenThuongKyLuat();

        #endregion

        #region Hiển thị danh sách

        public async Task<ActionResult<ServiceResponse<KhenThuongKyLuatDTO>>> Index(int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var khenthuong = await _http.GetFromJsonAsync<ServiceResponse<List<TbKhenThuongKyLuat>>>($"http://10.0.0.4:5259/api/KhenThuongKyLuat/kyluat/{nhanvienId}");

            var KhenThuongModel = new KhenThuongKyLuatDTO
            {
                KhenThuongKyLuats = khenthuong.Data,
                NhanVien = nhanvien.Data
            };

            return View(KhenThuongModel);
        }

        #endregion

        #region Thêm khen thưởng kỷ luật

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbKhenThuongKyLuat>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbKhenThuongKyLuat>>> Create(TbKhenThuongKyLuat khenthuongkyluat, IFormFile File)
        {
            if (File != null)
            {
                // Tải lên hình ảnh và lấy tên file
                string fileName = await _uploadHelper.UploadFile(File);

                // Lưu tên file vào model 
                khenthuongkyluat.DinhKem = fileName;
            }

            var createkhenthuongkyluat = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/KhenThuongKyLuat", khenthuongkyluat);
            if (createkhenthuongkyluat.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = khenthuongkyluat.IdNv });
            }

            return RedirectToAction("ErrorAction");
        }

        #endregion

        #region Cập nhật khen thưởng kỷ luật 

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbKhenThuongKyLuat>>> Update(int Id)
        {
            var khenthuong = await _http.GetFromJsonAsync<ServiceResponse<TbKhenThuongKyLuat>>($"http://10.0.0.4:5259/api/KhenThuongKyLuat/{Id}");

            return View(khenthuong);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbKhenThuongKyLuat>>> Update(TbKhenThuongKyLuat thongtinkhenthuong, IFormFile File)
        {
            if (File != null)
            {
                // Tải lên hình ảnh và lấy tên file
                string fileName = await _uploadHelper.UploadFile(File);

                // Lưu tên file vào model 
                thongtinkhenthuong.DinhKem = fileName;
            }
            var updatekhenthuong = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/KhenThuongKyLuat", thongtinkhenthuong);
            if (updatekhenthuong.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = thongtinkhenthuong.IdNv });
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Xoá khen thưởng kỷ luật

        [HttpGet]
        public async Task<ActionResult> DeleteKhenThuong(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbKhenThuongKyLuat>>($"http://10.0.0.4:5259/api/KhenThuongKyLuat/{Id}");
            KhenThuongKyLuat = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/KhenThuongKyLuat/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = KhenThuongKyLuat.IdNv });
            }
            else
            {
                return View("Error");
            }
        }

        #endregion

    }
}
