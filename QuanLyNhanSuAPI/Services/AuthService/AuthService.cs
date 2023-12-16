using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using System.Security.Claims;
using System.Security.Cryptography;

namespace QuanLyNhanSuAPI.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(DataContext context,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserEmail() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public async Task<string> Login(string email, string password)
        {
            string response = null;
            var user = await _context.TbTaiKhoans.Include(u => u.IdNvNavigation)
                .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            if (user == null)
            {
                //response.Success = false;
                //response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                //response.Success = false;
                //response.Message = "Wrong password.";
            }
            else
            {
                response = user.Role;
            }


            return response;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(DoiMatKhau doiMatKhau)
        {
            var user = await _context.TbTaiKhoans.FirstOrDefaultAsync(p => p.Email == doiMatKhau.Email);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            CreatePasswordHash(doiMatKhau.newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Password has been changed." };
        }

        public async Task<TbTaiKhoan> GetUserByEmail(string email)
        {
            return await _context.TbTaiKhoans.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public async Task<ServiceResponse<int>> Register(TbTaiKhoan user, string password)
        {
            if (await UserExists(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.TbTaiKhoans.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful!" };
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.TbTaiKhoans.AnyAsync(user => user.Email.ToLower()
                 .Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        public async Task<ServiceResponse<List<TbTaiKhoan>>> GetTaiKhoans()
        {
            var response = new ServiceResponse<List<TbTaiKhoan>>
            {
                Data = await _context.TbTaiKhoans.Where(p => p.Email != "quynhngo@gmail.com").ToListAsync()
            };
            return response;
        }
    }
}
