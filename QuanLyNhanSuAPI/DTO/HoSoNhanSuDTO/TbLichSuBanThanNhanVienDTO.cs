using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbLichSuBanThanNhanVienDTO
{
    public int? IdNv { get; set; }

    public DateTime? TuNgay { get; set; }

    public DateTime? DenNgay { get; set; }

    public string? LamGi { get; set; }

    public string? Odau { get; set; }
}
