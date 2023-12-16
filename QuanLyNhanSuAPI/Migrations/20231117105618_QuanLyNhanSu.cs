using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanSuAPI.Migrations
{
    /// <inheritdoc />
    public partial class QuanLyNhanSu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiemThanhCongCuaOKR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diem = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0.5))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DiemThan__3214EC0760339709", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ChucVu",
                columns: table => new
                {
                    IdCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_ChucV__B7739095E99E25F7", x => x.IdCV);
                });

            migrationBuilder.CreateTable(
                name: "tb_DiNuocNgoai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDi = table.Column<DateTime>(type: "date", nullable: true),
                    NgayVe = table.Column<DateTime>(type: "date", nullable: true),
                    ThoiGian = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QuocGiaDen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MucDich = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_DiNuo__3214EC0755D93C0E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_HoSo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    TenHoSo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TapTin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LoaiHoSo = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_HoSo__3214EC07FF9307C9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_KhenThuong_KyLuat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    HinhThuc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TuNgay = table.Column<DateTime>(type: "date", nullable: true),
                    DenNgay = table.Column<DateTime>(type: "date", nullable: true),
                    LyDo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CapQuyetDinh = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SoQuyetDinh = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NguoiKy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DinhKem = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Loai = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_KhenT__3214EC077E63EDDC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_LichSuBanThanNhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    TuNgay = table.Column<DateTime>(type: "date", nullable: true),
                    DenNgay = table.Column<DateTime>(type: "date", nullable: true),
                    LamGi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ODau = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_LichS__3214EC07273B86DB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_OKR",
                columns: table => new
                {
                    IdOkr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nam = table.Column<DateTime>(type: "date", nullable: false),
                    Quy = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    TieuDe = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MucTieu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KieuOkr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LaKetQuaThenChot = table.Column<int>(type: "int", nullable: true),
                    Diem = table.Column<double>(type: "float", nullable: true),
                    PhongBan = table.Column<int>(type: "int", nullable: true),
                    NhanVien = table.Column<int>(type: "int", nullable: true),
                    ChuSoHuu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    KetQua = table.Column<bool>(type: "bit", nullable: true),
                    TrongSo = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    DiemThanhCong = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_OKR__2A0B92DCF590D442", x => x.IdOkr);
                    table.ForeignKey(
                        name: "FK__tb_OKR__DiemThan__6DCC4D03",
                        column: x => x.DiemThanhCong,
                        principalTable: "DiemThanhCongCuaOKR",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__tb_OKR__LaKetQua__6AEFE058",
                        column: x => x.LaKetQuaThenChot,
                        principalTable: "tb_OKR",
                        principalColumn: "IdOkr");
                });

            migrationBuilder.CreateTable(
                name: "tb_PhongBan",
                columns: table => new
                {
                    IdPB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhongBan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    QuanLy = table.Column<int>(type: "int", nullable: true),
                    PhongBanCapTren = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_Phong__B7703B315BD0B293", x => x.IdPB);
                    table.ForeignKey(
                        name: "FK__tb_PhongB__Phong__6166761E",
                        column: x => x.PhongBanCapTren,
                        principalTable: "tb_PhongBan",
                        principalColumn: "IdPB");
                });

            migrationBuilder.CreateTable(
                name: "tb_ThongTinNhanVien",
                columns: table => new
                {
                    IdNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoKhaiSinh = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HoThuongDung = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TenKhaiSinh = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TenThuongDung = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BiDanh = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayCapCMND = table.Column<DateTime>(type: "date", nullable: true),
                    NoiCapCMND = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TheCanCuoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayCapTheCanCuoc = table.Column<DateTime>(type: "date", nullable: false),
                    SoHoChieu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayCapHoChieu = table.Column<DateTime>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    QuocTich = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DanToc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TonGiao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThanhPhanGiaDinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChieuCao = table.Column<int>(type: "int", nullable: false),
                    NhanDang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenChucDanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MoTaCongViec = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BacLuong = table.Column<double>(type: "float", nullable: true),
                    NgayNghiViec = table.Column<DateTime>(type: "date", nullable: true),
                    LyDoNghiViec = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    QueQuanPhuongXa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    QueQuanQuanHuyen = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    QueQuanThanhPho = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DienThoaiNha = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DTDD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DiaChiThuongTru = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhuongXaThuongTru = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    QuanHuyenThuongTru = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ThanhPhoThuongTru = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChiTamTru = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhuongXaTamTru = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    QuanHuyenTamTru = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ThanhPhoTamTru = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdPB = table.Column<int>(type: "int", nullable: true),
                    IdCV = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_Thong__B773C970CE603B85", x => x.IdNV);
                    table.ForeignKey(
                        name: "FK__tb_ThongTi__IdCV__3B75D760",
                        column: x => x.IdCV,
                        principalTable: "tb_ChucVu",
                        principalColumn: "IdCV");
                    table.ForeignKey(
                        name: "FK__tb_ThongTi__IdPB__3A81B327",
                        column: x => x.IdPB,
                        principalTable: "tb_PhongBan",
                        principalColumn: "IdPB");
                });

            migrationBuilder.CreateTable(
                name: "tb_QuaTrinhCongTac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    TuNgay = table.Column<DateTime>(type: "date", nullable: true),
                    DenNgay = table.Column<DateTime>(type: "date", nullable: true),
                    TenCongTy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenPhongBan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenDoi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChucDanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LyDo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DangHoatDong = table.Column<bool>(type: "bit", nullable: true),
                    SoHDLD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LoaiHDLD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayQuyetDinh = table.Column<DateTime>(type: "date", nullable: true),
                    NgayHieuLuc = table.Column<DateTime>(type: "date", nullable: true),
                    SoQD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NguoiKy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileQuyetDinh = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Loai = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_QuaTr__3214EC076769272D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_QuaTrin__IdNV__17036CC0",
                        column: x => x.IdNV,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_QuaTrinhDaoTao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuNam = table.Column<DateTime>(type: "date", nullable: false),
                    DenNam = table.Column<DateTime>(type: "date", nullable: true),
                    CheDoHoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiDaoTao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TruongDaoTao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NganhDaoTao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BangCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    KetQua = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThoiGian = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChuyenMon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoBang = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NgayCap = table.Column<DateTime>(type: "date", nullable: true),
                    QuocGia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_QuaTr__3214EC07027CBA84", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_QuaTrin__IdNV__3E52440B",
                        column: x => x.IdNV,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_QuaTrinhDaoTaoCuMoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoaHoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Truong_DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HoanTat = table.Column<bool>(type: "bit", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "date", nullable: true),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HinhThuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenBang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoBang = table.Column<int>(type: "int", nullable: true),
                    DangBang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayCap = table.Column<DateTime>(type: "date", nullable: true),
                    HetHan = table.Column<DateTime>(type: "date", nullable: true),
                    LoaiDaoTao = table.Column<bool>(type: "bit", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_QuaTr__3214EC07151343B8", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_QuaTrin__IdNV__4F47C5E3",
                        column: x => x.IdNV,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_QuaTrinhDaoTaoMoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoaHoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Truong_DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HoanTat = table.Column<bool>(type: "bit", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "date", nullable: true),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HinhThuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenBang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoBang = table.Column<int>(type: "int", nullable: true),
                    DangBang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayCap = table.Column<DateTime>(type: "date", nullable: true),
                    HetHan = table.Column<bool>(type: "bit", nullable: true),
                    KetQua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaDiem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_QuaTr__3214EC07139862CA", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_QuaTrin__IdNV__6754599E",
                        column: x => x.IdNV,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_TaiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Role = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IdNv = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_TaiKh__3214EC0731F56160", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_TaiKhoa__IdNv__681373AD",
                        column: x => x.IdNv,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_ThongTinChinhTri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrinhDoChinhTri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CheDoHoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TuNgay = table.Column<DateTime>(type: "date", nullable: true),
                    DenNgay = table.Column<DateTime>(type: "date", nullable: true),
                    KinhPhi = table.Column<decimal>(type: "money", nullable: true),
                    NguonKinhPhi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayCap = table.Column<DateTime>(type: "date", nullable: true),
                    IdNv = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_Thong__3214EC07AE914137", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_ThongTi__IdNv__4F7CD00D",
                        column: x => x.IdNv,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_ThongTinDoanDang",
                columns: table => new
                {
                    IdNV = table.Column<int>(type: "int", nullable: false),
                    SoTheDang = table.Column<int>(type: "int", nullable: true),
                    NgayCapThe = table.Column<DateTime>(type: "date", nullable: true),
                    DaVaoDang = table.Column<bool>(type: "bit", nullable: true),
                    NgayVaoDang1 = table.Column<DateTime>(type: "date", nullable: true),
                    NgayChinhThuc1 = table.Column<DateTime>(type: "date", nullable: true),
                    NgayVaoDang2 = table.Column<DateTime>(type: "date", nullable: true),
                    NgayChinhThuc2 = table.Column<DateTime>(type: "date", nullable: true),
                    NguoiThuNhat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChucVu1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChi1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NguoiThuHai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChucVu2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChi2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NgayVaoDoan = table.Column<DateTime>(type: "date", nullable: true),
                    DaVaoDoan = table.Column<bool>(type: "bit", nullable: true),
                    NgayNhapNgu = table.Column<DateTime>(type: "date", nullable: true),
                    NgayXuatNgu = table.Column<DateTime>(type: "date", nullable: true),
                    QuanHamChucVuCaoNhat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DanhHieuDuocPhong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoTruong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_Thong__B773C9708379E3CA", x => x.IdNV);
                    table.ForeignKey(
                        name: "FK__tb_ThongTi__IdNV__29221CFB",
                        column: x => x.IdNV,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_ThongTinGiaDinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    QuanHe = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phuong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QuanHuyen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TinhThanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConSong = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_Thong__3214EC07F706D245", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_ThongTi__IdNV__797309D9",
                        column: x => x.IdNV,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_ThongTinHopDongLaoDong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    SoHDLD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LoaiHopDong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThoiHan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChucDanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BacLuong = table.Column<double>(type: "float", nullable: true),
                    HeSoLuong = table.Column<double>(type: "float", nullable: true),
                    NgayKy = table.Column<DateTime>(type: "date", nullable: true),
                    NguoiKy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayThuViec = table.Column<DateTime>(type: "date", nullable: true),
                    NgayChinhThuc = table.Column<DateTime>(type: "date", nullable: true),
                    NgayHetHan = table.Column<DateTime>(type: "date", nullable: true),
                    NgayGiaHan = table.Column<DateTime>(type: "date", nullable: true),
                    FileQuyetDinh = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileHDLD = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_Thong__3214EC076A9523FC", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_ThongTi__IdNV__02FC7413",
                        column: x => x.IdNV,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_ThongTinNgoaiNgu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgoaiNgu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BangCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KetQua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayCap = table.Column<DateTime>(type: "date", nullable: true),
                    KinhPhi = table.Column<decimal>(type: "money", nullable: true),
                    ChinhPhu = table.Column<bool>(type: "bit", nullable: true),
                    NguonKinhPhi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_Thong__3214EC0751591164", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_ThongTi__IdNV__49C3F6B7",
                        column: x => x.IdNV,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_ThongTinViTinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BangCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoBang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CheDoHoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayCap = table.Column<DateTime>(type: "date", nullable: true),
                    TuNgay = table.Column<DateTime>(type: "date", nullable: true),
                    Denngay = table.Column<DateTime>(type: "date", nullable: true),
                    KinhPhi = table.Column<decimal>(type: "money", nullable: true),
                    NguonKinhPhi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IdNV = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_Thong__3214EC072EE3659B", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_ThongTi__IdNV__4CA06362",
                        column: x => x.IdNV,
                        principalTable: "tb_ThongTinNhanVien",
                        principalColumn: "IdNV");
                });

            migrationBuilder.CreateTable(
                name: "tb_QuaTrinhLamViecCuaThanNhan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdThanNhan = table.Column<int>(type: "int", nullable: true),
                    TuNam = table.Column<DateTime>(type: "date", nullable: true),
                    DenNam = table.Column<DateTime>(type: "date", nullable: true),
                    CongViec = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CapBac = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LoaiChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrongNganh = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_QuaTr__3214EC0768EF9789", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tb_QuaTri__IdTha__7C4F7684",
                        column: x => x.IdThanNhan,
                        principalTable: "tb_ThongTinGiaDinh",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_DiNuocNgoai_IdNV",
                table: "tb_DiNuocNgoai",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "IX_tb_HoSo_IdNV",
                table: "tb_HoSo",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "IX_tb_KhenThuong_KyLuat_IdNV",
                table: "tb_KhenThuong_KyLuat",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "IX_tb_LichSuBanThanNhanVien_IdNV",
                table: "tb_LichSuBanThanNhanVien",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OKR_DiemThanhCong",
                table: "tb_OKR",
                column: "DiemThanhCong");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OKR_LaKetQuaThenChot",
                table: "tb_OKR",
                column: "LaKetQuaThenChot");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OKR_NhanVien",
                table: "tb_OKR",
                column: "NhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OKR_PhongBan",
                table: "tb_OKR",
                column: "PhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_tb_PhongBan_PhongBanCapTren",
                table: "tb_PhongBan",
                column: "PhongBanCapTren");

            migrationBuilder.CreateIndex(
                name: "IX_tb_PhongBan_QuanLy",
                table: "tb_PhongBan",
                column: "QuanLy");

            migrationBuilder.CreateIndex(
                name: "IX_tb_QuaTrinhCongTac_IdNV",
                table: "tb_QuaTrinhCongTac",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "UQ__tb_QuaTr__BC3C524B9779704C",
                table: "tb_QuaTrinhCongTac",
                column: "SoQD",
                unique: true,
                filter: "[SoQD] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_QuaTrinhDaoTao_IdNV",
                table: "tb_QuaTrinhDaoTao",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "IX_tb_QuaTrinhDaoTaoCuMoi_IdNV",
                table: "tb_QuaTrinhDaoTaoCuMoi",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "IX_tb_QuaTrinhDaoTaoMoi_IdNV",
                table: "tb_QuaTrinhDaoTaoMoi",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "IX_tb_QuaTrinhLamViecCuaThanNhan_IdThanNhan",
                table: "tb_QuaTrinhLamViecCuaThanNhan",
                column: "IdThanNhan");

            migrationBuilder.CreateIndex(
                name: "IX_tb_TaiKhoan_IdNv",
                table: "tb_TaiKhoan",
                column: "IdNv");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ThongTinChinhTri_IdNv",
                table: "tb_ThongTinChinhTri",
                column: "IdNv");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ThongTinGiaDinh_IdNV",
                table: "tb_ThongTinGiaDinh",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ThongTinHopDongLaoDong_IdNV",
                table: "tb_ThongTinHopDongLaoDong",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "UQ__tb_Thong__062764664F071968",
                table: "tb_ThongTinHopDongLaoDong",
                column: "SoHDLD",
                unique: true,
                filter: "[SoHDLD] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ThongTinNgoaiNgu_IdNV",
                table: "tb_ThongTinNgoaiNgu",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ThongTinNhanVien_IdCV",
                table: "tb_ThongTinNhanVien",
                column: "IdCV");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ThongTinNhanVien_IdPB",
                table: "tb_ThongTinNhanVien",
                column: "IdPB");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ThongTinViTinh_IdNV",
                table: "tb_ThongTinViTinh",
                column: "IdNV");

            migrationBuilder.AddForeignKey(
                name: "FK__tb_DiNuocN__IdNV__619B8048",
                table: "tb_DiNuocNgoai",
                column: "IdNV",
                principalTable: "tb_ThongTinNhanVien",
                principalColumn: "IdNV");

            migrationBuilder.AddForeignKey(
                name: "FK__tb_HoSo__IdNV__76969D2E",
                table: "tb_HoSo",
                column: "IdNV",
                principalTable: "tb_ThongTinNhanVien",
                principalColumn: "IdNV");

            migrationBuilder.AddForeignKey(
                name: "FK__tb_KhenThu__IdNV__73BA3083",
                table: "tb_KhenThuong_KyLuat",
                column: "IdNV",
                principalTable: "tb_ThongTinNhanVien",
                principalColumn: "IdNV");

            migrationBuilder.AddForeignKey(
                name: "FK__tb_LichSuB__IdNV__7F2BE32F",
                table: "tb_LichSuBanThanNhanVien",
                column: "IdNV",
                principalTable: "tb_ThongTinNhanVien",
                principalColumn: "IdNV");

            migrationBuilder.AddForeignKey(
                name: "FK__tb_OKR__NhanVien__6CD828CA",
                table: "tb_OKR",
                column: "NhanVien",
                principalTable: "tb_ThongTinNhanVien",
                principalColumn: "IdNV");

            migrationBuilder.AddForeignKey(
                name: "FK__tb_OKR__PhongBan__6BE40491",
                table: "tb_OKR",
                column: "PhongBan",
                principalTable: "tb_PhongBan",
                principalColumn: "IdPB");

            migrationBuilder.AddForeignKey(
                name: "FK__tb_PhongB__QuanL__607251E5",
                table: "tb_PhongBan",
                column: "QuanLy",
                principalTable: "tb_ThongTinNhanVien",
                principalColumn: "IdNV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__tb_PhongB__QuanL__607251E5",
                table: "tb_PhongBan");

            migrationBuilder.DropTable(
                name: "tb_DiNuocNgoai");

            migrationBuilder.DropTable(
                name: "tb_HoSo");

            migrationBuilder.DropTable(
                name: "tb_KhenThuong_KyLuat");

            migrationBuilder.DropTable(
                name: "tb_LichSuBanThanNhanVien");

            migrationBuilder.DropTable(
                name: "tb_OKR");

            migrationBuilder.DropTable(
                name: "tb_QuaTrinhCongTac");

            migrationBuilder.DropTable(
                name: "tb_QuaTrinhDaoTao");

            migrationBuilder.DropTable(
                name: "tb_QuaTrinhDaoTaoCuMoi");

            migrationBuilder.DropTable(
                name: "tb_QuaTrinhDaoTaoMoi");

            migrationBuilder.DropTable(
                name: "tb_QuaTrinhLamViecCuaThanNhan");

            migrationBuilder.DropTable(
                name: "tb_TaiKhoan");

            migrationBuilder.DropTable(
                name: "tb_ThongTinChinhTri");

            migrationBuilder.DropTable(
                name: "tb_ThongTinDoanDang");

            migrationBuilder.DropTable(
                name: "tb_ThongTinHopDongLaoDong");

            migrationBuilder.DropTable(
                name: "tb_ThongTinNgoaiNgu");

            migrationBuilder.DropTable(
                name: "tb_ThongTinViTinh");

            migrationBuilder.DropTable(
                name: "DiemThanhCongCuaOKR");

            migrationBuilder.DropTable(
                name: "tb_ThongTinGiaDinh");

            migrationBuilder.DropTable(
                name: "tb_ThongTinNhanVien");

            migrationBuilder.DropTable(
                name: "tb_ChucVu");

            migrationBuilder.DropTable(
                name: "tb_PhongBan");
        }
    }
}
