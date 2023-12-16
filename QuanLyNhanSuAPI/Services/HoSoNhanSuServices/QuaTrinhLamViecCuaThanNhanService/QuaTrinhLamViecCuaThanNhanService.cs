using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhLamViecCuaThanNhanService
{
    public class QuaTrinhLamViecCuaThanNhanService : IQuaTrinhLamViecCuaThanNhanService
    {
        private readonly DataContext _context;

        public QuaTrinhLamViecCuaThanNhanService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>> CreateThanNhanLamViec(TbQuaTrinhLamViecCuaThanNhan thannhanlamviec)
        {
            var dbThanNhan = await _context.TbThongTinGiaDinhs.Select(nv => nv.Id).ToListAsync();

            if (!dbThanNhan.Contains((int)thannhanlamviec.IdThanNhan))
            {
                return new ServiceResponse<TbQuaTrinhLamViecCuaThanNhan> { Success = false, Message = "Dữ liệu không tồn tại!" };
            }
            else
            {
                _context.TbQuaTrinhLamViecCuaThanNhans.Add(thannhanlamviec);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbQuaTrinhLamViecCuaThanNhan> { Data = thannhanlamviec };
        }

        public async Task<ServiceResponse<bool>> DeleteThanNhanLamViec(int thannhanlamviecIdId)
        {
            var dbThanNhan = await _context.TbQuaTrinhLamViecCuaThanNhans.FindAsync(thannhanlamviecIdId);

            if (dbThanNhan == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbThanNhan.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>> GetThanNhanLamViecAsync(int thannhanlamviecId)
        {
            var response = new ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>();

            TbQuaTrinhLamViecCuaThanNhan thannhan = null;

            thannhan = await _context.TbQuaTrinhLamViecCuaThanNhans.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == thannhanlamviecId);

            if (thannhan == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = thannhan;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbQuaTrinhLamViecCuaThanNhan>>> GetThanNhanLamViecsAsync(int thannhanId)
        {
            var response = new ServiceResponse<List<TbQuaTrinhLamViecCuaThanNhan>>
            {
                Data = await _context.TbQuaTrinhLamViecCuaThanNhans.Where(p => (bool)!p.IsDelete && p.IdThanNhan == thannhanId).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>> UpdateThanNhanLamViec(TbQuaTrinhLamViecCuaThanNhan thannhanlamviec)
        {
            var dbThanNhanLamViec = await _context.TbQuaTrinhLamViecCuaThanNhans.FirstOrDefaultAsync(p => p.Id == thannhanlamviec.Id);

            if (dbThanNhanLamViec == null)
            {
                return new ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbThanNhanLamViec.TuNam = thannhanlamviec.TuNam;
            dbThanNhanLamViec.DenNam = thannhanlamviec.DenNam;
            dbThanNhanLamViec.CongViec = thannhanlamviec.CongViec;
            dbThanNhanLamViec.DonVi = thannhanlamviec.DonVi;
            dbThanNhanLamViec.CapBac = thannhanlamviec.CapBac;
            dbThanNhanLamViec.ChucVu = thannhanlamviec.ChucVu;
            dbThanNhanLamViec.LoaiChucVu = thannhanlamviec.LoaiChucVu;
            dbThanNhanLamViec.TrongNganh = thannhanlamviec.TrongNganh;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbQuaTrinhLamViecCuaThanNhan> { Data = thannhanlamviec };
        }
    }
}
