using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinViTinhService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinViTinhController : ControllerBase
    {
        private readonly IThongTinViTinhService _vitinhService;

        public ThongTinViTinhController(IThongTinViTinhService vitinhService)
        {
            _vitinhService = vitinhService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinViTinh>>>> GetViTinhsAsync()
        {
            var result = await _vitinhService.GetViTinhsAsync();
            return Ok(result);
        }

        [HttpGet("{vitinhId}")]
        public async Task<ActionResult<ServiceResponse<TbThongTinViTinh>>> GetViTinhAsync(int vitinhId)
        {
            var result = await _vitinhService.GetViTinhAsync(vitinhId);
            return Ok(result);
        }

        [HttpGet("vitinhnhanvien/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinViTinh>>>> GetViTinhNhanVienAsync(int nhanvienId)
        {
            var result = await _vitinhService.GetViTinhNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinViTinh>>> CreateThongTinViTinhAsync(TbThongTinViTinh vitinh)
        {
            var result = await _vitinhService.CreateViTinh(vitinh);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbThongTinViTinh>>> UpdateThongTinViTinhAsync(TbThongTinViTinh vitinh)
        {
            var result = await _vitinhService.UpdateViTinh(vitinh);
            return Ok(result);
        }

        [HttpDelete("{vitinhId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteThongTinViTinhAsync(int vitinhId)
        {
            var result = await _vitinhService.DeleteViTinh(vitinhId); return Ok(result);
        }
    }
}
