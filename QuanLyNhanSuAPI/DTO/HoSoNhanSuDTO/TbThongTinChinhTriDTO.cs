using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbThongTinChinhTriDTO
{
    public string? TrinhDoChinhTri { get; set; }

    public string? CheDoHoc { get; set; }

    public DateTime? TuNgay { get; set; }

    public DateTime? DenNgay { get; set; }

    public decimal? KinhPhi { get; set; }

    public string? NguonKinhPhi { get; set; }

    public DateTime? NgayCap { get; set; }

    public int? IdNv { get; set; }
}
