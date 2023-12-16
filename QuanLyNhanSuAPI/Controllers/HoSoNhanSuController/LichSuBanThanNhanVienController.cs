using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.LichSuBanThanNhanVienService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichSuBanThanNhanVienController : ControllerBase
    {
        private readonly ILichSuBanThanNhanVienService _lichsuService;

        public LichSuBanThanNhanVienController(ILichSuBanThanNhanVienService lichsuService)
        {
            _lichsuService = lichsuService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbLichSuBanThanNhanVien>>>> GetLichSuNhanViensAsync()
        {
            var result = await _lichsuService.GetLichSuNhanViensAsync();
            return Ok(result);
        }

        [HttpGet("{lichsuId}")]
        public async Task<ActionResult<ServiceResponse<TbLichSuBanThanNhanVien>>> GetLichSuNhanVienAsync(int lichsuId)
        {
            var result = await _lichsuService.GetLichSuNhanVienAsync(lichsuId);
            return Ok(result);
        }

        [HttpGet("lichsunhanvien/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbLichSuBanThanNhanVien>>>> GetNhanViensAsync(int nhanvienId)
        {
            var result = await _lichsuService.GetNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbLichSuBanThanNhanVien>>> CreateLichSuNhanVienAsync(TbLichSuBanThanNhanVien lichsu)
        {
            var result = await _lichsuService.CreateLichSuNhanVien(lichsu);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbLichSuBanThanNhanVien>>> UpdateLichSuNhanVienAsync(TbLichSuBanThanNhanVien lichsu)
        {
            var result = await _lichsuService.UpdateLichSuNhanVien(lichsu);
            return Ok(result);
        }

        [HttpDelete("{lichsuId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteLichSuNhanVienAsync(int lichsuId)
        {
            var result = await _lichsuService.DeleteLichSuNhanVien(lichsuId);
            return Ok(result);
        }
    }
}
