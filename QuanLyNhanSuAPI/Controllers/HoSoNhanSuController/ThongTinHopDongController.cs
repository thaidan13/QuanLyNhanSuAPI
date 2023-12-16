using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinHopDongLaoDongService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinHopDongController : ControllerBase
    {
        private readonly IThongTinHopDongLaoDongService _hopdongService;

        public ThongTinHopDongController(IThongTinHopDongLaoDongService hopdongService)
        {
            _hopdongService = hopdongService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinHopDongLaoDong>>>> GetHopDongsAsync()
        {
            var result = await _hopdongService.GetHopDongsAsync();
            return Ok(result);
        }

        [HttpGet("{hopdongId}")]
        public async Task<ActionResult<ServiceResponse<TbThongTinHopDongLaoDong>>> GetHopDongAsync(int hopdongId)
        {
            var result = await _hopdongService.GetHopDongAsync(hopdongId);
            return Ok(result);
        }

        [HttpGet("hopdongnhanvien/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinHopDongLaoDong>>>> GetHopDongNhanVienAsync(int nhanvienId)
        {
            var result = await _hopdongService.GetHopDongNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinHopDongLaoDong>>> CreateHopDongAsync(TbThongTinHopDongLaoDong hopdong)
        {
            var result = await _hopdongService.CreateHopDong(hopdong);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbThongTinHopDongLaoDong>>> UpdateHopDongAsync(TbThongTinHopDongLaoDong hopdong)
        {
            var result = await _hopdongService.UpdateHopDong(hopdong);
            return Ok(result);
        }

        [HttpDelete("{hopdongId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteHopDongAsync(int hopdongId)
        {
            var result = await _hopdongService.DeleteHopDong(hopdongId);
            return Ok(result);
        }
    }
}
