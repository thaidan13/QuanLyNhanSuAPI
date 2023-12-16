using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbHoSoDTO
{
    public int? IdNv { get; set; }

    public string? TenHoSo { get; set; }

    public string? TapTin { get; set; }

    public bool? LoaiHoSo { get; set; }
}
