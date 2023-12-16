using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhCongTacService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuaTrinhCongTacController : ControllerBase
    {
        private readonly IQuaTrinhCongTacService _congtacService;

        public QuaTrinhCongTacController(IQuaTrinhCongTacService congtacService)
        {
            _congtacService = congtacService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbQuaTrinhCongTac>>>> GetCongTacsAsync()
        {
            var result = await _congtacService.GetCongTacsAsync();
            return Ok(result);
        }

        [HttpGet("{congtacId}")]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhCongTac>>> GetCongTacAsync(int congtacId)
        {
            var result = await _congtacService.GetCongTacAsync(congtacId);
            return Ok(result);
        }

        [HttpGet("congtacnhanvien/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbQuaTrinhCongTac>>>> GetCongTacNhanVienAsync(int nhanvienId)
        {
            var result = await _congtacService.GetCongTacNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpGet("congtacngoaicongty/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbQuaTrinhCongTac>>>> GetNgoaiCongTysAsync(int nhanvienId)
        {
            var result = await _congtacService.GetCongTacNgoaiCongTys(nhanvienId);
            return Ok(result);
        }

        [HttpGet("congtactrongcongty/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbQuaTrinhCongTac>>>> GetTrongCongTysAsync(int nhanvienId)
        {
            var result = await _congtacService.GetCongTacTrongCongTys(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhCongTac>>> CreateCongTacAsync(TbQuaTrinhCongTac congtac)
        {
            var result = await _congtacService.CreateCongTac(congtac);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhCongTac>>> UpdateCongTacAsync(TbQuaTrinhCongTac congtac)
        {
            var result = await _congtacService.UpdateCongTac(congtac);
            return Ok(result);
        }

        [HttpDelete("{congtacId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteCongTacAsync(int congtacId)
        {
            var result = await _congtacService.DeleteCongTac(congtacId);
            return Ok(result);
        }
    }
}
