using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbThongTinViTinhDTO
{
    public string? BangCap { get; set; }

    public string? SoBang { get; set; }

    public string? NoiDung { get; set; }

    public string? CheDoHoc { get; set; }

    public DateTime? NgayCap { get; set; }

    public DateTime? TuNgay { get; set; }

    public DateTime? Denngay { get; set; }

    public decimal? KinhPhi { get; set; }

    public string? NguonKinhPhi { get; set; }

    public int? IdNv { get; set; }
}
