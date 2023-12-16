using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinNhanVienService
{
    public class ThongTinNhanVienService : IThongTinNhanVienService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ThongTinNhanVienService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<TbThongTinNhanVien>> CreateNhanVien(TbThongTinNhanVien nhanvien)
        {
            
            if (nhanvien.IdCv == 0 || nhanvien.IdPb == 0)
            {
                return new ServiceResponse<TbThongTinNhanVien> { Success = false, Message = "Dữ liệu Không phù hợp!" };
            }
            bool isUnique = !_context.TbThongTinNhanViens.Any(x => x.Email == nhanvien.Email);
            if(isUnique == false)
            {
                return new ServiceResponse<TbThongTinNhanVien> { Success = false, Message = "Dữ liệu Không phù hợp!" };
            }
            _context.TbThongTinNhanViens.Add(nhanvien);
            await _context.SaveChangesAsync();
            return new ServiceResponse<TbThongTinNhanVien> { Data = nhanvien };
        }

        public async Task<ServiceResponse<bool>> DeleteNhanVien(int nhanvienId)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.FindAsync(nhanvienId);

            if (dbNhanVien == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbNhanVien.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbThongTinNhanVien>> GetNhanVienAsync(int nhanvienId)
        {
            var response = new ServiceResponse<TbThongTinNhanVien>();

            TbThongTinNhanVien nhanvien = null;

            nhanvien = await _context.TbThongTinNhanViens.Where(p => (bool)!p.IsDelete).Include(p => p.IdCvNavigation).Include(p => p.IdPbNavigation).FirstOrDefaultAsync(p => p.IdNv == nhanvienId);

            if (nhanvien == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = nhanvien;
            }

            return response;


        }

        public async Task<ServiceResponse<List<TbThongTinNhanVien>>> GetNhanViensAsync()
        {
            var response = new ServiceResponse<List<TbThongTinNhanVien>>
            {
                Data = await _context.TbThongTinNhanViens.Where(p => (bool)!p.IsDelete).Include(p => p.IdCvNavigation).Include(p => p.IdPbNavigation).ToListAsync()
            };
            return response;
        }

        //public async Task<ServiceResponse<IEnumerable<TbThongTinNhanVien>>> GetPagedEntities(int pageNumber, int pageSize)
        //{
        //    var response = new ServiceResponse<IEnumerable<TbThongTinNhanVien>>
        //    {
        //        Data = await _context.TbThongTinNhanViens.OrderBy(x => x.IdNv).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync()
        //    };
        //    return response;
        //}

        //public async Task<ServiceResponse<int>> TotalEntityCount()
        //{
        //    var response = new ServiceResponse<int>
        //    {
        //        Data = await _context.TbThongTinNhanViens.CountAsync()
        //    };
        //    return response;
        //}

        public async Task<ServiceResponse<TbThongTinNhanVien>> UpdateNhanVien(TbThongTinNhanVien nhanvien)
        {
            //throw new NotImplementedException();
            var dbNhanVien = await _context.TbThongTinNhanViens.FirstOrDefaultAsync(p => p.IdNv == nhanvien.IdNv);

            if(dbNhanVien == null)
            {
                return new ServiceResponse<TbThongTinNhanVien>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbNhanVien.HoKhaiSinh = nhanvien.HoKhaiSinh;
            dbNhanVien.HoThuongDung = nhanvien.HoThuongDung;
            dbNhanVien.TenKhaiSinh = nhanvien.TenKhaiSinh;
            dbNhanVien.TenThuongDung = nhanvien.TenThuongDung;
            dbNhanVien.BiDanh = nhanvien.BiDanh;
            dbNhanVien.Cmnd = nhanvien.Cmnd;
            dbNhanVien.NgayCapCmnd = nhanvien.NgayCapCmnd;
            dbNhanVien.NoiCapCmnd = nhanvien.NoiCapCmnd;
            dbNhanVien.TheCanCuoc = nhanvien.TheCanCuoc;
            dbNhanVien.NgayCapTheCanCuoc = nhanvien.NgayCapTheCanCuoc;
            dbNhanVien.SoHoChieu = nhanvien.SoHoChieu;
            dbNhanVien.NgayCapHoChieu = nhanvien.NgayCapHoChieu;
            dbNhanVien.GioiTinh = nhanvien.GioiTinh;
            dbNhanVien.NgaySinh = nhanvien.NgaySinh;
            dbNhanVien.HinhAnh = nhanvien.HinhAnh;
            dbNhanVien.QuocTich = nhanvien.QuocTich;
            dbNhanVien.DanToc = nhanvien.DanToc;
            dbNhanVien.TonGiao = nhanvien.TonGiao;
            dbNhanVien.ThanhPhanGiaDinh = nhanvien.ThanhPhanGiaDinh;
            dbNhanVien.ChieuCao = nhanvien.ChieuCao;
            dbNhanVien.NhanDang = nhanvien.NhanDang;
            dbNhanVien.TenChucDanh = nhanvien.TenChucDanh;
            dbNhanVien.MoTaCongViec = nhanvien.MoTaCongViec;
            dbNhanVien.BacLuong = nhanvien.BacLuong;
            dbNhanVien.NgayNghiViec = nhanvien.NgayNghiViec;
            dbNhanVien.LyDoNghiViec = nhanvien.LyDoNghiViec;
            dbNhanVien.QueQuanPhuongXa = nhanvien.QueQuanPhuongXa;
            dbNhanVien.QueQuanQuanHuyen = nhanvien.QueQuanQuanHuyen;
            dbNhanVien.QueQuanThanhPho = nhanvien.QueQuanThanhPho;
            dbNhanVien.DienThoaiNha = nhanvien.DienThoaiNha;
            dbNhanVien.Dtdd = nhanvien.Dtdd;
            dbNhanVien.Email = nhanvien.Email;
            dbNhanVien.DiaChiThuongTru = nhanvien.DiaChiThuongTru;
            dbNhanVien.PhuongXaThuongTru = nhanvien.PhuongXaThuongTru;
            dbNhanVien.QuanHuyenThuongTru = nhanvien.QuanHuyenThuongTru;
            dbNhanVien.ThanhPhoThuongTru = nhanvien.ThanhPhoThuongTru;
            dbNhanVien.DiaChiTamTru = nhanvien.DiaChiTamTru;
            dbNhanVien.PhuongXaTamTru = nhanvien.PhuongXaTamTru;
            dbNhanVien.QuanHuyenTamTru = nhanvien.QuanHuyenTamTru;
            dbNhanVien.ThanhPhoTamTru = nhanvien.ThanhPhoTamTru;
            dbNhanVien.IdPb = nhanvien.IdPb;
            dbNhanVien.IdCv = nhanvien.IdCv;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbThongTinNhanVien> { Data = nhanvien };
        }
    }
}