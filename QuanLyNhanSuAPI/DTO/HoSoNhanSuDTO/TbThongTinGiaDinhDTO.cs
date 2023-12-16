using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbThongTinGiaDinhDTO
{
    public int? IdNv { get; set; }

    public string? HoTen { get; set; }

    public string? QuanHe { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Phuong { get; set; }

    public string? QuanHuyen { get; set; }

    public string? TinhThanh { get; set; }

    public bool? ConSong { get; set; }
}
