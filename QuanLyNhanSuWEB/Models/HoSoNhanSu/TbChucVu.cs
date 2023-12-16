using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbChucVu
{
    public int IdCv { get; set; }

    public string TenChucVu { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public virtual ICollection<TbThongTinNhanVien> TbThongTinNhanViens { get; set; } = new List<TbThongTinNhanVien>();
}
