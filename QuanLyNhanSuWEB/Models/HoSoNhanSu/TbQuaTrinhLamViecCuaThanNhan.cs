using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbQuaTrinhLamViecCuaThanNhan
{
    public int Id { get; set; }

    public int? IdThanNhan { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? TuNam { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? DenNam { get; set; }

    public string? CongViec { get; set; }

    public string? DonVi { get; set; }

    public string? CapBac { get; set; }

    public string? ChucVu { get; set; }

    public string? LoaiChucVu { get; set; }

    public bool? TrongNganh { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinGiaDinh? IdThanNhanNavigation { get; set; }
}
