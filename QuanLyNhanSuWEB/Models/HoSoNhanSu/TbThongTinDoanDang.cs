using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbThongTinDoanDang
{
    public int IdNv { get; set; }

    public int? SoTheDang { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayCapThe { get; set; }

    public bool? DaVaoDang { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayVaoDang1 { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayChinhThuc1 { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayVaoDang2 { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayChinhThuc2 { get; set; }

    public string? NguoiThuNhat { get; set; }

    public string? ChucVu1 { get; set; }

    public string? DiaChi1 { get; set; }

    public string? NguoiThuHai { get; set; }

    public string? ChucVu2 { get; set; }

    public string? DiaChi2 { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayVaoDoan { get; set; }

    public bool? DaVaoDoan { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayNhapNgu { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayXuatNgu { get; set; }

    public string? QuanHamChucVuCaoNhat { get; set; }

    public string? DanhHieuDuocPhong { get; set; }

    public string? SoTruong { get; set; }

    public virtual TbThongTinNhanVien IdNvNavigation { get; set; } = null!;
}
