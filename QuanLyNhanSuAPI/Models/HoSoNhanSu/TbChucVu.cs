using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbChucVu
{
    public int IdCv { get; set; }

    public string TenChucVu { get; set; } = null!;

    public bool? IsDelete { get; set; }

    [JsonIgnore]
    public virtual ICollection<TbThongTinNhanVien> TbThongTinNhanViens { get; set; } = new List<TbThongTinNhanVien>();
}
