using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhDaoTaoCuMoiService
{
    public class QuaTrinhDaoTaoCuMoiService : IQuaTrinhDaoTaoCuMoiService
    {
        private readonly DataContext _context;

        public QuaTrinhDaoTaoCuMoiService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>> CreateDaoTaoCuMoi(TbQuaTrinhDaoTaoCuMoi daotao)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)daotao.IdNv))
            {
                return new ServiceResponse<TbQuaTrinhDaoTaoCuMoi> { Success = false, Message = "Dữ liệu không tồn tại!" };
            }
            else
            {
                _context.TbQuaTrinhDaoTaoCuMois.Add(daotao);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbQuaTrinhDaoTaoCuMoi> { Data = daotao };
        }

        public async Task<ServiceResponse<bool>> DeleteDaoTaoCuMoi(int daotaoid)
        {
            var dbDaoTao = await _context.TbQuaTrinhDaoTaoCuMois.FindAsync(daotaoid);

            if (dbDaoTao == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbDaoTao.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>> GetDaoTaoCuMoiAsync(int daotaoid)
        {
            var response = new ServiceResponse<TbQuaTrinhDaoTaoCuMoi>();

            TbQuaTrinhDaoTaoCuMoi daotao = null;

            daotao = await _context.TbQuaTrinhDaoTaoCuMois.Where(p => (bool)!p.IsDelete).Include(p => p.IdNvNavigation).FirstOrDefaultAsync(p => p.Id == daotaoid);

            if (daotao == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = daotao;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>> GetDaoTaoCuNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>();

            List<TbQuaTrinhDaoTaoCuMoi> daotao = null;

            daotao = await _context.TbQuaTrinhDaoTaoCuMois.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId && (bool)p.LoaiDaoTao).ToListAsync();

            if (daotao == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = daotao;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>> GetDaoTaoMoiNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>();

            List<TbQuaTrinhDaoTaoCuMoi> daotao = null;

            daotao = await _context.TbQuaTrinhDaoTaoCuMois.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId && (bool)!p.LoaiDaoTao).ToListAsync();

            if (daotao == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = daotao;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>> GetDaoTaoCuMoisAsync()
        {
            var response = new ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>
            {
                Data = await _context.TbQuaTrinhDaoTaoCuMois.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>> UpdateDaoTaoCuMoi(TbQuaTrinhDaoTaoCuMoi daotao)
        {
            var dbDaoTao = await _context.TbQuaTrinhDaoTaoCuMois.FirstOrDefaultAsync(p => p.Id == daotao.Id);

            if (dbDaoTao == null)
            {
                return new ServiceResponse<TbQuaTrinhDaoTaoCuMoi>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbDaoTao.KhoaHoc = daotao.KhoaHoc;
            dbDaoTao.TruongDonVi = daotao.TruongDonVi;
            dbDaoTao.HoanTat = daotao.HoanTat;
            dbDaoTao.NgayBatDau = daotao.NgayBatDau;
            dbDaoTao.NgayKetThuc = daotao.NgayKetThuc;
            dbDaoTao.SoQuyetDinh = daotao.SoQuyetDinh;
            dbDaoTao.HinhThuc = daotao.HinhThuc;
            dbDaoTao.TenBang = daotao.TenBang;
            dbDaoTao.SoBang = daotao.SoBang;
            dbDaoTao.DangBang = daotao.DangBang;
            dbDaoTao.NgayCap = daotao.NgayCap;
            dbDaoTao.HetHan = daotao.HetHan;
            dbDaoTao.GhiChu = daotao.GhiChu;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbQuaTrinhDaoTaoCuMoi> { Data = daotao };
        }
    }
}
