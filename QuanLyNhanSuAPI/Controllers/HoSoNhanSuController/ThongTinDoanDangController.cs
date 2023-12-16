using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinDoanDangService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinDoanDangController : ControllerBase
    {
        private readonly IThongTinDoanDangService _doandangService;

        public ThongTinDoanDangController(IThongTinDoanDangService doandangService)
        {
            _doandangService = doandangService;
        }

        [HttpGet("{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<TbThongTinDoanDang>>> GetDoanDangAsync(int nhanvienId)
        {
            var result = await _doandangService.GetDoanDangAsync(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinDoanDang>>> CreateDoanDangAsync(TbThongTinDoanDangDTO doandang)
        {
            var result = await _doandangService.CreateDoanDang(doandang);
            return Ok(result);
        }


        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbThongTinDoanDang>>> UpdateDoanDangAsync(TbThongTinDoanDang doandang)
        {
            var result = await _doandangService.UpdateDoanDang(doandang);
            return Ok(result);
        }
    }
}
