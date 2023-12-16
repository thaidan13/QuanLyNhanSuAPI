using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Services;
using QuanLyNhanSuAPI.Services.OKRService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OKRController : ControllerBase
    {
        private readonly IOkrServices _okrService;

        public OKRController(IOkrServices okrService)
        {
            _okrService = okrService;
        }

        [HttpGet("admin")]
        public async Task<ActionResult<ServiceResponse<List<TbOkr>>>> GetAdminOKRs()
        {
            var result = await _okrService.GetOKRAdminsAsync();
            return Ok(result);
        }

        [HttpGet("diemokr/{diemid}")]
        public async Task<ActionResult<ServiceResponse<DiemThanhCongCuaOkr>>> GetDiem(int diemid)
        {
            var result = await _okrService.GetDiem(diemid);
            return Ok(result);
        }

        [HttpGet("nhanvien/okr")]
        public async Task<ActionResult<ServiceResponse<List<TbOkr>>>> GetOKRNhanViensAsync(string email)
        {
            var result = await _okrService.GetOKRNhanViensAsync(email);
            return Ok(result);
        }

        [HttpGet("chitietokr")]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> GetOKRNhanVienAsync(int id)
        {
            var result = await _okrService.GetOKRNhanVienAsync(id);
            return Ok(result);
        }

        [HttpGet("soluongokrcon")]
        public async Task<ActionResult<int>> CountChildOKRs(int okrChaId)
        {
            var result = await _okrService.CountChildOKRs(okrChaId);
            return Ok(result);
        }

        [HttpGet("diemthanhcongokr")]
        public async Task<ActionResult<ServiceResponse<DiemThanhCongCuaOkr>>> GetDiemOkrsAsync()
        {
            var result = await _okrService.GetDiemThanhCongs();
            return Ok(result);
        }

        [HttpGet("diemokr")]
        public async Task<ActionResult<ServiceResponse<List<DiemThanhCongCuaOkr>>>> GetDiemOkrs()
        {
            var result = await _okrService.GetDiemThanhCong();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> CreateOKR(TbOkr okr)
        {
            var result = await _okrService.CreateOKR(okr);
            return Ok(result);
        }

        [HttpPut("adminupdateokr")]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> UpdateOKRAdmin(TbOkr okr)
        {
            var result = await _okrService.UpdateOKRAdmin(okr);
            return Ok(result);
        }

        [HttpPut("nhanvienupdateokr")]
        public async Task<ActionResult<ServiceResponse<TbOkr>>> UpdateOKRNhanVien(TbOkr okr)
        {
            var result = await _okrService.UpdateOKRNhanVien(okr);
            return Ok(result);
        }

        [HttpPut("updatediemokr")]
        public async Task<ActionResult<ServiceResponse<DiemThanhCongCuaOkr>>> UpdateDiemOkr(DiemThanhCongCuaOkr diemokr)
        {
            var result = await _okrService.UpdateDiemThanhCong(diemokr);
            return Ok(result);
        }
    }
}
