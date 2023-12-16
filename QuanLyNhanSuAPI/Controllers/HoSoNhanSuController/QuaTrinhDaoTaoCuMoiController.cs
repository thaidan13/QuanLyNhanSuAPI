using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.DiNuocNgoaiService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhDaoTaoCuMoiService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuaTrinhDaoTaoCuMoiController : ControllerBase
    {
        private readonly IQuaTrinhDaoTaoCuMoiService _daotaoService;

        public QuaTrinhDaoTaoCuMoiController(IQuaTrinhDaoTaoCuMoiService daotaoService)
        {
            _daotaoService = daotaoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>> GetDaoTaoCuMoisAsync()
        {
            var result = await _daotaoService.GetDaoTaoCuMoisAsync();
            return Ok(result);
        }

        [HttpGet("{daotaoId}")]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>> GetDaoTaoCuMoiAsync(int daotaoId)
        {
            var result = await _daotaoService.GetDaoTaoCuMoiAsync(daotaoId);
            return Ok(result);
        }

        [HttpGet("daotaocu/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>>> GetDaoTaoCuNhanVienAsync(int nhanvienId)
        {
            var result = await _daotaoService.GetDaoTaoCuNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpGet("daotaomoi/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>> GetDaoTaoMoiNhanVienAsync(int nhanvienId)
        {
            var result = await _daotaoService.GetDaoTaoMoiNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>> CreateDaoTaoAsync(TbQuaTrinhDaoTaoCuMoi daotao)
        {
            var result = await _daotaoService.CreateDaoTaoCuMoi(daotao);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>>> UpdateDaoTaoCuMoiAsync(TbQuaTrinhDaoTaoCuMoi daotao)
        {
            var result = await _daotaoService.UpdateDaoTaoCuMoi(daotao);
            return Ok(result);
        }

        [HttpDelete("{daotaoId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteDaoTaoCuMoiAsync(int daotaoId)
        {
            var result = await _daotaoService.DeleteDaoTaoCuMoi(daotaoId);
            return Ok(result);
        }
    }
}
