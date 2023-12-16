using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbOkr
{
    public int IdOkr { get; set; }

    public DateTime Nam { get; set; }

    public string? Quy { get; set; }

    public string TieuDe { get; set; } = null!;

    public string? MoTa { get; set; }

    public string MucTieu { get; set; } = null!;

    public string KieuOkr { get; set; } = null!;

    public int? LaKetQuaThenChot { get; set; }

    public double? Diem { get; set; }

    public int? PhongBan { get; set; }

    public int? NhanVien { get; set; }

    public string? ChuSoHuu { get; set; }

    public bool? KetQua { get; set; }

    public decimal? TrongSo { get; set; }

    public int? DiemThanhCong { get; set; }

    public bool? IsDelete { get; set; }

    [JsonIgnore]
    public virtual DiemThanhCongCuaOkr? DiemThanhCongNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<TbOkr> InverseLaKetQuaThenChotNavigation { get; set; } = new List<TbOkr>();

    public virtual TbOkr? LaKetQuaThenChotNavigation { get; set; }

    public virtual TbThongTinNhanVien? NhanVienNavigation { get; set; }

    public virtual TbPhongBan? PhongBanNavigation { get; set; }
}
