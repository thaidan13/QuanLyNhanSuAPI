using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhanSuAPI.Models.HoSoNhanSu;

public partial class TbThongTinNhanVien
{
    public int IdNv { get; set; }

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string HoKhaiSinh { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string HoThuongDung { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string TenKhaiSinh { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string TenThuongDung { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string BiDanh { get; set; } = null!;

    public string? Cmnd { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayCapCmnd { get; set; }

    public string? NoiCapCmnd { get; set; }

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string TheCanCuoc { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public DateTime NgayCapTheCanCuoc { get; set; }

    public string? SoHoChieu { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayCapHoChieu { get; set; }

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string GioiTinh { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public DateTime NgaySinh { get; set; }

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string HinhAnh { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string QuocTich { get; set; } = null!;

    public string DanToc { get; set; } = null!;

    public string? TonGiao { get; set; }

    public string ThanhPhanGiaDinh { get; set; } = null!;

    public int ChieuCao { get; set; }

    public string? NhanDang { get; set; }

    public string? TenChucDanh { get; set; }

    public string? MoTaCongViec { get; set; }

    public double? BacLuong { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayNghiViec { get; set; }

    public string? LyDoNghiViec { get; set; }

    public string? QueQuanPhuongXa { get; set; }

    public string? QueQuanQuanHuyen { get; set; }

    public string? QueQuanThanhPho { get; set; }

    public string? DienThoaiNha { get; set; }

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string Dtdd { get; set; } = null!;

    //[Remote("CreateNhanVien", "ThongTinNhanVien", ErrorMessage = "Email đã được sử dụng.")]
    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string DiaChiThuongTru { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string PhuongXaThuongTru { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string QuanHuyenThuongTru { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string ThanhPhoThuongTru { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string DiaChiTamTru { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string PhuongXaTamTru { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string QuanHuyenTamTru { get; set; } = null!;

    [Required(ErrorMessage = "Không đươc bỏ trống!")]
    public string ThanhPhoTamTru { get; set; } = null!;

    public int? IdPb { get; set; }

    public int? IdCv { get; set; }

    public bool? IsDelete { get; set; }

    
    public virtual TbChucVu? IdCvNavigation { get; set; }

    
    public virtual TbPhongBan? IdPbNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<TbDiNuocNgoai> TbDiNuocNgoais { get; set; } = new List<TbDiNuocNgoai>();

    [JsonIgnore]
    public virtual ICollection<TbHoSo> TbHoSos { get; set; } = new List<TbHoSo>();

    [JsonIgnore]
    public virtual ICollection<TbKhenThuongKyLuat> TbKhenThuongKyLuats { get; set; } = new List<TbKhenThuongKyLuat>();

    [JsonIgnore]
    public virtual ICollection<TbLichSuBanThanNhanVien> TbLichSuBanThanNhanViens { get; set; } = new List<TbLichSuBanThanNhanVien>();

    [JsonIgnore]
    public virtual ICollection<TbOkr> TbOkrs { get; set; } = new List<TbOkr>();

    [JsonIgnore]
    public virtual ICollection<TbPhongBan> TbPhongBans { get; set; } = new List<TbPhongBan>();

    [JsonIgnore]
    public virtual ICollection<TbQuaTrinhCongTac> TbQuaTrinhCongTacs { get; set; } = new List<TbQuaTrinhCongTac>();

    [JsonIgnore]
    public virtual ICollection<TbQuaTrinhDaoTaoCuMoi> TbQuaTrinhDaoTaoCuMois { get; set; } = new List<TbQuaTrinhDaoTaoCuMoi>();

    [JsonIgnore]
    public virtual ICollection<TbQuaTrinhDaoTaoMoi> TbQuaTrinhDaoTaoMois { get; set; } = new List<TbQuaTrinhDaoTaoMoi>();

    [JsonIgnore]
    public virtual ICollection<TbQuaTrinhDaoTao> TbQuaTrinhDaoTaos { get; set; } = new List<TbQuaTrinhDaoTao>();

    [JsonIgnore]
    public virtual ICollection<TbTaiKhoan> TbTaiKhoans { get; set; } = new List<TbTaiKhoan>();

    [JsonIgnore]
    public virtual ICollection<TbThongTinChinhTri> TbThongTinChinhTris { get; set; } = new List<TbThongTinChinhTri>();

    [JsonIgnore]
    public virtual TbThongTinDoanDang? TbThongTinDoanDang { get; set; }

    [JsonIgnore]
    public virtual ICollection<TbThongTinGiaDinh> TbThongTinGiaDinhs { get; set; } = new List<TbThongTinGiaDinh>();

    [JsonIgnore]
    public virtual ICollection<TbThongTinHopDongLaoDong> TbThongTinHopDongLaoDongs { get; set; } = new List<TbThongTinHopDongLaoDong>();

    [JsonIgnore]
    public virtual ICollection<TbThongTinNgoaiNgu> TbThongTinNgoaiNgus { get; set; } = new List<TbThongTinNgoaiNgu>();

    [JsonIgnore]
    public virtual ICollection<TbThongTinViTinh> TbThongTinViTinhs { get; set; } = new List<TbThongTinViTinh>();
}
