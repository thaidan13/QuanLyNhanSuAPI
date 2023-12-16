using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.DiNuocNgoaiService
{
    public class DiNuocNgoaiService : IDiNuocNgoaiService
    {
        private readonly DataContext _context;

        public DiNuocNgoaiService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbDiNuocNgoai>> CreateNuocNgoai(TbDiNuocNgoai nuocngoai)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)nuocngoai.IdNv))
            {
                return new ServiceResponse<TbDiNuocNgoai> { Success = false, Message = "Dữ liệu không tồn tại!" };
            }
            else
            {
                _context.TbDiNuocNgoais.Add(nuocngoai);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbDiNuocNgoai> { Data = nuocngoai };
        }

        public async Task<ServiceResponse<bool>> DeleteTbDiNuocNgoai(int nuocngoaiId)
        {
            var dbNuocNgoai = await _context.TbDiNuocNgoais.FindAsync(nuocngoaiId);

            if (dbNuocNgoai == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbNuocNgoai.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbDiNuocNgoai>> GetNuocNgoaiAsync(int nuocngoaiId)
        {
            var response = new ServiceResponse<TbDiNuocNgoai>();

            TbDiNuocNgoai nuocngoai = null;

            nuocngoai = await _context.TbDiNuocNgoais.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == nuocngoaiId);

            if (nuocngoai == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = nuocngoai;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbDiNuocNgoai>>> GetNuocNgoaiNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbDiNuocNgoai>>();

            List<TbDiNuocNgoai> nuocngoai = null;

            nuocngoai = await _context.TbDiNuocNgoais.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId).ToListAsync();

            if (nuocngoai == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = nuocngoai;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbDiNuocNgoai>>> GetNuocNgoaisAsync()
        {
            var response = new ServiceResponse<List<TbDiNuocNgoai>>
            {
                Data = await _context.TbDiNuocNgoais.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbDiNuocNgoai>> UpdateNuocNgoai(TbDiNuocNgoai nuocngoai)
        {
            var dbNuocNgoai = await _context.TbDiNuocNgoais.FirstOrDefaultAsync(p => p.Id == nuocngoai.Id);

            if (dbNuocNgoai == null)
            {
                return new ServiceResponse<TbDiNuocNgoai>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbNuocNgoai.NgayDi = nuocngoai.NgayDi;
            dbNuocNgoai.NgayVe = nuocngoai.NgayVe;
            dbNuocNgoai.ThoiGian = nuocngoai.ThoiGian;
            dbNuocNgoai.QuocGiaDen = nuocngoai.QuocGiaDen;
            dbNuocNgoai.MucDich = nuocngoai.MucDich;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbDiNuocNgoai> { Data = nuocngoai };

        }
    }
}
