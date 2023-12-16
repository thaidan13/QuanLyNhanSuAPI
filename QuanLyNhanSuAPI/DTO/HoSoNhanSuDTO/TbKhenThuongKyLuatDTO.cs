using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbKhenThuongKyLuatDTO
{
    public int? IdNv { get; set; }

    public string? HinhThuc { get; set; }

    public DateTime? TuNgay { get; set; }

    public DateTime? DenNgay { get; set; }

    public string? LyDo { get; set; }

    public string? CapQuyetDinh { get; set; }

    public string? SoQuyetDinh { get; set; }

    public string? NguoiKy { get; set; }

    public string? GhiChu { get; set; }

    public string? DinhKem { get; set; }

    public bool? Loai { get; set; }
}
