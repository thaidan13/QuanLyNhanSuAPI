using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbThongTinGiaDinh
{
    public int Id { get; set; }

    public int? IdNv { get; set; }

    public string? HoTen { get; set; }

    public string? QuanHe { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Phuong { get; set; }

    public string? QuanHuyen { get; set; }

    public string? TinhThanh { get; set; }

    public bool? ConSong { get; set; }

    public bool? IsDelete { get; set; }

    public virtual TbThongTinNhanVien? IdNvNavigation { get; set; }

    public virtual ICollection<TbQuaTrinhLamViecCuaThanNhan> TbQuaTrinhLamViecCuaThanNhans { get; set; } = new List<TbQuaTrinhLamViecCuaThanNhan>();
}
