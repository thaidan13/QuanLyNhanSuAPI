using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.PhongBanService
{
    public class PhongBanService : IPhongBanService
    {
        private readonly DataContext _context;

        public PhongBanService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> CreatePhongBan(TbPhongBan phongban)
        {
            var newPhongBan = new TbPhongBan
            {
                TenPhongBan = phongban.TenPhongBan,
                QuanLy = phongban.QuanLy
            };
            _context.TbPhongBans.Add(newPhongBan);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Message = "Thêm thành công" };
        }

        public async Task<ServiceResponse<bool>> DeletePhongBan(int phongbanId)
        {
            var dbPhongBan = await _context.TbPhongBans.FindAsync(phongbanId);
            if (dbPhongBan == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Không có dữ liệu."
                };
            }

            dbPhongBan.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<TbPhongBan>> GetPhongBanAsync(int phongbanId)
        {
            var response = new ServiceResponse<TbPhongBan>();
            TbPhongBan phongban = null;
            phongban = await _context.TbPhongBans.FirstOrDefaultAsync(p => p.IdPb == phongbanId);

            if (phongban == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = phongban;
            }

            return response;
        }

        public async Task<List<PhongBanModelView>> GetPhongBanOKRs()
        {
            var query = from a in _context.TbPhongBans
                        join b in _context.TbThongTinNhanViens on a.QuanLy equals b.IdNv
                        select new PhongBanModelView { IdPb = a.IdPb, IdNv = (int)a.QuanLy, TenPhongBan = a.TenPhongBan, QuanLy = b.HoKhaiSinh + " " + b.TenKhaiSinh };
            List<PhongBanModelView> result = await query.ToListAsync();
            return result;
        }

        public async Task<ServiceResponse<List<TbPhongBan>>> GetPhongBansAsync()
        {
            var response = new ServiceResponse<List<TbPhongBan>>
            {
                Data = await _context.TbPhongBans.Where(p => (bool)!p.IsDelete).Include(p => p.TbThongTinNhanViens).Include(p => p.QuanLyNavigation).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbPhongBan>> UpdatePhongBan(TbPhongBan phongban)
        {
            var dbPhongBan = await _context.TbPhongBans.FirstOrDefaultAsync(p => p.IdPb == phongban.IdPb);

            if (dbPhongBan == null)
            {
                return new ServiceResponse<TbPhongBan>
                {
                    Success = false,
                    Message = "Không có dữ liệu!."
                };
            }

            dbPhongBan.TenPhongBan = phongban.TenPhongBan;
            dbPhongBan.QuanLy = phongban.QuanLy;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbPhongBan> { Data = phongban };
        }
    }
}
