using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<List<TbTaiKhoan>>> GetTaiKhoans();
        Task<ServiceResponse<int>> Register(TbTaiKhoan user, string password);
        Task<bool> UserExists(string email);
        Task<string> Login(string email, string password);
        //Task<ServiceResponse<ThongTinSauKhiLogin>> Login(string email, string password);
        Task<ServiceResponse<bool>> ChangePassword(DoiMatKhau doiMatKhau);
        int GetUserId();
        string GetUserEmail();
        Task<TbTaiKhoan> GetUserByEmail(string email);
    }
}
