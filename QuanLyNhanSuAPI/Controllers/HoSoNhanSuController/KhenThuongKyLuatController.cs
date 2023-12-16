using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.KhenThuongKyLuatService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhenThuongKyLuatController : ControllerBase
    {
        private readonly IKhenThuongKyLuatService _khenthuongkyluatService;

        public KhenThuongKyLuatController(IKhenThuongKyLuatService khenthuongkyluatService)
        {
            _khenthuongkyluatService = khenthuongkyluatService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbKhenThuongKyLuat>>>> GetKhenThuongKyLuatsAsync()
        {
            var result = await _khenthuongkyluatService.GetKhenThuongKyLuatsAsync();
            return Ok(result);
        }

        [HttpGet("{khenthuongkyluatId}")]
        public async Task<ActionResult<ServiceResponse<TbKhenThuongKyLuat>>> GetKhenThuongKyLuatAsync(int khenthuongkyluatId)
        {
            var result = await _khenthuongkyluatService.GetKhenThuongKyLuatAsync(khenthuongkyluatId);
            return Ok(result);
        }

        [HttpGet("khenthuong/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbKhenThuongKyLuat>>>> GetKhenThuongNhanVien(int nhanvienId)
        {
            var result = await _khenthuongkyluatService.GetKhenThuongNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpGet("kyluat/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbKhenThuongKyLuat>>>> GetKyLuatNhanVien(int nhanvienId)
        {
            var result = await _khenthuongkyluatService.GetKyLuatNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbKhenThuongKyLuat>>> CreateKhenThuongKyLuatAsync(TbKhenThuongKyLuat khenThuongKyLuat)
        {
            var result = await _khenthuongkyluatService.CreateKhenThuongKyLuat(khenThuongKyLuat);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbKhenThuongKyLuat>>> UpdateKhenThuongKyLuatAsync(TbKhenThuongKyLuat khenThuongKyLuat)
        {
            var result = await _khenthuongkyluatService.UpdateKhenThuongKyLuat(khenThuongKyLuat);
            return Ok(result);
        }

        [HttpDelete("{khenthuongkyluatId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteKhenThuongKyLuatAsync(int khenthuongkyluatId)
        {
            var result = await _khenthuongkyluatService.DeleteKhenThuongKyLuat(khenthuongkyluatId);
            return Ok(result);
        }
    }
}
