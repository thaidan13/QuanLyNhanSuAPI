using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ChucVuService
{
    public class ChucVuService : IChucVuService
    {
        private readonly DataContext _context;

        public ChucVuService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> CreateChucVu(TbChucVu chucvu)
        {
            var newChucVu = new TbChucVu
            {
                TenChucVu = chucvu.TenChucVu
            };
            _context.TbChucVus.Add(newChucVu);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Message = "Thêm thành công" };
        }

        public async Task<ServiceResponse<bool>> DeleteChucVu(int chucvuId)
        {
            var dbChucVu = await _context.TbChucVus.FindAsync(chucvuId);
            if (dbChucVu == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbChucVu.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbChucVu>> GetChucVuAsync(int chucvuId)
        {
            var response = new ServiceResponse<TbChucVu>();
            TbChucVu chucvu = null;
            chucvu = await _context.TbChucVus.FirstOrDefaultAsync(p => p.IdCv == chucvuId);

            if (chucvu == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = chucvu;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbChucVu>>> GetChucVusAsync()
        {
            var response = new ServiceResponse<List<TbChucVu>>
            {
                Data = await _context.TbChucVus.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbChucVu>> UpdateChucVu(TbChucVu chucvu)
        {
            var dbChucVu = await _context.TbChucVus.FirstOrDefaultAsync(p => p.IdCv == chucvu.IdCv);

            if(dbChucVu == null)
            {
                return new ServiceResponse<TbChucVu>
                {
                    Success = false,
                    Message = "Không có dữ liệu!."
                };
            }

            dbChucVu.TenChucVu = chucvu.TenChucVu;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbChucVu> { Data = chucvu };
        }
    }
}
