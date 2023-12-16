using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbQuaTrinhDaoTao
{
    public int Id { get; set; }

    public DateTime TuNam { get; set; }

    public DateTime? DenNam { get; set; }

    public string CheDoHoc { get; set; } = null!;

    public string LoaiDaoTao { get; set; } = null!;

    public string TruongDaoTao { get; set; } = null!;

    public string? NganhDaoTao { get; set; }

    public string? BangCap { get; set; }

    public string? NoiDung { get; set; }

    public string? KetQua { get; set; }

    public string? ThoiGian { get; set; }

    public string? ChuyenMon { get; set; }

    public string? SoBang { get; set; }

    public DateTime? NgayCap { get; set; }

    public string? QuocGia { get; set; }

    public int? IdNv { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
