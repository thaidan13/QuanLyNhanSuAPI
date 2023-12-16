using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhLamViecCuaThanNhanService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuaTrinhLamViecCuaThanNhanController : ControllerBase
    {
        private readonly IQuaTrinhLamViecCuaThanNhanService _lamviecthannhanService;

        public QuaTrinhLamViecCuaThanNhanController(IQuaTrinhLamViecCuaThanNhanService lamviecthannhanService)
        {
            _lamviecthannhanService = lamviecthannhanService;
        }

        [HttpGet("{thannhanId}")]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>>> GetThanNhanLamViecAsync(int thannhanId)
        {
            var result = await _lamviecthannhanService.GetThanNhanLamViecAsync(thannhanId);
            return Ok(result);
        }

        [HttpGet("thannhanlamviec/{thannhanId}")]
        public async Task<ActionResult<ServiceResponse<List<TbQuaTrinhLamViecCuaThanNhan>>>> GetThanNhanLamViecsAsync(int thannhanId)
        {
            var result = await _lamviecthannhanService.GetThanNhanLamViecsAsync(thannhanId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>>> CreateThanNhanLamViecAsync(TbQuaTrinhLamViecCuaThanNhan thannhanlamviec)
        {
            var result = await _lamviecthannhanService.CreateThanNhanLamViec(thannhanlamviec);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>>> UpdateThanNhanLamViec(TbQuaTrinhLamViecCuaThanNhan thannhanlamviec)
        {
            var result = await _lamviecthannhanService.UpdateThanNhanLamViec(thannhanlamviec);
            return Ok(result);
        }

        [HttpDelete("{thannhanId}")]
        public async Task<ActionResult<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>>> DeleteThanNhanLamViecAsync(int thannhanId)
        {
            var result = await _lamviecthannhanService.DeleteThanNhanLamViec(thannhanId);
            return Ok(result);
        }
    }
}
