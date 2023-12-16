using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbHoSo
{
    public int Id { get; set; }

    public int? IdNv { get; set; }

    public string? TenHoSo { get; set; }

    public string? TapTin { get; set; }

    public bool? LoaiHoSo { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
