using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbThongTinDoanDangDTO
{
    public int IdNv { get; set; }

    public int? SoTheDang { get; set; }

    public DateTime? NgayCapThe { get; set; }

    public bool? DaVaoDang { get; set; }

    public DateTime? NgayVaoDang1 { get; set; }

    public DateTime? NgayChinhThuc1 { get; set; }

    public DateTime? NgayVaoDang2 { get; set; }

    public DateTime? NgayChinhThuc2 { get; set; }

    public string? NguoiThuNhat { get; set; }

    public string? ChucVu1 { get; set; }

    public string? DiaChi1 { get; set; }

    public string? NguoiThuHai { get; set; }

    public string? ChucVu2 { get; set; }

    public string? DiaChi2 { get; set; }

    public DateTime? NgayVaoDoan { get; set; }

    public bool? DaVaoDoan { get; set; }

    public DateTime? NgayNhapNgu { get; set; }

    public DateTime? NgayXuatNgu { get; set; }

    public string? QuanHamChucVuCaoNhat { get; set; }

    public string? DanhHieuDuocPhong { get; set; }

    public string? SoTruong { get; set; }
}
