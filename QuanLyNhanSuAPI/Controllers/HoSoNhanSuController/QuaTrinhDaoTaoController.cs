using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhDaoTaoService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuaTrinhDaoTaoController : ControllerBase
    {
        private readonly IQuaTrinhDaoTaoService _quatrinhdaotaoService;

        public QuaTrinhDaoTaoController(IQuaTrinhDaoTaoService quatrinhdaotaoService)
        {
            _quatrinhdaotaoService = quatrinhdaotaoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbQuaTrinhDaoTao>>>> GetDaoTaosAsync()
        {
            var result = await _quatrinhdaotaoService.GetQuaTrinhDaoTaosAsync();
            return Ok(result);
        }

        [HttpGet("{daotaoId}")]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTao>>> GetDaoTaoAsync(int daotaoId)
        {
            var result = await _quatrinhdaotaoService.GetQuaTrinhDaoTaoAsync(daotaoId);
            return Ok(result);
        }

        [HttpGet("nhanviendaotao/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTao>>> GetNhanVienDaoTaoAsync(int nhanvienId)
        {
            var result = await _quatrinhdaotaoService.GetDaoTaoNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTao>>> CreateQuaTrinhDaoTaoAsync(TbQuaTrinhDaoTao quatrinhDaoTao)
        {
            var result = await _quatrinhdaotaoService.CreateQuaTrinhDaoTao(quatrinhDaoTao);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhDaoTao>>> UpdateDaoTaoAsync(TbQuaTrinhDaoTao quaTrinhDaoTao)
        {
            var result = await _quatrinhdaotaoService.UpdateQuaTrinhDaoTao(quaTrinhDaoTao);
            return Ok(result);
        }

        [HttpDelete("{daotaoId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteDaoTaoAsync(int daotaoId)
        {
            var result = await _quatrinhdaotaoService.DeleteQuaTrinhDaoTao(daotaoId);
            return Ok(result);
        }

    }
}
