using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbQuaTrinhCongTacDTO
{
    public int? IdNv { get; set; }

    public DateTime? TuNgay { get; set; }

    public DateTime? DenNgay { get; set; }

    public string? TenCongTy { get; set; }

    public string? TenPhongBan { get; set; }

    public string? TenDoi { get; set; }

    public string? ChucDanh { get; set; }

    public string? LyDo { get; set; }

    public bool? DangHoatDong { get; set; }

    public string? SoHdld { get; set; }

    public string? LoaiHdld { get; set; }

    public DateTime? NgayQuyetDinh { get; set; }

    public DateTime? NgayHieuLuc { get; set; }

    public string? SoQd { get; set; }

    public string? NguoiKy { get; set; }

    public string? FileQuyetDinh { get; set; }

    public bool? Loai { get; set; }
}
