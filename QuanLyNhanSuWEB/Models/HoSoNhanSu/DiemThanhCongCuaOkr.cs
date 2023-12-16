using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class DiemThanhCongCuaOkr
{
    public int Id { get; set; }

    public double? Diem { get; set; }

    public virtual ICollection<TbOkr> TbOkrs { get; set; } = new List<TbOkr>();
}
