using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbQuaTrinhDaoTaoCuMoi
{
    public int Id { get; set; }

    public string? KhoaHoc { get; set; }

    public string? TruongDonVi { get; set; }

    public bool? HoanTat { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayBatDau { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayKetThuc { get; set; }

    public string? SoQuyetDinh { get; set; }

    public string? HinhThuc { get; set; }

    public string? TenBang { get; set; }

    public int? SoBang { get; set; }

    public string? DangBang { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayCap { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? HetHan { get; set; }

    public bool? LoaiDaoTao { get; set; }

    public string? GhiChu { get; set; }

    public int? IdNv { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
