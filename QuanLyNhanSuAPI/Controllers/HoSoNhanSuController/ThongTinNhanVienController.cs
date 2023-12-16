using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinChinhTriService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinNhanVienService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinNhanVienController : ControllerBase
    {
        private readonly IThongTinNhanVienService _nhanvienService;
        public ThongTinNhanVienController(IThongTinNhanVienService nhanvienService)
        {
            _nhanvienService = nhanvienService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinNhanVien>>>> GetNhanViensAsync()
        {
            var result = await _nhanvienService.GetNhanViensAsync();
            return Ok(result);
        }

        

        [HttpGet("{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<TbThongTinNhanVienDTO>>> GetNhanVienAsync(int nhanvienId)
        {
            var result = await _nhanvienService.GetNhanVienAsync(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinNhanVien>>> CreateNhanVienAsync(TbThongTinNhanVien nhanvien)
        {
            var result = await _nhanvienService.CreateNhanVien(nhanvien);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbThongTinNhanVien>>> UpdateNhanVienAsync(TbThongTinNhanVien nhanvien)
        {
            var result = await _nhanvienService.UpdateNhanVien(nhanvien);
            return Ok(result);
        }

        [HttpDelete("{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteNhanVienAsync(int nhanvienId)
        {
            var result = await _nhanvienService.DeleteNhanVien(nhanvienId);
            return Ok(result);
        }
    }
}
