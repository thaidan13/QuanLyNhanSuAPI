using System;
using System.Collections.Generic;

namespace QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

public partial class TbThongTinNhanVienDTO
{
    public int Id { get; set; }

    public string HoKhaiSinh { get; set; } = null!;

    public string HoThuongDung { get; set; } = null!;

    public string TenKhaiSinh { get; set; } = null!;

    public string TenThuongDung { get; set; } = null!;

    public string BiDanh { get; set; } = null!;

    public string? Cmnd { get; set; }

    public DateTime? NgayCapCmnd { get; set; }

    public DateTime? NoiCapCmnd { get; set; }

    public string TheCanCuoc { get; set; } = null!;

    public DateTime NgayCapTheCanCuoc { get; set; }

    public string? SoHoChieu { get; set; }

    public DateTime? NgayCapHoChieu { get; set; }

    public string GioiTinh { get; set; } = null!;

    public DateTime NgaySinh { get; set; }

    public string HinhAnh { get; set; } = null!;

    public string QuocTich { get; set; } = null!;

    public string DanToc { get; set; } = null!;

    public string? TonGiao { get; set; }

    public string ThanhPhanGiaDinh { get; set; } = null!;

    public int ChieuCao { get; set; }

    public string? NhanDang { get; set; }

    public string? TenChucDanh { get; set; }

    public string? MoTaCongViec { get; set; }

    public double? BacLuong { get; set; }

    public DateTime? NgayNghiViec { get; set; }

    public string? LyDoNghiViec { get; set; }

    public string? QueQuanPhuongXa { get; set; }

    public string? QueQuanQuanHuyen { get; set; }

    public string? QueQuanThanhPho { get; set; }

    public string? DienThoaiNha { get; set; }

    public string Dtdd { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DiaChiThuongTru { get; set; } = null!;

    public string PhuongXaThuongTru { get; set; } = null!;

    public string QuanHuyenThuongTru { get; set; } = null!;

    public string ThanhPhoThuongTru { get; set; } = null!;

    public string DiaChiTamTru { get; set; } = null!;

    public string PhuongXaTamTru { get; set; } = null!;

    public string QuanHuyenTamTru { get; set; } = null!;

    public string ThanhPhoTamTru { get; set; } = null!;

    public int? IdPb { get; set; }

    public int? IdCv { get; set; }
}
