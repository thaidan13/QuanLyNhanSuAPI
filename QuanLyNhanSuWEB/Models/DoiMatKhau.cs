using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuWEB.Models
{
    public class DoiMatKhau
    {
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string newPassword { get; set; }
    }
}
