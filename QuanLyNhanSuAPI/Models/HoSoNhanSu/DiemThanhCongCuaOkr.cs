using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class DiemThanhCongCuaOkr
{
    public int Id { get; set; }

    public double? Diem { get; set; }

    [JsonIgnore]
    public virtual ICollection<TbOkr> TbOkrs { get; set; } = new List<TbOkr>();
}
