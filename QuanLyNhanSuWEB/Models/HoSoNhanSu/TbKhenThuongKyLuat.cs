using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbKhenThuongKyLuat
{
    public int Id { get; set; }

    public int? IdNv { get; set; }

    public string? HinhThuc { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? TuNgay { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? DenNgay { get; set; }

    public string? LyDo { get; set; }

    public string? CapQuyetDinh { get; set; }

    public string? SoQuyetDinh { get; set; }

    public string? NguoiKy { get; set; }

    public string? GhiChu { get; set; }

    public string? DinhKem { get; set; }

    public bool? Loai { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }
}
