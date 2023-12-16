using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinDoanDangService
{
    public class ThongTinDoanDangService : IThongTinDoanDangService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ThongTinDoanDangService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<TbThongTinDoanDang>> CreateDoanDang(TbThongTinDoanDangDTO doandang)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();
            if (!dbNhanVien.Contains((int)doandang.IdNv))
            {
                return new ServiceResponse<TbThongTinDoanDang> { Success = false, Message = "Dữ liệu không tồn tại!" };
            }
            else
            {
                var newDoanDang = _mapper.Map<TbThongTinDoanDang>(doandang);
                _context.TbThongTinDoanDangs.Add(newDoanDang);
                await _context.SaveChangesAsync();
                return new ServiceResponse<TbThongTinDoanDang> { Data = newDoanDang };
            }
        }

        public async Task<ServiceResponse<TbThongTinDoanDang>> GetDoanDangAsync(int nhanvienId)
        {
            var response = new ServiceResponse<TbThongTinDoanDang>();

            TbThongTinDoanDang doandang = null;

            doandang = await _context.TbThongTinDoanDangs.FirstOrDefaultAsync(p => p.IdNv == nhanvienId);

            if (doandang == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = doandang;
            }

            return response;
        }

        public Task<ServiceResponse<TbThongTinDoanDang>> GetDoanDangNhanVien(int nhanvienId)
        {
            throw new NotImplementedException();
        }//không làm

        public Task<ServiceResponse<List<TbThongTinDoanDang>>> GetDoanDangsAsync()
        {
            throw new NotImplementedException();
        }//không làm

        public async Task<ServiceResponse<TbThongTinDoanDang>> UpdateDoanDang(TbThongTinDoanDang doandang)
        {
            var dbDoanDang = await _context.TbThongTinDoanDangs.FirstOrDefaultAsync(p => p.IdNv == doandang.IdNv);

            if (dbDoanDang == null)
            {
                return new ServiceResponse<TbThongTinDoanDang>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbDoanDang.SoTheDang = doandang.SoTheDang;
            dbDoanDang.NgayCapThe = doandang.NgayCapThe;
            dbDoanDang.DaVaoDang = doandang.DaVaoDang;
            dbDoanDang.NgayVaoDang1 = doandang.NgayVaoDang1;
            dbDoanDang.NgayChinhThuc1 = doandang.NgayChinhThuc1;
            dbDoanDang.NgayVaoDang2 = doandang.NgayVaoDang2;
            dbDoanDang.NgayChinhThuc2 = doandang.NgayChinhThuc2;
            dbDoanDang.NguoiThuNhat = doandang.NguoiThuNhat;
            dbDoanDang.ChucVu1 = doandang.ChucVu1;
            dbDoanDang.DiaChi1 = doandang.DiaChi1;
            dbDoanDang.NguoiThuHai = doandang.NguoiThuHai;
            dbDoanDang.ChucVu2 = doandang.ChucVu2;
            dbDoanDang.DiaChi2 = doandang.DiaChi2;
            dbDoanDang.NgayVaoDoan = doandang.NgayVaoDoan;
            dbDoanDang.DaVaoDoan = doandang.DaVaoDoan;
            dbDoanDang.NgayNhapNgu = doandang.NgayNhapNgu;
            dbDoanDang.NgayXuatNgu = doandang.NgayXuatNgu;
            dbDoanDang.QuanHamChucVuCaoNhat = doandang.QuanHamChucVuCaoNhat;
            dbDoanDang.DanhHieuDuocPhong = doandang.DanhHieuDuocPhong;
            dbDoanDang.SoTruong = doandang.SoTruong;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbThongTinDoanDang> { Data = doandang };
        }
    }
}
