
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuAPI.Models
{
    public class LoginTaiKhoan
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
