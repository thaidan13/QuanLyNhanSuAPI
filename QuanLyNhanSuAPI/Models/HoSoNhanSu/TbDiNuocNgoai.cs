using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbDiNuocNgoai
{
    public int Id { get; set; }

    public DateTime? NgayDi { get; set; }

    public DateTime? NgayVe { get; set; }

    public string? ThoiGian { get; set; }

    public string? QuocGiaDen { get; set; }

    public string? MucDich { get; set; }

    public int? IdNv { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
