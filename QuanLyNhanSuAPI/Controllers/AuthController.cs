using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Services.AuthService;
using System.Security.Claims;

namespace QuanLyNhanSuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private DataContext _context;

        public AuthController(IAuthService authService, DataContext dataContext)
        {
            _authService = authService;
            _context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TbTaiKhoan>>>> GetTaiKhoans()
        {
            var result = await _authService.GetTaiKhoans();
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterTaiKhoan request)
        {
            var response = await _authService.Register(
                new TbTaiKhoan
                {
                    IdNv = request.IdNv,
                    Email = request.Email,
                    Role = request.Role
                },
                request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginTaiKhoan request)
        {
            var response = await _authService.Login(request.Email, request.Password);
            if (response == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("change-password")]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword(DoiMatKhau doiMatKhau)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.ChangePassword(doiMatKhau);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


    }
}
