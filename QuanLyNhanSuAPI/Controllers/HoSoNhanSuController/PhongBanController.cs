using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.PhongBanService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanService _phongbanService;
        public PhongBanController(IPhongBanService phongbanService)
        {
            _phongbanService = phongbanService;
        }

        [HttpGet("PhongBanOkr")]
        public async Task<ActionResult<List<PhongBanModelView>>> GetPhongBanOKRs()
        {
            var result = await _phongbanService.GetPhongBanOKRs();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbPhongBan>>>> GetPhongBansAsync()
        {
            var response = await _phongbanService.GetPhongBansAsync();
            return Ok(response);
        }

        [HttpGet("{phongbanId}")]
        public async Task<ActionResult<ServiceResponse<TbPhongBan>>> GetPhongBanAsync(int phongbanId)
        {
            var response = await _phongbanService.GetPhongBanAsync(phongbanId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> CreatePhongBanAsync(TbPhongBanDTO phongban)
        {
            var response = await _phongbanService.CreatePhongBan(
                new TbPhongBan
                {
                    IdPb = phongban.Id,
                    TenPhongBan = phongban.TenPhongBan,
                    QuanLy = phongban.QuanLy
                }
                );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbPhongBan>>> UpdatePhongBanAsync([FromForm] TbPhongBan phongban)
        {
            var result = await _phongbanService.UpdatePhongBan(phongban);
            return Ok(result);
        }


        [HttpDelete("{phongbanId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeletePhongBanAsync(int phongbanId)
        {
            var response = await _phongbanService.DeletePhongBan(phongbanId);
            return Ok(response);
        }
    }
}
