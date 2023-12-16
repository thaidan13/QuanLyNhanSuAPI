using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbTaiKhoan
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public DateTime? DateCreated { get; set; }

    public string? Role { get; set; }

    public int? IdNv { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
