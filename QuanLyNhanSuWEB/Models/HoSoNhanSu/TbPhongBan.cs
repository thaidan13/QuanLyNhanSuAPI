using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbPhongBan
{
    public int IdPb { get; set; }

    public string TenPhongBan { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public int? QuanLy { get; set; }

    public int? PhongBanCapTren { get; set; }

    [JsonIgnore]
    public virtual ICollection<TbPhongBan> InversePhongBanCapTrenNavigation { get; set; } = new List<TbPhongBan>();

    [JsonIgnore]
    public virtual TbPhongBan? PhongBanCapTrenNavigation { get; set; }

    [JsonIgnore]
    public virtual TbThongTinNhanVien? QuanLyNavigation { get; set; }

    
    public virtual ICollection<TbOkr> TbOkrs { get; set; } = new List<TbOkr>();

    [JsonIgnore]
    public virtual ICollection<TbThongTinNhanVien> TbThongTinNhanViens { get; set; } = new List<TbThongTinNhanVien>();
}
