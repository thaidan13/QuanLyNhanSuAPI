using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using System.Linq;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhDaoTaoService
{
    public class QuaTrinhDaoTaoService : IQuaTrinhDaoTaoService
    {
        private readonly DataContext _context;

        public QuaTrinhDaoTaoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbQuaTrinhDaoTao>> CreateQuaTrinhDaoTao(TbQuaTrinhDaoTao qtdt)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if(!dbNhanVien.Contains((int)qtdt.IdNv))
            {
                return new ServiceResponse<TbQuaTrinhDaoTao> { Success = false ,Message = "Dữ liệu không tồn tại!" };
                
            }
            else
            {
                _context.TbQuaTrinhDaoTaos.Add(qtdt);
                await _context.SaveChangesAsync();
            }
            
            return new ServiceResponse<TbQuaTrinhDaoTao> { Data = qtdt };
        }

        public async Task<ServiceResponse<bool>> DeleteQuaTrinhDaoTao(int qtdtid)
        {
            var dbQuaTrinh = await _context.TbQuaTrinhDaoTaos.FindAsync(qtdtid);

            if (dbQuaTrinh == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbQuaTrinh.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<TbQuaTrinhDaoTao>>> GetDaoTaoNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbQuaTrinhDaoTao>>();

            List<TbQuaTrinhDaoTao> daotao = null;

            daotao = await _context.TbQuaTrinhDaoTaos.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId).Include(p => p.IdNvNavigation).ToListAsync();

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

        public async Task<ServiceResponse<TbQuaTrinhDaoTao>> GetQuaTrinhDaoTaoAsync(int qtdtid)
        {
            var response = new ServiceResponse<TbQuaTrinhDaoTao>();

            TbQuaTrinhDaoTao daotao = null;

            daotao = await _context.TbQuaTrinhDaoTaos.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == qtdtid);

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

        public async Task<ServiceResponse<List<TbQuaTrinhDaoTao>>> GetQuaTrinhDaoTaosAsync()
        {
            var response = new ServiceResponse<List<TbQuaTrinhDaoTao>>
            {
                Data = await _context.TbQuaTrinhDaoTaos.Where(p => (bool)!p.IsDelete).Include(p => p.IdNvNavigation).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbQuaTrinhDaoTao>> UpdateQuaTrinhDaoTao(TbQuaTrinhDaoTao qtdt)
        {
            var dbDaoTao = await _context.TbQuaTrinhDaoTaos.FirstOrDefaultAsync(p => p.Id == qtdt.Id);

            if (dbDaoTao == null)
            {
                return new ServiceResponse<TbQuaTrinhDaoTao>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbDaoTao.TuNam = qtdt.TuNam;
            dbDaoTao.DenNam = qtdt.DenNam;
            dbDaoTao.CheDoHoc = qtdt.CheDoHoc;
            dbDaoTao.LoaiDaoTao = qtdt.LoaiDaoTao;
            dbDaoTao.TruongDaoTao = qtdt.TruongDaoTao;
            dbDaoTao.NganhDaoTao = qtdt.NganhDaoTao;
            dbDaoTao.BangCap = qtdt.BangCap;
            dbDaoTao.NoiDung = qtdt.NoiDung;
            dbDaoTao.KetQua = qtdt.KetQua;
            dbDaoTao.ThoiGian = qtdt.ThoiGian;
            dbDaoTao.ChuyenMon = qtdt.ChuyenMon;
            dbDaoTao.SoBang = qtdt.SoBang;
            dbDaoTao.NgayCap = qtdt.NgayCap;
            dbDaoTao.QuocGia = qtdt.QuocGia;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbQuaTrinhDaoTao> { Data = qtdt };

        }
    }
}
