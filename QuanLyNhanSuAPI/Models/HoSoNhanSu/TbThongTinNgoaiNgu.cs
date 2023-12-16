using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbThongTinNgoaiNgu
{
    public int Id { get; set; }

    public string? NgoaiNgu { get; set; }

    public string? BangCap { get; set; }

    public string? KetQua { get; set; }

    public DateTime? NgayCap { get; set; }

    public decimal? KinhPhi { get; set; }

    public bool? ChinhPhu { get; set; }

    public string? NguonKinhPhi { get; set; }

    public string? GhiChu { get; set; }

    public int? IdNv { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
