using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbThongTinChinhTri
{
    public int Id { get; set; }

    public string? TrinhDoChinhTri { get; set; }

    public string? CheDoHoc { get; set; }

    public DateTime? TuNgay { get; set; }

    public DateTime? DenNgay { get; set; }

    public decimal? KinhPhi { get; set; }

    public string? NguonKinhPhi { get; set; }

    public DateTime? NgayCap { get; set; }

    public int? IdNv { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
