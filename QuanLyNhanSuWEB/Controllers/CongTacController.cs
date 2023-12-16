using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Helper;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class CongTacController : Controller
    {
        private readonly HttpClient _http;
        private readonly UploadFileHelper _uploadHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CongTacController(HttpClient http, UploadFileHelper uploadHelper, IWebHostEnvironment webHostEnvironment)
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

        public TbQuaTrinhCongTac CongTac { get; set; } = new TbQuaTrinhCongTac();

        #endregion

        #region Hiển thị danh sách

        public async Task<ActionResult<ServiceResponse<QuaTrinhCongTacDTO>>> Index(int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var trongcongty = await _http.GetFromJsonAsync<ServiceResponse<List<TbQuaTrinhCongTac>>>($"http://10.0.0.4:5259/api/QuaTrinhCongTac/congtactrongcongty/{nhanvienId}");

            var ngoaicongty = await _http.GetFromJsonAsync<ServiceResponse<List<TbQuaTrinhCongTac>>>($"http://10.0.0.4:5259/api/QuaTrinhCongTac/congtacngoaicongty/{nhanvienId}");

            var CongTacModel = new QuaTrinhCongTacDTO
            {
                TrongCongTacs = trongcongty.Data,
                NgoaiCongTacs = ngoaicongty.Data,
                NhanVien = nhanvien.Data
            };

            return View(CongTacModel);
        }

        #endregion

        #region Thêm công tác

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhCongTac>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhCongTac>>> Create(TbQuaTrinhCongTac congtac, IFormFile File)
        {
            if (File != null)
            {
                // Tải lên hình ảnh và lấy tên file
                string fileName = await _uploadHelper.UploadFile(File);

                // Lưu tên file vào model 
                congtac.FileQuyetDinh = fileName;
            }

            var createkhencongtac = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/QuaTrinhCongTac", congtac);
            if (createkhencongtac.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = congtac.IdNv });
            }

            return RedirectToAction("ErrorAction");
        }

        #endregion

        #region Cập nhật công tác

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhCongTac>>> Update(int Id)
        {
            var congtac = await _http.GetFromJsonAsync<ServiceResponse<TbQuaTrinhCongTac>>($"http://10.0.0.4:5259/api/QuaTrinhCongTac/{Id}");

            return View(congtac);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhCongTac>>> Update(TbQuaTrinhCongTac congtac, IFormFile File)
        {
            if (File != null)
            {
                // Tải lên hình ảnh và lấy tên file
                string fileName = await _uploadHelper.UploadFile(File);

                // Lưu tên file vào model 
                congtac.FileQuyetDinh = fileName;
            }
            var updatecongtac = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/QuaTrinhCongTac", congtac);
            if (updatecongtac.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = congtac.IdNv });
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Xoá công tác

        [HttpGet]
        public async Task<ActionResult> DeleteCongTac(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbQuaTrinhCongTac>>($"http://10.0.0.4:5259/api/QuaTrinhCongTac/{Id}");
            CongTac = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/QuaTrinhCongTac/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = CongTac.IdNv });
            }
            else
            {
                return View("Error");
            }
        }

        #endregion
    }
}
