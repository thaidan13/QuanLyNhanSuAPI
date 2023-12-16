using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinGiaDinhService
{
    public class ThongTinGiaDinhService : IThongTinGiaDinhService
    {
        private readonly DataContext _context;

        public ThongTinGiaDinhService(DataContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<TbThongTinGiaDinh>> CreateGiaDinh(TbThongTinGiaDinh giadinh)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)giadinh.IdNv))
            {
                return new ServiceResponse<TbThongTinGiaDinh> { Success = false, Message = "Dữ liệu nhân viên không tồn tại!" };
            }
            else
            {
                _context.TbThongTinGiaDinhs.Add(giadinh);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbThongTinGiaDinh> { Data = giadinh };
        }

        public async Task<ServiceResponse<bool>> DeleteGiaDinh(int giadinhId)
        {
            var dbGiaDinh = await _context.TbThongTinGiaDinhs.FindAsync(giadinhId);

            if (dbGiaDinh == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbGiaDinh.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbThongTinGiaDinh>> GetGiaDinhAsync(int giadinhId)
        {
            var response = new ServiceResponse<TbThongTinGiaDinh>();

            TbThongTinGiaDinh giadinh = null;

            giadinh = await _context.TbThongTinGiaDinhs.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == giadinhId);

            if (giadinh == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = giadinh;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbThongTinGiaDinh>>> GetGiaDinhNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbThongTinGiaDinh>>();

            List<TbThongTinGiaDinh> giadinh = null;

            giadinh = await _context.TbThongTinGiaDinhs.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId).ToListAsync();

            if (giadinh == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = giadinh;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbThongTinGiaDinh>>> GetGiaDinhsAsync()
        {
            var response = new ServiceResponse<List<TbThongTinGiaDinh>>
            {
                Data = await _context.TbThongTinGiaDinhs.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbThongTinGiaDinh>> UpdateGiaDinh(TbThongTinGiaDinh giadinh)
        {
            var dbGiaDinh = await _context.TbThongTinGiaDinhs.FirstOrDefaultAsync(p => p.Id == giadinh.Id);

            if (dbGiaDinh == null)
            {
                return new ServiceResponse<TbThongTinGiaDinh>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbGiaDinh.HoTen = giadinh.HoTen;
            dbGiaDinh.QuanHe = giadinh.QuanHe;
            dbGiaDinh.NgaySinh = giadinh.NgaySinh;
            dbGiaDinh.DiaChi = giadinh.DiaChi;
            dbGiaDinh.Phuong = giadinh.Phuong;
            dbGiaDinh.QuanHuyen = giadinh.QuanHuyen;
            dbGiaDinh.TinhThanh = giadinh.TinhThanh;
            dbGiaDinh.ConSong = giadinh.ConSong;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbThongTinGiaDinh> { Data = giadinh };
        }
    }
}
