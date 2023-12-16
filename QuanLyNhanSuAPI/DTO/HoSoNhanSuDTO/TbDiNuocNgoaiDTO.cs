using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbDiNuocNgoaiDTO
{
    public DateTime? NgayDi { get; set; }

    public DateTime? NgayVe { get; set; }

    public string? ThoiGian { get; set; }

    public string? QuocGiaDen { get; set; }

    public string? MucDich { get; set; }

    public int? IdNv { get; set; }
}
