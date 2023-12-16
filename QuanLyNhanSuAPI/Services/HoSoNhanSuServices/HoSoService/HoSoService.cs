using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.HoSoService
{
    public class HoSoService : IHoSoService
    {
        private readonly DataContext _context;
        
        public HoSoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbHoSo>> CreateHoSo(TbHoSo hoso)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)hoso.IdNv))
            {
                return new ServiceResponse<TbHoSo> { Success = false, Message = "Dữ liệu nhân viên không tồn tại!" };
            }
            else
            {
                _context.TbHoSos.Add(hoso);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbHoSo> { Data = hoso };
        }

        public async Task<ServiceResponse<bool>> DeleteHoSo(int hosoId)
        {
            var dbHoSo = await _context.TbHoSos.FindAsync(hosoId);

            if (dbHoSo == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbHoSo.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbHoSo>> GetHoSoAsync(int hosoId)
        {
            var response = new ServiceResponse<TbHoSo>();

            TbHoSo hoso = null;

            hoso = await _context.TbHoSos.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == hosoId);

            if (hoso == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = hoso;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbHoSo>>> GetHoSoLienQuanNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbHoSo>>();

            List<TbHoSo> hoso = null;

            hoso = await _context.TbHoSos.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId && (bool)!p.LoaiHoSo).Include(p => p.IdNvNavigation).ToListAsync();

            if (hoso == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = hoso;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbHoSo>>> GetHoSosAsync()
        {
            var response = new ServiceResponse<List<TbHoSo>>
            {
                Data = await _context.TbHoSos.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<TbHoSo>>> GetHoSoTuyenDungNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbHoSo>>();

            List<TbHoSo> hoso = null;

            hoso = await _context.TbHoSos.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId && (bool)p.LoaiHoSo).Include(p => p.IdNvNavigation).ToListAsync();

            if (hoso == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = hoso;
            }

            return response;
        }

        public async Task<ServiceResponse<TbHoSo>> UpdateHoSo(TbHoSo hoso)
        {
            var dbHoSo = await _context.TbHoSos.FirstOrDefaultAsync(p => p.Id == hoso.Id);

            if (dbHoSo == null)
            {
                return new ServiceResponse<TbHoSo>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbHoSo.TenHoSo = hoso.TenHoSo;
            dbHoSo.TapTin = hoso.TapTin;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbHoSo> { Data = hoso };

        }
    }
}
