using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuAPI.Models
{
    public class RegisterTaiKhoan
    {
        [Required]
        public int IdNv { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = null!;
    }
}
