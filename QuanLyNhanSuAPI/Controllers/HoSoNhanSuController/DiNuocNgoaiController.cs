using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.DiNuocNgoaiService;

namespace QuanLyNhanSuAPI.Controllers.HoSoNhanSuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiNuocNgoaiController : ControllerBase
    {
        private readonly IDiNuocNgoaiService _nuocngoaiService;

        public DiNuocNgoaiController(IDiNuocNgoaiService nuocngoaiService)
        {
            _nuocngoaiService = nuocngoaiService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbDiNuocNgoai>>>> GetNuocNgoaisAsync()
        {
            var result = await _nuocngoaiService.GetNuocNgoaisAsync();
            return Ok(result);
        }

        [HttpGet("{nuocngoaiId}")]
        public async Task<ActionResult<ServiceResponse<TbDiNuocNgoai>>> GetNuocNgoaiAsync(int nuocngoaiId)
        {
            var result = await _nuocngoaiService.GetNuocNgoaiAsync(nuocngoaiId);
            return Ok(result);
        }

        [HttpGet("nhanviennuocngoai/{nhanvienId}")]
        public async Task<ActionResult<ServiceResponse<List<TbDiNuocNgoai>>>> GetNuocNgoaiNhanVienAsync(int nhanvienId)
        {
            var result = await _nuocngoaiService.GetNuocNgoaiNhanVien(nhanvienId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbDiNuocNgoai>>> CreateNuocNgoaiAsync(TbDiNuocNgoai nuocngoai)
        {
            var result = await _nuocngoaiService.CreateNuocNgoai(nuocngoai);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TbDiNuocNgoai>>> UpdateNuocNgoaiAsync(TbDiNuocNgoai nuocngoai)
        {
            var result = await _nuocngoaiService.UpdateNuocNgoai(nuocngoai);
            return Ok(result);
        }

        [HttpDelete("{nuocngoaiId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteNuocNgoaiAsync(int nuocngoaiId)
        {
            var result = await _nuocngoaiService.DeleteTbDiNuocNgoai(nuocngoaiId);
            return Ok(result);
        }
    }
}
