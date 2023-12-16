using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayKy { get; set; }

    public string? NguoiKy { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayThuViec { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayChinhThuc { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayHetHan { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayGiaHan { get; set; }

    public string? FileQuyetDinh { get; set; }

    public string? FileHdld { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
