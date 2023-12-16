using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuWEB.Models
{
    public class LoginTaiKhoan
    {
        [Required(ErrorMessage = "Không đươc bỏ trống!")]
        [StringLength(50, ErrorMessage = "Không được vượt quá 50 ký tự")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Không đươc bỏ trống!")]
        [StringLength(50, ErrorMessage = "Không được vượt quá 50 ký tự")]
        public string Password { get; set; } = string.Empty;
    }
}
