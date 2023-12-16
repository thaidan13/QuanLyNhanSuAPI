using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbPhongBanDTO
{
    public int Id { get; set; }
    public string TenPhongBan { get; set; } = null!;
    public int QuanLy { get; set; }
}
