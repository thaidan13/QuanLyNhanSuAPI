using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbQuaTrinhLamViecCuaThanNhanDTO
{
    public int? IdThanNhan { get; set; }

    public DateTime? TuNam { get; set; }

    public DateTime? DenNam { get; set; }

    public string? CongViec { get; set; }

    public string? DonVi { get; set; }

    public string? CapBac { get; set; }

    public string? ChucVu { get; set; }

    public string? LoaiChucVu { get; set; }

    public bool? TrongNganh { get; set; }
}
