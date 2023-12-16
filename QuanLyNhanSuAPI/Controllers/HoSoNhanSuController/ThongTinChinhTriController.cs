using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinChinhTriService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinChinhTriController : ControllerBase
    {
        private readonly IThongTinChinhTriService _chinhtriService;

        public ThongTinChinhTriController(IThongTinChinhTriService chinhtriService)
        {
            _chinhtriService = chinhtriService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinChinhTri>>>> GetChinhTrisAsync()
        {
            var result = await _chinhtriService.GetChinhTrisAsync();
            return Ok(result);
        }

        [HttpGet("{chinhtriId}")]
        public async Task<ActionResult<ServiceResponse<TbThongTinChinhTri>>> GetChinhTriAsync(int chinhtriId)
        {
            var result = await _chinhtriService.GetChinhTriAsync(chinhtriId);
            return Ok(result);
        }

        [HttpGet("nhanvienchinhtri/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbThongTinChinhTri>>>> GetChinhTriNhanVienAsync(int nhanvienId)
        {
            var result = await _chinhtriService.GetChinhTriNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbThongTinChinhTri>>> CreateChinhTriAsync(TbThongTinChinhTri chinhtri)
        {
            var result = await _chinhtriService.CreateChinhTri(chinhtri);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbThongTinChinhTri>>> UpdateChinhTriAsync(TbThongTinChinhTri chinhtri)
        {
            var result = await _chinhtriService.UpdateChinhTri(chinhtri);
            return Ok(result);
        }

        [HttpDelete("{chinhtriId}")]
        public async Task<ActionResult<ServiceResponse<TbThongTinChinhTri>>> DeleteChinhTriAsync(int chinhtriId)
        {
            var result = await _chinhtriService.DeleteChinhTri(chinhtriId);
            return Ok(result);
        }
    }
}
