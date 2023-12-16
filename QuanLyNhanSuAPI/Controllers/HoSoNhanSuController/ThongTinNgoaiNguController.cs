using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinNgoaiNguService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinNgoaiNguController : ControllerBase
    {
        private readonly IThongTinNgoaiNguService _ngoainguService;

        public ThongTinNgoaiNguController(IThongTinNgoaiNguService ngoainguService)
        {
            _ngoainguService = ngoainguService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinNgoaiNgu>>>> GetNgoaiNgusAsync()
        {
            var result = await _ngoainguService.GetNgoaiNgusAsync();
            return Ok(result);
        }

        [HttpGet("{ngoainguId}")]
        public async Task<ActionResult<ServiceResponse<TbThongTinNgoaiNgu>>> GetNgoaiNguAsync(int ngoainguId)
        {
            var result = await _ngoainguService.GetNgoaiNguAsync(ngoainguId);
            return Ok(result);
        }

        [HttpGet("nhanvienngoaingu/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinNgoaiNgu>>>> GetNgoaiNguNhanVienAsync(int nhanvienId)
        {
            var result = await _ngoainguService.GetNgoaiNguNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinNgoaiNgu>>> CreateNgoaiNguAsync(TbThongTinNgoaiNgu ngoaingu)
        {
            var result = await _ngoainguService.CreateNgoaiNgu(ngoaingu);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbThongTinNgoaiNgu>>> UpdateNgoaiNguAsync(TbThongTinNgoaiNgu ngoaingu)
        {
            var result = await _ngoainguService.UpdateNgoaiNgu(ngoaingu);
            return Ok(result);
        }

        [HttpDelete("{ngoainguId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteNgoaiNguAsync(int ngoainguId)
        {
            var result = await _ngoainguService.DeleteNgoaiNgu(ngoainguId);
            return Ok(result);
        }
    }
}
