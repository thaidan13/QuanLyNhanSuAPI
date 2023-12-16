using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinViTinhService
{
    public class ThongTinViTinhService : IThongTinViTinhService
    {
        private readonly DataContext _context;

        public ThongTinViTinhService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbThongTinViTinh>> CreateViTinh(TbThongTinViTinh vitinh)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)vitinh.IdNv))
            {
                return new ServiceResponse<TbThongTinViTinh> { Success = false, Message = "Dữ liệu nhân viên không tồn tại!" };

            }
            else
            {
                _context.TbThongTinViTinhs.Add(vitinh);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbThongTinViTinh> { Data = vitinh };
        }

        public async Task<ServiceResponse<bool>> DeleteViTinh(int vitinhId)
        {
            var dbViTinh = await _context.TbThongTinViTinhs.FindAsync(vitinhId);

            if (dbViTinh == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbViTinh.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbThongTinViTinh>> GetViTinhAsync(int vitinhId)
        {
            var response = new ServiceResponse<TbThongTinViTinh>();

            TbThongTinViTinh vitinh = null;

            vitinh = await _context.TbThongTinViTinhs.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == vitinhId);

            if (vitinh == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = vitinh;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbThongTinViTinh>>> GetViTinhNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbThongTinViTinh>>();

            List<TbThongTinViTinh> vitinh = null;

            vitinh = await _context.TbThongTinViTinhs.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId).ToListAsync();

            if (vitinh == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = vitinh;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbThongTinViTinh>>> GetViTinhsAsync()
        {
            var response = new ServiceResponse<List<TbThongTinViTinh>>
            {
                Data = await _context.TbThongTinViTinhs.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbThongTinViTinh>> UpdateViTinh(TbThongTinViTinh vitinh)
        {
            var dbViTinh = await _context.TbThongTinViTinhs.FirstOrDefaultAsync(p => p.Id == vitinh.Id);

            if (dbViTinh == null)
            {
                return new ServiceResponse<TbThongTinViTinh>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbViTinh.BangCap = vitinh.BangCap;
            dbViTinh.SoBang = vitinh.SoBang;
            dbViTinh.NoiDung = vitinh.NoiDung;
            dbViTinh.CheDoHoc = vitinh.CheDoHoc;
            dbViTinh.NgayCap = vitinh.NgayCap;
            dbViTinh.TuNgay = vitinh.TuNgay;
            dbViTinh.Denngay = vitinh.Denngay;
            dbViTinh.KinhPhi = vitinh.KinhPhi;
            dbViTinh.NguonKinhPhi = vitinh.NguonKinhPhi;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbThongTinViTinh> { Data = vitinh };

        }
    }
}
