using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.LichSuBanThanNhanVienService
{
    public class LichSuBanThanService : ILichSuBanThanNhanVienService
    {
        private readonly DataContext _context;

        public LichSuBanThanService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbLichSuBanThanNhanVien>> CreateLichSuNhanVien(TbLichSuBanThanNhanVien lichsu)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)lichsu.IdNv))
            {
                return new ServiceResponse<TbLichSuBanThanNhanVien> { Success = false, Message = "Dữ liệu không tồn tại!" };
            }
            else
            {
                _context.TbLichSuBanThanNhanViens.Add(lichsu);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbLichSuBanThanNhanVien> { Data = lichsu };
        }

        public async Task<ServiceResponse<bool>> DeleteLichSuNhanVien(int lichsuId)
        {
            var dbLichSu = await _context.TbLichSuBanThanNhanViens.FindAsync(lichsuId);

            if (dbLichSu == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbLichSu.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbLichSuBanThanNhanVien>> GetLichSuNhanVienAsync(int lichsuId)
        {
            var response = new ServiceResponse<TbLichSuBanThanNhanVien>();

            TbLichSuBanThanNhanVien lichsu = null;

            lichsu = await _context.TbLichSuBanThanNhanViens.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == lichsuId);

            if (lichsu == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = lichsu;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbLichSuBanThanNhanVien>>> GetLichSuNhanViensAsync()
        {
            var response = new ServiceResponse<List<TbLichSuBanThanNhanVien>>
            {
                Data = await _context.TbLichSuBanThanNhanViens.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<TbLichSuBanThanNhanVien>>> GetNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbLichSuBanThanNhanVien>>();

            List<TbLichSuBanThanNhanVien> lichsu = null;

            lichsu = await _context.TbLichSuBanThanNhanViens.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId).ToListAsync();

            if (lichsu == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = lichsu;
            }

            return response;
        }

        public async Task<ServiceResponse<TbLichSuBanThanNhanVien>> UpdateLichSuNhanVien(TbLichSuBanThanNhanVien lichsu)
        {
            var dbLichSu = await _context.TbLichSuBanThanNhanViens.FirstOrDefaultAsync(p => p.Id == lichsu.Id);

            if (dbLichSu == null)
            {
                return new ServiceResponse<TbLichSuBanThanNhanVien>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbLichSu.TuNgay = lichsu.TuNgay;
            dbLichSu.DenNgay = lichsu.DenNgay;
            dbLichSu.LamGi = lichsu.LamGi;
            dbLichSu.Odau = lichsu.Odau;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbLichSuBanThanNhanVien> { Data = lichsu };
        }
    }
}
