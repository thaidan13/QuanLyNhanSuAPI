using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinChinhTriService
{
    public class ThongTinChinhTriService : IThongTinChinhTriService
    {
        private readonly DataContext _context;

        public ThongTinChinhTriService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbThongTinChinhTri>> CreateChinhTri(TbThongTinChinhTri chinhtri)
        {
            var dbNhanVien = await _context.TbThongTinNhanViens.Select(nv => nv.IdNv).ToListAsync();

            if (!dbNhanVien.Contains((int)chinhtri.IdNv))
            {
                return new ServiceResponse<TbThongTinChinhTri> { Success = false, Message = "Dữ liệu nhân viên không tồn tại!" };

            }
            else
            {
                _context.TbThongTinChinhTris.Add(chinhtri);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse<TbThongTinChinhTri> { Data = chinhtri };
        }

        public async Task<ServiceResponse<bool>> DeleteChinhTri(int chinhtriId)
        {
            var dbChinhTri = await _context.TbThongTinChinhTris.FindAsync(chinhtriId);

            if (dbChinhTri == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbChinhTri.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }


        public async Task<ServiceResponse<TbThongTinChinhTri>> GetChinhTriAsync(int chinhtriId)
        {
            var response = new ServiceResponse<TbThongTinChinhTri>();

            TbThongTinChinhTri chinhtri = null;

            chinhtri = await _context.TbThongTinChinhTris.Where(p => (bool)!p.IsDelete).FirstOrDefaultAsync(p => p.Id == chinhtriId);

            if (chinhtri == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = chinhtri;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbThongTinChinhTri>>> GetChinhTriNhanVien(int nhanvienId)
        {
            var response = new ServiceResponse<List<TbThongTinChinhTri>>();

            List<TbThongTinChinhTri> chinhtri = null;

            chinhtri = await _context.TbThongTinChinhTris.Where(p => (bool)!p.IsDelete && p.IdNv == nhanvienId).ToListAsync();

            if (chinhtri == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = chinhtri;
            }

            return response;
        }

        public async Task<ServiceResponse<List<TbThongTinChinhTri>>> GetChinhTrisAsync()
        {
            var response = new ServiceResponse<List<TbThongTinChinhTri>>
            {
                Data = await _context.TbThongTinChinhTris.Where(p => (bool)!p.IsDelete).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbThongTinChinhTri>> UpdateChinhTri(TbThongTinChinhTri chinhtri)
        {
            var dbChinhTri = await _context.TbThongTinChinhTris.FirstOrDefaultAsync(p => p.Id == chinhtri.Id);

            if (dbChinhTri == null)
            {
                return new ServiceResponse<TbThongTinChinhTri>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbChinhTri.TrinhDoChinhTri = chinhtri.TrinhDoChinhTri;
            dbChinhTri.CheDoHoc = chinhtri.CheDoHoc;
            dbChinhTri.TuNgay = chinhtri.TuNgay;
            dbChinhTri.DenNgay = chinhtri.DenNgay;
            dbChinhTri.KinhPhi = chinhtri.KinhPhi;
            dbChinhTri.NguonKinhPhi = chinhtri.NguonKinhPhi;
            dbChinhTri.NgayCap = chinhtri.NgayCap;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbThongTinChinhTri> { Data = chinhtri };
        }
    }
}
