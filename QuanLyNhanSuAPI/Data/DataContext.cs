using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiemThanhCongCuaOkr> DiemThanhCongCuaOkrs { get; set; }

    public virtual DbSet<TbChucVu> TbChucVus { get; set; }

    public virtual DbSet<TbDiNuocNgoai> TbDiNuocNgoais { get; set; }

    public virtual DbSet<TbHoSo> TbHoSos { get; set; }

    public virtual DbSet<TbKhenThuongKyLuat> TbKhenThuongKyLuats { get; set; }

    public virtual DbSet<TbLichSuBanThanNhanVien> TbLichSuBanThanNhanViens { get; set; }

    public virtual DbSet<TbOkr> TbOkrs { get; set; }

    public virtual DbSet<TbPhongBan> TbPhongBans { get; set; }

    public virtual DbSet<TbQuaTrinhCongTac> TbQuaTrinhCongTacs { get; set; }

    public virtual DbSet<TbQuaTrinhDaoTao> TbQuaTrinhDaoTaos { get; set; }

    public virtual DbSet<TbQuaTrinhDaoTaoCuMoi> TbQuaTrinhDaoTaoCuMois { get; set; }

    public virtual DbSet<TbQuaTrinhDaoTaoMoi> TbQuaTrinhDaoTaoMois { get; set; }

    public virtual DbSet<TbQuaTrinhLamViecCuaThanNhan> TbQuaTrinhLamViecCuaThanNhans { get; set; }

    public virtual DbSet<TbTaiKhoan> TbTaiKhoans { get; set; }

    public virtual DbSet<TbThongTinChinhTri> TbThongTinChinhTris { get; set; }

    public virtual DbSet<TbThongTinDoanDang> TbThongTinDoanDangs { get; set; }

    public virtual DbSet<TbThongTinGiaDinh> TbThongTinGiaDinhs { get; set; }

    public virtual DbSet<TbThongTinHopDongLaoDong> TbThongTinHopDongLaoDongs { get; set; }

    public virtual DbSet<TbThongTinNgoaiNgu> TbThongTinNgoaiNgus { get; set; }

    public virtual DbSet<TbThongTinNhanVien> TbThongTinNhanViens { get; set; }

    public virtual DbSet<TbThongTinViTinh> TbThongTinViTinhs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=ADMIN\\SQLEXPRESS;database=QuanLyNhanSuWedTN;trusted_connection=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiemThanhCongCuaOkr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiemThan__3214EC0760339709");

            entity.ToTable("DiemThanhCongCuaOKR");

            entity.Property(e => e.Diem).HasDefaultValueSql("((0.5))");
        });

        modelBuilder.Entity<TbChucVu>(entity =>
        {
            entity.HasKey(e => e.IdCv).HasName("PK__tb_ChucV__B7739095E99E25F7");

            entity.ToTable("tb_ChucVu");

            entity.Property(e => e.IdCv).HasColumnName("IdCV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.TenChucVu).HasMaxLength(100);
        });

        modelBuilder.Entity<TbDiNuocNgoai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_DiNuo__3214EC0755D93C0E");

            entity.ToTable("tb_DiNuocNgoai");

            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.MucDich).HasMaxLength(100);
            entity.Property(e => e.NgayDi).HasColumnType("date");
            entity.Property(e => e.NgayVe).HasColumnType("date");
            entity.Property(e => e.QuocGiaDen).HasMaxLength(100);
            entity.Property(e => e.ThoiGian).HasMaxLength(100);

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbDiNuocNgoais)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_DiNuocN__IdNV__619B8048");
        });

        modelBuilder.Entity<TbHoSo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_HoSo__3214EC07FF9307C9");

            entity.ToTable("tb_HoSo");

            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.TapTin).HasMaxLength(500);
            entity.Property(e => e.TenHoSo).HasMaxLength(150);

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbHoSos)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_HoSo__IdNV__76969D2E");
        });

        modelBuilder.Entity<TbKhenThuongKyLuat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_KhenT__3214EC077E63EDDC");

            entity.ToTable("tb_KhenThuong_KyLuat");

            entity.Property(e => e.CapQuyetDinh).HasMaxLength(150);
            entity.Property(e => e.DenNgay).HasColumnType("date");
            entity.Property(e => e.DinhKem).HasMaxLength(500);
            entity.Property(e => e.GhiChu).HasMaxLength(250);
            entity.Property(e => e.HinhThuc).HasMaxLength(150);
            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.LyDo).HasMaxLength(250);
            entity.Property(e => e.NguoiKy).HasMaxLength(150);
            entity.Property(e => e.SoQuyetDinh)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TuNgay).HasColumnType("date");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbKhenThuongKyLuats)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_KhenThu__IdNV__73BA3083");
        });

        modelBuilder.Entity<TbLichSuBanThanNhanVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_LichS__3214EC07273B86DB");

            entity.ToTable("tb_LichSuBanThanNhanVien");

            entity.Property(e => e.DenNgay).HasColumnType("date");
            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.LamGi).HasMaxLength(250);
            entity.Property(e => e.Odau)
                .HasMaxLength(250)
                .HasColumnName("ODau");
            entity.Property(e => e.TuNgay).HasColumnType("date");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbLichSuBanThanNhanViens)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_LichSuB__IdNV__7F2BE32F");
        });

        modelBuilder.Entity<TbOkr>(entity =>
        {
            entity.HasKey(e => e.IdOkr).HasName("PK__tb_OKR__2A0B92DCF590D442");

            entity.ToTable("tb_OKR");

            entity.Property(e => e.ChuSoHuu).HasMaxLength(150);
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.KieuOkr).HasMaxLength(100);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.MucTieu).HasMaxLength(100);
            entity.Property(e => e.Nam).HasColumnType("date");
            entity.Property(e => e.Quy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TieuDe).HasMaxLength(500);
            entity.Property(e => e.TrongSo).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.DiemThanhCongNavigation).WithMany(p => p.TbOkrs)
                .HasForeignKey(d => d.DiemThanhCong)
                .HasConstraintName("FK__tb_OKR__DiemThan__6DCC4D03");

            entity.HasOne(d => d.LaKetQuaThenChotNavigation).WithMany(p => p.InverseLaKetQuaThenChotNavigation)
                .HasForeignKey(d => d.LaKetQuaThenChot)
                .HasConstraintName("FK__tb_OKR__LaKetQua__6AEFE058");

            entity.HasOne(d => d.NhanVienNavigation).WithMany(p => p.TbOkrs)
                .HasForeignKey(d => d.NhanVien)
                .HasConstraintName("FK__tb_OKR__NhanVien__6CD828CA");

            entity.HasOne(d => d.PhongBanNavigation).WithMany(p => p.TbOkrs)
                .HasForeignKey(d => d.PhongBan)
                .HasConstraintName("FK__tb_OKR__PhongBan__6BE40491");
        });

        modelBuilder.Entity<TbPhongBan>(entity =>
        {
            entity.HasKey(e => e.IdPb).HasName("PK__tb_Phong__B7703B315BD0B293");

            entity.ToTable("tb_PhongBan");

            entity.Property(e => e.IdPb).HasColumnName("IdPB");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.TenPhongBan).HasMaxLength(100);

            entity.HasOne(d => d.PhongBanCapTrenNavigation).WithMany(p => p.InversePhongBanCapTrenNavigation)
                .HasForeignKey(d => d.PhongBanCapTren)
                .HasConstraintName("FK__tb_PhongB__Phong__6166761E");

            entity.HasOne(d => d.QuanLyNavigation).WithMany(p => p.TbPhongBans)
                .HasForeignKey(d => d.QuanLy)
                .HasConstraintName("FK__tb_PhongB__QuanL__607251E5");
        });

        modelBuilder.Entity<TbQuaTrinhCongTac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_QuaTr__3214EC076769272D");

            entity.ToTable("tb_QuaTrinhCongTac");

            entity.HasIndex(e => e.SoQd, "UQ__tb_QuaTr__BC3C524B9779704C").IsUnique();

            entity.Property(e => e.ChucDanh).HasMaxLength(100);
            entity.Property(e => e.DenNgay).HasColumnType("date");
            entity.Property(e => e.FileQuyetDinh).HasMaxLength(500);
            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.LoaiHdld)
                .HasMaxLength(100)
                .HasColumnName("LoaiHDLD");
            entity.Property(e => e.LyDo).HasMaxLength(250);
            entity.Property(e => e.NgayHieuLuc).HasColumnType("date");
            entity.Property(e => e.NgayQuyetDinh).HasColumnType("date");
            entity.Property(e => e.NguoiKy).HasMaxLength(100);
            entity.Property(e => e.SoHdld)
                .HasMaxLength(100)
                .HasColumnName("SoHDLD");
            entity.Property(e => e.SoQd)
                .HasMaxLength(100)
                .HasColumnName("SoQD");
            entity.Property(e => e.TenCongTy).HasMaxLength(100);
            entity.Property(e => e.TenDoi).HasMaxLength(100);
            entity.Property(e => e.TenPhongBan).HasMaxLength(100);
            entity.Property(e => e.TuNgay).HasColumnType("date");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbQuaTrinhCongTacs)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_QuaTrin__IdNV__17036CC0");
        });

        modelBuilder.Entity<TbQuaTrinhDaoTao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_QuaTr__3214EC07027CBA84");

            entity.ToTable("tb_QuaTrinhDaoTao");

            entity.Property(e => e.BangCap).HasMaxLength(100);
            entity.Property(e => e.CheDoHoc).HasMaxLength(100);
            entity.Property(e => e.ChuyenMon).HasMaxLength(100);
            entity.Property(e => e.DenNam).HasColumnType("date");
            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.KetQua).HasMaxLength(50);
            entity.Property(e => e.LoaiDaoTao).HasMaxLength(100);
            entity.Property(e => e.NganhDaoTao).HasMaxLength(100);
            entity.Property(e => e.NgayCap).HasColumnType("date");
            entity.Property(e => e.NoiDung).HasMaxLength(500);
            entity.Property(e => e.QuocGia).HasMaxLength(250);
            entity.Property(e => e.SoBang)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGian).HasMaxLength(50);
            entity.Property(e => e.TruongDaoTao).HasMaxLength(100);
            entity.Property(e => e.TuNam).HasColumnType("date");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbQuaTrinhDaoTaos)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_QuaTrin__IdNV__3E52440B");
        });

        modelBuilder.Entity<TbQuaTrinhDaoTaoCuMoi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_QuaTr__3214EC07151343B8");

            entity.ToTable("tb_QuaTrinhDaoTaoCuMoi");

            entity.Property(e => e.DangBang).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.HetHan).HasColumnType("date");
            entity.Property(e => e.HinhThuc).HasMaxLength(100);
            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.KhoaHoc).HasMaxLength(100);
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayCap).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(100);
            entity.Property(e => e.TenBang).HasMaxLength(100);
            entity.Property(e => e.TruongDonVi)
                .HasMaxLength(100)
                .HasColumnName("Truong_DonVi");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbQuaTrinhDaoTaoCuMois)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_QuaTrin__IdNV__4F47C5E3");
        });

        modelBuilder.Entity<TbQuaTrinhDaoTaoMoi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_QuaTr__3214EC07139862CA");

            entity.ToTable("tb_QuaTrinhDaoTaoMoi");

            entity.Property(e => e.DangBang).HasMaxLength(100);
            entity.Property(e => e.DiaDiem).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(250);
            entity.Property(e => e.HinhThuc).HasMaxLength(100);
            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.KetQua).HasMaxLength(100);
            entity.Property(e => e.KhoaHoc).HasMaxLength(100);
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayCap).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(100);
            entity.Property(e => e.TenBang).HasMaxLength(100);
            entity.Property(e => e.TruongDonVi)
                .HasMaxLength(100)
                .HasColumnName("Truong_DonVi");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbQuaTrinhDaoTaoMois)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_QuaTrin__IdNV__6754599E");
        });

        modelBuilder.Entity<TbQuaTrinhLamViecCuaThanNhan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_QuaTr__3214EC0768EF9789");

            entity.ToTable("tb_QuaTrinhLamViecCuaThanNhan");

            entity.Property(e => e.CapBac).HasMaxLength(100);
            entity.Property(e => e.ChucVu).HasMaxLength(100);
            entity.Property(e => e.CongViec).HasMaxLength(150);
            entity.Property(e => e.DenNam).HasColumnType("date");
            entity.Property(e => e.DonVi).HasMaxLength(150);
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.LoaiChucVu).HasMaxLength(100);
            entity.Property(e => e.TuNam).HasColumnType("date");

            entity.HasOne(d => d.IdThanNhanNavigation).WithMany(p => p.TbQuaTrinhLamViecCuaThanNhans)
                .HasForeignKey(d => d.IdThanNhan)
                .HasConstraintName("FK__tb_QuaTri__IdTha__7C4F7684");
        });

        modelBuilder.Entity<TbTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_TaiKh__3214EC0731F56160");

            entity.ToTable("tb_TaiKhoan");

            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Role).HasMaxLength(150);

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbTaiKhoans)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_TaiKhoa__IdNv__681373AD");
        });

        modelBuilder.Entity<TbThongTinChinhTri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Thong__3214EC07AE914137");

            entity.ToTable("tb_ThongTinChinhTri");

            entity.Property(e => e.CheDoHoc).HasMaxLength(100);
            entity.Property(e => e.DenNgay).HasColumnType("date");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.KinhPhi).HasColumnType("money");
            entity.Property(e => e.NgayCap).HasColumnType("date");
            entity.Property(e => e.NguonKinhPhi).HasMaxLength(100);
            entity.Property(e => e.TrinhDoChinhTri).HasMaxLength(100);
            entity.Property(e => e.TuNgay).HasColumnType("date");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbThongTinChinhTris)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_ThongTi__IdNv__4F7CD00D");
        });

        modelBuilder.Entity<TbThongTinDoanDang>(entity =>
        {
            entity.HasKey(e => e.IdNv).HasName("PK__tb_Thong__B773C9708379E3CA");

            entity.ToTable("tb_ThongTinDoanDang");

            entity.Property(e => e.IdNv)
                .ValueGeneratedNever()
                .HasColumnName("IdNV");
            entity.Property(e => e.ChucVu1).HasMaxLength(100);
            entity.Property(e => e.ChucVu2).HasMaxLength(100);
            entity.Property(e => e.DanhHieuDuocPhong).HasMaxLength(100);
            entity.Property(e => e.DiaChi1).HasMaxLength(250);
            entity.Property(e => e.DiaChi2).HasMaxLength(250);
            entity.Property(e => e.NgayCapThe).HasColumnType("date");
            entity.Property(e => e.NgayChinhThuc1).HasColumnType("date");
            entity.Property(e => e.NgayChinhThuc2).HasColumnType("date");
            entity.Property(e => e.NgayNhapNgu).HasColumnType("date");
            entity.Property(e => e.NgayVaoDang1).HasColumnType("date");
            entity.Property(e => e.NgayVaoDang2).HasColumnType("date");
            entity.Property(e => e.NgayVaoDoan).HasColumnType("date");
            entity.Property(e => e.NgayXuatNgu).HasColumnType("date");
            entity.Property(e => e.NguoiThuHai).HasMaxLength(100);
            entity.Property(e => e.NguoiThuNhat).HasMaxLength(100);
            entity.Property(e => e.QuanHamChucVuCaoNhat).HasMaxLength(100);
            entity.Property(e => e.SoTruong).HasMaxLength(100);

            entity.HasOne(d => d.IdNvNavigation).WithOne(p => p.TbThongTinDoanDang)
                .HasForeignKey<TbThongTinDoanDang>(d => d.IdNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_ThongTi__IdNV__29221CFB");
        });

        modelBuilder.Entity<TbThongTinGiaDinh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Thong__3214EC07F706D245");

            entity.ToTable("tb_ThongTinGiaDinh");

            entity.Property(e => e.DiaChi).HasMaxLength(250);
            entity.Property(e => e.HoTen).HasMaxLength(250);
            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Phuong).HasMaxLength(100);
            entity.Property(e => e.QuanHe).HasMaxLength(250);
            entity.Property(e => e.QuanHuyen).HasMaxLength(100);
            entity.Property(e => e.TinhThanh).HasMaxLength(100);

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbThongTinGiaDinhs)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_ThongTi__IdNV__797309D9");
        });

        modelBuilder.Entity<TbThongTinHopDongLaoDong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Thong__3214EC076A9523FC");

            entity.ToTable("tb_ThongTinHopDongLaoDong");

            entity.HasIndex(e => e.SoHdld, "UQ__tb_Thong__062764664F071968").IsUnique();

            entity.Property(e => e.ChucDanh).HasMaxLength(100);
            entity.Property(e => e.FileHdld)
                .HasMaxLength(500)
                .HasColumnName("FileHDLD");
            entity.Property(e => e.FileQuyetDinh).HasMaxLength(500);
            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.LoaiHopDong).HasMaxLength(100);
            entity.Property(e => e.NgayChinhThuc).HasColumnType("date");
            entity.Property(e => e.NgayGiaHan).HasColumnType("date");
            entity.Property(e => e.NgayHetHan).HasColumnType("date");
            entity.Property(e => e.NgayKy).HasColumnType("date");
            entity.Property(e => e.NgayThuViec).HasColumnType("date");
            entity.Property(e => e.NguoiKy).HasMaxLength(100);
            entity.Property(e => e.SoHdld)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SoHDLD");
            entity.Property(e => e.ThoiHan).HasMaxLength(50);

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbThongTinHopDongLaoDongs)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_ThongTi__IdNV__02FC7413");
        });

        modelBuilder.Entity<TbThongTinNgoaiNgu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Thong__3214EC0751591164");

            entity.ToTable("tb_ThongTinNgoaiNgu");

            entity.Property(e => e.BangCap).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(250);
            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.KetQua).HasMaxLength(100);
            entity.Property(e => e.KinhPhi).HasColumnType("money");
            entity.Property(e => e.NgayCap).HasColumnType("date");
            entity.Property(e => e.NgoaiNgu).HasMaxLength(100);
            entity.Property(e => e.NguonKinhPhi).HasMaxLength(100);

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbThongTinNgoaiNgus)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_ThongTi__IdNV__49C3F6B7");
        });

        modelBuilder.Entity<TbThongTinNhanVien>(entity =>
        {
            entity.HasKey(e => e.IdNv).HasName("PK__tb_Thong__B773C970CE603B85");

            entity.ToTable("tb_ThongTinNhanVien");

            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.BiDanh).HasMaxLength(150);
            entity.Property(e => e.Cmnd)
                .HasMaxLength(100)
                .HasColumnName("CMND");
            entity.Property(e => e.DanToc).HasMaxLength(100);
            entity.Property(e => e.DiaChiTamTru).HasMaxLength(250);
            entity.Property(e => e.DiaChiThuongTru).HasMaxLength(250);
            entity.Property(e => e.DienThoaiNha)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Dtdd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DTDD");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HinhAnh).HasMaxLength(500);
            entity.Property(e => e.HoKhaiSinh).HasMaxLength(250);
            entity.Property(e => e.HoThuongDung).HasMaxLength(250);
            entity.Property(e => e.IdCv).HasColumnName("IdCV");
            entity.Property(e => e.IdPb).HasColumnName("IdPB");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.LyDoNghiViec).HasMaxLength(250);
            entity.Property(e => e.MoTaCongViec).HasMaxLength(250);
            entity.Property(e => e.NgayCapCmnd)
                .HasColumnType("date")
                .HasColumnName("NgayCapCMND");
            entity.Property(e => e.NgayCapHoChieu).HasColumnType("date");
            entity.Property(e => e.NgayCapTheCanCuoc).HasColumnType("date");
            entity.Property(e => e.NgayNghiViec).HasColumnType("date");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.NhanDang).HasMaxLength(100);
            entity.Property(e => e.NoiCapCmnd)
                .HasMaxLength(250)
                .HasColumnName("NoiCapCMND");
            entity.Property(e => e.PhuongXaTamTru).HasMaxLength(250);
            entity.Property(e => e.PhuongXaThuongTru).HasMaxLength(250);
            entity.Property(e => e.QuanHuyenTamTru).HasMaxLength(250);
            entity.Property(e => e.QuanHuyenThuongTru).HasMaxLength(250);
            entity.Property(e => e.QueQuanPhuongXa).HasMaxLength(150);
            entity.Property(e => e.QueQuanQuanHuyen).HasMaxLength(150);
            entity.Property(e => e.QueQuanThanhPho).HasMaxLength(150);
            entity.Property(e => e.QuocTich).HasMaxLength(100);
            entity.Property(e => e.SoHoChieu).HasMaxLength(100);
            entity.Property(e => e.TenChucDanh).HasMaxLength(100);
            entity.Property(e => e.TenKhaiSinh).HasMaxLength(250);
            entity.Property(e => e.TenThuongDung).HasMaxLength(250);
            entity.Property(e => e.ThanhPhanGiaDinh).HasMaxLength(100);
            entity.Property(e => e.ThanhPhoTamTru).HasMaxLength(100);
            entity.Property(e => e.ThanhPhoThuongTru).HasMaxLength(100);
            entity.Property(e => e.TheCanCuoc).HasMaxLength(100);
            entity.Property(e => e.TonGiao).HasMaxLength(100);

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.TbThongTinNhanViens)
                .HasForeignKey(d => d.IdCv)
                .HasConstraintName("FK__tb_ThongTi__IdCV__3B75D760");

            entity.HasOne(d => d.IdPbNavigation).WithMany(p => p.TbThongTinNhanViens)
                .HasForeignKey(d => d.IdPb)
                .HasConstraintName("FK__tb_ThongTi__IdPB__3A81B327");
        });

        modelBuilder.Entity<TbThongTinViTinh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Thong__3214EC072EE3659B");

            entity.ToTable("tb_ThongTinViTinh");

            entity.Property(e => e.BangCap).HasMaxLength(100);
            entity.Property(e => e.CheDoHoc).HasMaxLength(100);
            entity.Property(e => e.Denngay).HasColumnType("date");
            entity.Property(e => e.IdNv).HasColumnName("IdNV");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.KinhPhi).HasColumnType("money");
            entity.Property(e => e.NgayCap).HasColumnType("date");
            entity.Property(e => e.NguonKinhPhi).HasMaxLength(150);
            entity.Property(e => e.NoiDung).HasMaxLength(250);
            entity.Property(e => e.SoBang).HasMaxLength(100);
            entity.Property(e => e.TuNgay).HasColumnType("date");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TbThongTinViTinhs)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("FK__tb_ThongTi__IdNV__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
