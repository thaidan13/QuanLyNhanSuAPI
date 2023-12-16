using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinHopDongLaoDongService
{
    public class ThongTinHopDongLaoDongService : IThongTinHopDongLaoDongService
    {
        private readonly DataContext _context;

        public ThongTinHopDongLaoDongService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbThongTinHopDongLaoDong>> CreateHopDong(TbThongTinHopDongLaoDong hopdong)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)hopdong.IdNv))
            {
                return new ServiceResponse<TbThongTinHopDongLaoDong> { Success = false, Message = "Dữ liệu không tồn tại!" };
            }
            else
            {
                _context.TbThongTinHopDongLaoDongs.Add(hopdong);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbThongTinHopDongLaoDong> { Data = hopdong };
        }

        public async Task<ServiceResponse<bool>> DeleteHopDong(int hopdongId)
        {
            var dbHopDong = await _context.TbThongTinHopDongLaoDongs.FindAsync(hopdongId);

            if (dbHopDong == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbHopDong.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbThongTinHopDongLaoDong>> GetHopDongAsync(int hopdongId)
        {
            var response = new ServiceResponse<TbThongTinHopDongLaoDong>();

            TbThongTinHopDongLaoDong hopdong = null;

            hopdong = await _context.TbThongTinHopDongLaoDongs.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == hopdongId);

            if (hopdong == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = hopdong;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbThongTinHopDongLaoDong>>> GetHopDongNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbThongTinHopDongLaoDong>>();

            List<TbThongTinHopDongLaoDong> hopdong = null;

            hopdong = await _context.TbThongTinHopDongLaoDongs.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId).ToListAsync();

            if (hopdong == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = hopdong;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbThongTinHopDongLaoDong>>> GetHopDongsAsync()
        {
            var response = new ServiceResponse<List<TbThongTinHopDongLaoDong>>
            {
                Data = await _context.TbThongTinHopDongLaoDongs.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbThongTinHopDongLaoDong>> UpdateHopDong(TbThongTinHopDongLaoDong hopdong)
        {
            var dbHopDong = await _context.TbThongTinHopDongLaoDongs.FirstOrDefaultAsync(p => p.Id == hopdong.Id);

            if (dbHopDong == null)
            {
                return new ServiceResponse<TbThongTinHopDongLaoDong>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbHopDong.LoaiHopDong = hopdong.LoaiHopDong;
            dbHopDong.ThoiHan = hopdong.ThoiHan;
            dbHopDong.ChucDanh = hopdong.ChucDanh;
            dbHopDong.BacLuong = hopdong.BacLuong;
            dbHopDong.HeSoLuong = hopdong.HeSoLuong;
            dbHopDong.NgayKy = hopdong.NgayKy;
            dbHopDong.NguoiKy = hopdong.NguoiKy;
            dbHopDong.NgayThuViec = hopdong.NgayThuViec;
            dbHopDong.NgayChinhThuc = hopdong.NgayChinhThuc;
            dbHopDong.NgayHetHan = hopdong.NgayHetHan;
            dbHopDong.NgayGiaHan = hopdong.NgayGiaHan;
            dbHopDong.FileQuyetDinh = hopdong.FileQuyetDinh;
            dbHopDong.FileHdld = hopdong.FileHdld;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbThongTinHopDongLaoDong> { Data = hopdong };
        }
    }
}
