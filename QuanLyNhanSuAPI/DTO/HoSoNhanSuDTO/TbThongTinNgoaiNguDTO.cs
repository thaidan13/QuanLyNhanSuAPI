using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbThongTinNgoaiNguDTO
{
    public string? NgoaiNgu { get; set; }

    public string? BangCap { get; set; }

    public string? KetQua { get; set; }

    public DateTime? NgayCap { get; set; }

    public decimal? KinhPhi { get; set; }

    public bool? ChinhPhu { get; set; }

    public string? NguonKinhPhi { get; set; }

    public string? GhiChu { get; set; }

    public int? IdNv { get; set; }
}
