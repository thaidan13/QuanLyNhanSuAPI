using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinNgoaiNguService
{
    public class ThongTinNgoaiNguService : IThongTinNgoaiNguService
    {
        private readonly DataContext _context;

        public ThongTinNgoaiNguService(DataContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<TbThongTinNgoaiNgu>> CreateNgoaiNgu(TbThongTinNgoaiNgu ngoaingu)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)ngoaingu.IdNv))
            {
                return new ServiceResponse<TbThongTinNgoaiNgu> { Success = false, Message = "Dữ liệu không tồn tại!" };
            }
            else
            {
                _context.TbThongTinNgoaiNgus.Add(ngoaingu);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbThongTinNgoaiNgu> { Data = ngoaingu };
        }

        public async Task<ServiceResponse<bool>> DeleteNgoaiNgu(int ngoainguId)
        {
            var dbNgoaiNgu = await _context.TbThongTinNgoaiNgus.FindAsync(ngoainguId);

            if (dbNgoaiNgu == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbNgoaiNgu.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbThongTinNgoaiNgu>> GetNgoaiNguAsync(int ngoainguId)
        {
            var response = new ServiceResponse<TbThongTinNgoaiNgu>();

            TbThongTinNgoaiNgu ngoaingu = null;

            ngoaingu = await _context.TbThongTinNgoaiNgus.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == ngoainguId);

            if (ngoaingu == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = ngoaingu;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbThongTinNgoaiNgu>>> GetNgoaiNguNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbThongTinNgoaiNgu>>();

            List<TbThongTinNgoaiNgu> ngoaingu = null;

            ngoaingu = await _context.TbThongTinNgoaiNgus.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId).ToListAsync();

            if (ngoaingu == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = ngoaingu;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbThongTinNgoaiNgu>>> GetNgoaiNgusAsync()
        {
            var response = new ServiceResponse<List<TbThongTinNgoaiNgu>>
            {
                Data = await _context.TbThongTinNgoaiNgus.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbThongTinNgoaiNgu>> UpdateNgoaiNgu(TbThongTinNgoaiNgu ngoaingu)
        {
            var dbNgoaiNgu = await _context.TbThongTinNgoaiNgus.FirstOrDefaultAsync(p => p.Id == ngoaingu.Id);

            if (dbNgoaiNgu == null)
            {
                return new ServiceResponse<TbThongTinNgoaiNgu>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbNgoaiNgu.NgoaiNgu = ngoaingu.NgoaiNgu;
            dbNgoaiNgu.BangCap = ngoaingu.BangCap;
            dbNgoaiNgu.KetQua = ngoaingu.KetQua;
            dbNgoaiNgu.NgayCap = ngoaingu.NgayCap;
            dbNgoaiNgu.KinhPhi = ngoaingu.KinhPhi;
            dbNgoaiNgu.ChinhPhu = ngoaingu.ChinhPhu;
            dbNgoaiNgu.NguonKinhPhi = ngoaingu.NguonKinhPhi;
            dbNgoaiNgu.GhiChu = ngoaingu.GhiChu;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbThongTinNgoaiNgu> { Data = ngoaingu };

        }
    }
}
