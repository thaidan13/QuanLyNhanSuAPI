using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinGiaDinhService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinGiaDinhController : ControllerBase
    {
        private readonly IThongTinGiaDinhService _giadinhService;

        public ThongTinGiaDinhController(IThongTinGiaDinhService giadinhService)
        {
            _giadinhService = giadinhService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinGiaDinh>>>> GetGiaDinhsAsync()
        {
            var result = await _giadinhService.GetGiaDinhsAsync();
            return Ok(result);
        }

        [HttpGet("{giadinhId}")]
        public async Task<ActionResult<ServiceResponse<TbThongTinGiaDinh>>> GetGiaDinhAsync(int giadinhId)
        {
            var result = await _giadinhService.GetGiaDinhAsync(giadinhId);
            return Ok(result);
        }

        [HttpGet("nhanviengiadinh/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinGiaDinh>>>> GetNhanVienGiaDinhAsync(int nhanvienId)
        {
            var result = await _giadinhService.GetGiaDinhNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinGiaDinh>>> CreateGiaDinhAsync(TbThongTinGiaDinh giadinh)
        {
            var result = await _giadinhService.CreateGiaDinh(giadinh);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbThongTinGiaDinh>>> UpdateGiaDinhAsync(TbThongTinGiaDinh giadinh)
        {
            var result = await _giadinhService.UpdateGiaDinh(giadinh);
            return Ok(result);
        }

        [HttpDelete("{giadinhId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteGiaDinhAsync(int giadinhId)
        {
            var result = await _giadinhService.DeleteGiaDinh(giadinhId);
            return Ok(result);
        }
    }
}
