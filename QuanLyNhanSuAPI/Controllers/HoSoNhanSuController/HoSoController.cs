using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.HoSoService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoSoController : ControllerBase
    {
        private readonly IHoSoService _hosoService;

        public HoSoController(IHoSoService hosoService)
        {
            _hosoService = hosoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbHoSo>>>> GetHoSosAsync()
        {
            var result = await _hosoService.GetHoSosAsync();
            return Ok(result);
        }

        [HttpGet("{hosoId}")]
        public async Task<ActionResult<ServiceResponse<TbHoSo>>> GetHoSoAsync(int hosoId)
        {
            var result = await _hosoService.GetHoSoAsync(hosoId);
            return Ok(result);
        }

        [HttpGet("hosotuyendung/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbHoSo>>>> GetHoSoTuyenDungAsync(int nhanvienId)
        {
            var result = await _hosoService.GetHoSoTuyenDungNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpGet("hosolienquan/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbHoSo>>>> GetHoSoLienQuanAsync(int nhanvienId)
        {
            var result = await _hosoService.GetHoSoLienQuanNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbHoSo>>> CreareHoSoAsync(TbHoSo hoso)
        {
            var result = await _hosoService.CreateHoSo(hoso);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbHoSo>>> UpdateHoSoAsync(TbHoSo hoso)
        {
            var result = await _hosoService.UpdateHoSo(hoso);
            return Ok(result);
        }

        [HttpDelete("{hosoId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteHoSoAsync(int hosoId)
        {
            var result = await _hosoService.DeleteHoSo(hosoId);
            return Ok(result);
        }
    }
}
