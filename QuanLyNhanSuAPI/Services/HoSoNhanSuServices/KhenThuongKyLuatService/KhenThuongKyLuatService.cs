using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.KhenThuongKyLuatService
{
    public class KhenThuongKyLuatService : IKhenThuongKyLuatService
    {
        private readonly DataContext _context;

        public KhenThuongKyLuatService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbKhenThuongKyLuat>> CreateKhenThuongKyLuat(TbKhenThuongKyLuat khenThuongKyLuat)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)khenThuongKyLuat.IdNv))
            {
                return new ServiceResponse<TbKhenThuongKyLuat> { Success = false, Message = "Dữ liệu nhân viên không tồn tại!" };
            }
            else
            {
                _context.TbKhenThuongKyLuats.Add(khenThuongKyLuat);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbKhenThuongKyLuat> { Data = khenThuongKyLuat };
        }

        public async Task<ServiceResponse<bool>> DeleteKhenThuongKyLuat(int khenThuongKyLuatId)
        {
            var dbKhenThuongKyLuat = await _context.TbKhenThuongKyLuats.FindAsync(khenThuongKyLuatId);

            if (dbKhenThuongKyLuat == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbKhenThuongKyLuat.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbKhenThuongKyLuat>> GetKhenThuongKyLuatAsync(int khenThuongKyLuatId)
        {
            var response = new ServiceResponse<TbKhenThuongKyLuat>();

            TbKhenThuongKyLuat khenThuongKyLuat = null;

            khenThuongKyLuat = await _context.TbKhenThuongKyLuats.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == khenThuongKyLuatId);

            if (khenThuongKyLuat == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = khenThuongKyLuat;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbKhenThuongKyLuat>>> GetKhenThuongNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbKhenThuongKyLuat>>();

            List<TbKhenThuongKyLuat> khenThuongKyLuats = null;

            khenThuongKyLuats = await _context.TbKhenThuongKyLuats.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId && (bool)!p.Loai).Include(p => p.IdNvNavigation).ToListAsync();

            if (khenThuongKyLuats == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = khenThuongKyLuats;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbKhenThuongKyLuat>>> GetKyLuatNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbKhenThuongKyLuat>>();

            List<TbKhenThuongKyLuat> khenThuongKyLuats = null;

            khenThuongKyLuats = await _context.TbKhenThuongKyLuats.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId && (bool)p.Loai).Include(p => p.IdNvNavigation).ToListAsync();

            if (khenThuongKyLuats == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = khenThuongKyLuats;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbKhenThuongKyLuat>>> GetKhenThuongKyLuatsAsync()
        {
            var response = new ServiceResponse<List<TbKhenThuongKyLuat>>
            {
                Data = await _context.TbKhenThuongKyLuats.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbKhenThuongKyLuat>> UpdateKhenThuongKyLuat(TbKhenThuongKyLuat khenThuongKyLuat)
        {
            var dbKhenThuongKyLuat = await _context.TbKhenThuongKyLuats.FirstOrDefaultAsync(p => p.Id == khenThuongKyLuat.Id);

            if (dbKhenThuongKyLuat == null)
            {
                return new ServiceResponse<TbKhenThuongKyLuat>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbKhenThuongKyLuat.HinhThuc = khenThuongKyLuat.HinhThuc;
            dbKhenThuongKyLuat.TuNgay = khenThuongKyLuat.DenNgay;
            dbKhenThuongKyLuat.DenNgay = khenThuongKyLuat.DenNgay;
            dbKhenThuongKyLuat.LyDo = khenThuongKyLuat.LyDo;
            dbKhenThuongKyLuat.CapQuyetDinh = khenThuongKyLuat.CapQuyetDinh;
            dbKhenThuongKyLuat.SoQuyetDinh = khenThuongKyLuat.SoQuyetDinh;
            dbKhenThuongKyLuat.NguoiKy = khenThuongKyLuat.NguoiKy;
            dbKhenThuongKyLuat.GhiChu = khenThuongKyLuat.GhiChu;
            dbKhenThuongKyLuat.DinhKem = khenThuongKyLuat.DinhKem;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbKhenThuongKyLuat> { Data = khenThuongKyLuat };

        }
    }
}
