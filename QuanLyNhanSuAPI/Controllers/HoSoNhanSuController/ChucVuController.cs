using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ChucVuService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuService _chucvuService;
        public ChucVuController(IChucVuService chucvuService)
        {
            _chucvuService = chucvuService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbChucVu>>>> GetChucVusAsync()
        {
            var result = await _chucvuService.GetChucVusAsync();
            return Ok(result);
        }

        [HttpGet("{chucvuId}")]
        public async Task<ActionResult<ServiceResponse<TbChucVu>>> GetChucVuAsync(int chucvuId)
        {
            var result = await _chucvuService.GetChucVuAsync(chucvuId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> CreateChucVuAsync(TbChucVuDTO chucvu)
        {
            var response = await _chucvuService.CreateChucVu(
                new TbChucVu
                {
                    TenChucVu = chucvu.TenChucVu
                }
                );
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbChucVu>>> UpdateChucVuAsync([FromForm] TbChucVu chucvu)
        {
            //var response = await _chucvuService.UpdateChucVu(
            //    new TbChucVu
            //    {
            //        IdCv = chucvu.Id,
            //        TenChucVu = chucvu.TenChucVu
            //    }
            //    );
            var result = await _chucvuService.UpdateChucVu(chucvu);
            return Ok(result);
        }

        [HttpDelete("{chucvuId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteChucVuAsync(int chucvuId)
        {
            var respone = await _chucvuService.DeleteChucVu(chucvuId);
            return Ok(respone);
        }
    }
}
