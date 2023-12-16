using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.PhongBanService
{
    public interface IPhongBanService
    {
        Task<ServiceResponse<List<TbPhongBan>>> GetPhongBansAsync();
        Task<ServiceResponse<TbPhongBan>> GetPhongBanAsync(int phongbanId);
        Task<ServiceResponse<int>> CreatePhongBan(TbPhongBan phongban);
        Task<ServiceResponse<TbPhongBan>> UpdatePhongBan(TbPhongBan phongban);
        Task<ServiceResponse<bool>> DeletePhongBan(int phongbanId);

        Task<List<PhongBanModelView>> GetPhongBanOKRs();
    }
}
