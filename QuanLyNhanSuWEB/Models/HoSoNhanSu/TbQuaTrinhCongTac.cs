using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbQuaTrinhCongTac
{
    public int Id { get; set; }

    public int? IdNv { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? TuNgay { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? DenNgay { get; set; }

    public string? TenCongTy { get; set; }

    public string? TenPhongBan { get; set; }

    public string? TenDoi { get; set; }

    public string? ChucDanh { get; set; }

    public string? LyDo { get; set; }

    public bool? DangHoatDong { get; set; }

    public string? SoHdld { get; set; }

    public string? LoaiHdld { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayQuyetDinh { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayHieuLuc { get; set; }

    public string? SoQd { get; set; }

    public string? NguoiKy { get; set; }

    public string? FileQuyetDinh { get; set; }

    public bool? Loai { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
