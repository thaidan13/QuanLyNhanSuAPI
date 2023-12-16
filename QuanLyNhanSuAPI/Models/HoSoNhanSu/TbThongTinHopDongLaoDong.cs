using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbThongTinHopDongLaoDong
{
    public int Id { get; set; }

    public int? IdNv { get; set; }

    public string? SoHdld { get; set; }

    public string? LoaiHopDong { get; set; }

    public string? ThoiHan { get; set; }

    public string? ChucDanh { get; set; }

    public double? BacLuong { get; set; }

    public double? HeSoLuong { get; set; }

    public DateTime? NgayKy { get; set; }

    public string? NguoiKy { get; set; }

    public DateTime? NgayThuViec { get; set; }

    public DateTime? NgayChinhThuc { get; set; }

    public DateTime? NgayHetHan { get; set; }

    public DateTime? NgayGiaHan { get; set; }

    public string? FileQuyetDinh { get; set; }

    public string? FileHdld { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
