using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Helper;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class HopDongLaoDongController : Controller
    {
        private readonly HttpClient _http;
        private readonly UploadFileHelper _uploadHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HopDongLaoDongController(HttpClient http, UploadFileHelper uploadHelper, IWebHostEnvironment webHostEnvironment)
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

        public TbThongTinHopDongLaoDong HopDong { get; set; } = new TbThongTinHopDongLaoDong();

        #endregion

        #region Hiển thị danh sách

        public async Task<ActionResult<ServiceResponse<HopDongLaoDongDTO>>> Index(int nhanvienId)
        {
            var nhanvien = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinNhanVien>>($"http://10.0.0.4:5259/api/ThongTinNhanVien/{nhanvienId}");

            var hopdong = await _http.GetFromJsonAsync<ServiceResponse<List<TbThongTinHopDongLaoDong>>>($"http://10.0.0.4:5259/api/ThongTinHopDong/hopdongnhanvien/{nhanvienId}");

            var HopDongModel = new HopDongLaoDongDTO
            {
                HopDongs = hopdong.Data,
                NhanVien = nhanvien.Data
            };

            return View(HopDongModel);
        }

        #endregion

        #region Thêm Hợp đồng

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinHopDongLaoDong>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinHopDongLaoDong>>> Create(TbThongTinHopDongLaoDong hopdong, IFormFile File,  IFormFile FileQuyetDinh)
        {
            if (File != null)
            {
                // Tải lên hình ảnh và lấy tên file
                string fileNameHdld = await _uploadHelper.UploadFile(File);
                //string fileNameQuyetDinh = await _uploadHelper.UploadFile(FileQuyetDinh);

                // Lưu tên file vào model 
                hopdong.FileHdld = fileNameHdld;
                //hopdong.FileQuyetDinh = fileNameQuyetDinh;
            }
            if (FileQuyetDinh != null)
            {
                // Tải lên hình ảnh và lấy tên file
                //string fileNameHdld = await _uploadHelper.UploadFile(File);
                string fileNameQuyetDinh = await _uploadHelper.UploadFile(FileQuyetDinh);

                // Lưu tên file vào model 
                //hopdong.FileHdld = fileNameHdld;
                hopdong.FileQuyetDinh = fileNameQuyetDinh;
            }

            var createhopdong = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/ThongTinHopDong", hopdong);
            if (createhopdong.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = hopdong.IdNv });
            }

            return RedirectToAction("ErrorAction");
        }

        #endregion

        #region Cập nhật hợp đồng

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbThongTinHopDongLaoDong>>> Update(int Id)
        {
            var hopdong = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinHopDongLaoDong>>($"http://10.0.0.4:5259/api/ThongTinHopDong/{Id}");

            return View(hopdong);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinHopDongLaoDong>>> Update(TbThongTinHopDongLaoDong thongtinhopdong, IFormFile File, IFormFile FileQD)
        {
            if (File != null)
            {
                // Tải lên hình ảnh và lấy tên file
                string fileNameHdld = await _uploadHelper.UploadFile(File);

                // Lưu tên file vào model 
                thongtinhopdong.FileHdld = fileNameHdld;
                
            }
            if(FileQD != null)
            {
                string fileNameQuyetDinh = await _uploadHelper.UploadFile(FileQD);
                thongtinhopdong.FileQuyetDinh = fileNameQuyetDinh;
            }
           
            var updatekhenthuong = await _http.PutAsJsonAsync("http://10.0.0.4:5259/api/ThongTinHopDong", thongtinhopdong);
            if (updatekhenthuong.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = thongtinhopdong.IdNv });
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Xoá hợp đồng

        [HttpGet]
        public async Task<ActionResult> DeleteHopDong(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbThongTinHopDongLaoDong>>($"http://10.0.0.4:5259/api/ThongTinHopDong/{Id}");
            HopDong = result.Data;
            var delete = await _http.DeleteAsync($"http://10.0.0.4:5259/api/ThongTinHopDong/{Id}");
            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { nhanvienId = HopDong.IdNv });
            }
            else
            {
                return View("Error");
            }
        }

        #endregion
    }
}
