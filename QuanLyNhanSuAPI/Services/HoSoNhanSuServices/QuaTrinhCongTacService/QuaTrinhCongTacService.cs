using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhCongTacService
{
    public class QuaTrinhCongTacService : IQuaTrinhCongTacService
    {
        private readonly DataContext _context;

        public QuaTrinhCongTacService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbQuaTrinhCongTac>> CreateCongTac(TbQuaTrinhCongTac congtac)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)congtac.IdNv))
            {
                return new ServiceResponse<TbQuaTrinhCongTac> { Success = false, Message = "Dữ liệu không tồn tại!" };
            }
            else
            {
                _context.TbQuaTrinhCongTacs.Add(congtac);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbQuaTrinhCongTac> { Data = congtac };
        }

        public async Task<ServiceResponse<bool>> DeleteCongTac(int congtacId)
        {
            var dbCongTac = await _context.TbQuaTrinhCongTacs.FindAsync(congtacId);

            if (dbCongTac == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbCongTac.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbQuaTrinhCongTac>> GetCongTacAsync(int congtacId)
        {
            var response = new ServiceResponse<TbQuaTrinhCongTac>();

            TbQuaTrinhCongTac congtac = null;

            congtac = await _context.TbQuaTrinhCongTacs.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == congtacId);

            if (congtac == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = congtac;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbQuaTrinhCongTac>>> GetCongTacNgoaiCongTys(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbQuaTrinhCongTac>>();

            List<TbQuaTrinhCongTac> ngoaicongty = null;

            ngoaicongty = await _context.TbQuaTrinhCongTacs.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId && (bool)!p.Loai).ToListAsync();

            if(ngoaicongty == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = ngoaicongty;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbQuaTrinhCongTac>>> GetCongTacNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbQuaTrinhCongTac>>();

            List<TbQuaTrinhCongTac> congtac = null;

            congtac = await _context.TbQuaTrinhCongTacs.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId).ToListAsync();

            if (congtac == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = congtac;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbQuaTrinhCongTac>>> GetCongTacsAsync()
        {
            var response = new ServiceResponse<List<TbQuaTrinhCongTac>>
            {
                Data = await _context.TbQuaTrinhCongTacs.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<TbQuaTrinhCongTac>>> GetCongTacTrongCongTys(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbQuaTrinhCongTac>>();

            List<TbQuaTrinhCongTac> trongcongty = null;

            trongcongty = await _context.TbQuaTrinhCongTacs.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId && (bool)p.Loai).ToListAsync();

            if (trongcongty == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = trongcongty;
            }

            return response;
        }

        public async Task<ServiceResponse<TbQuaTrinhCongTac>> UpdateCongTac(TbQuaTrinhCongTac congtac)
        {
            var dbCongTac = await _context.TbQuaTrinhCongTacs.FirstOrDefaultAsync(p => p.Id == congtac.Id);

            if (dbCongTac == null)
            {
                return new ServiceResponse<TbQuaTrinhCongTac>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbCongTac.TuNgay = congtac.TuNgay;
            dbCongTac.DenNgay = congtac.DenNgay;
            dbCongTac.TenCongTy = congtac.TenCongTy;
            dbCongTac.TenPhongBan = congtac.TenPhongBan;
            dbCongTac.TenDoi = congtac.TenDoi;
            dbCongTac.ChucDanh = congtac.ChucDanh;
            dbCongTac.LyDo = congtac.LyDo;
            dbCongTac.DangHoatDong = congtac.DangHoatDong;
            dbCongTac.SoHdld = congtac.SoHdld;
            dbCongTac.SoQd = congtac.SoQd;
            dbCongTac.LoaiHdld = congtac.LoaiHdld;
            dbCongTac.NgayQuyetDinh = congtac.NgayQuyetDinh;
            dbCongTac.NgayHieuLuc = congtac.NgayHieuLuc;
            dbCongTac.NguoiKy = congtac.NguoiKy;
            dbCongTac.FileQuyetDinh = congtac.FileQuyetDinh;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbQuaTrinhCongTac> { Data = congtac };
        }
    }
}
