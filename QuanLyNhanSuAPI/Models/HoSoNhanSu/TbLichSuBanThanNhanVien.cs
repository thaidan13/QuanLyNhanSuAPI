using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbLichSuBanThanNhanVien
{
    public int Id { get; set; }

    public int? IdNv { get; set; }

    public DateTime? TuNgay { get; set; }

    public DateTime? DenNgay { get; set; }

    public string? LamGi { get; set; }

    public string? Odau { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
