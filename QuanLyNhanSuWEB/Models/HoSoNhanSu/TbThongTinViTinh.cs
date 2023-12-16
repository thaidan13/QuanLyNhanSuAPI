using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbThongTinViTinh
{
    public int Id { get; set; }

    public string? BangCap { get; set; }

    public string? SoBang { get; set; }

    public string? NoiDung { get; set; }

    public string? CheDoHoc { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayCap { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? TuNgay { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Denngay { get; set; }

    [DisplayFormat(DataFormatString = "{0:0}")]
    public decimal? KinhPhi { get; set; }

    public string? NguonKinhPhi { get; set; }

    public int? IdNv { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
