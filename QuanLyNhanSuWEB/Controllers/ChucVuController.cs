using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuWEB.Models;

namespace QuanLyNhanSuWEB.Controllers
{
    [TypeFilter(typeof(AdminAuthorizationFilter))]
    public class ChucVuController : Controller
    {
        private readonly HttpClient _http;

        public ChucVuController(HttpClient http)
        {
            _http = http;
        }

        public List<TbChucVu> ChucVus { get; set; } = new List<TbChucVu>();
        public TbChucVu ChucVu = new TbChucVu();

        public async Task<ActionResult<ServiceResponse<List<TbChucVu>>>> Index()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TbChucVu>>>("http://10.0.0.4:5259/api/ChucVu");
            ChucVus = result.Data;
            return View(ChucVus);
        }

        public async Task<ActionResult<ServiceResponse<TbChucVu>>> Details(int chucvuId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbChucVu>>($"http://10.0.0.4:5259/api/ChucVu/{chucvuId}");
            ChucVu = result.Data;
            return View(ChucVu);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbChucVu>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbChucVu>>> Create(TbChucVu chucVu)
        {
            var result = await _http.PostAsJsonAsync("http://10.0.0.4:5259/api/ChucVu", chucVu);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbChucVu>>> Update(int chucvuId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbChucVu>>($"http://10.0.0.4:5259/api/ChucVu/{chucvuId}");
            ChucVu = result.Data;
            return View(ChucVu);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbChucVu>>> Update(TbChucVu chucVu)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(chucVu.IdCv.ToString()), "IdCv");
            content.Add(new StringContent(chucVu.TenChucVu.ToString()), "TenChucVu");

            var result = await _http.PutAsync("http://10.0.0.4:5259/api/ChucVu", content);
            string apiRes = await result.Content.ReadAsStringAsync();
            ViewBag.Result = "Thành Công";
            chucVu = JsonConvert.DeserializeObject<TbChucVu>(apiRes);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int chucvuId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TbChucVu>>($"http://10.0.0.4:5259/api/ChucVu/{chucvuId}");
            ChucVu = result.Data;
            var respon = await _http.DeleteAsync($"http://10.0.0.4:5259/api/ChucVu/{chucvuId}");
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
            //return View(ChucVu);
        }

        //[HttpPost, ActionName("Delete")]
        //public async Task<ActionResult<ServiceResponse<TbChucVu>>> DeleteConfirmed(int chucvuId)
        //{
        //    var result = await _http.DeleteAsync($"http://10.0.0.4:5259/swagger/index.html/{chucvuId}");
        //    return RedirectToAction("Index");
        //}
    }
}
