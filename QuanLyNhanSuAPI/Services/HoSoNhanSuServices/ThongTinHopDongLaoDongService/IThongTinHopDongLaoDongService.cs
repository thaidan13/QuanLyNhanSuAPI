using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinHopDongLaoDongService
{
    public interface IThongTinHopDongLaoDongService
    {
        Task<ServiceResponse<List<TbThongTinHopDongLaoDong>>> GetHopDongsAsync();
        Task<ServiceResponse<TbThongTinHopDongLaoDong>> GetHopDongAsync(int hopdongId);
        Task<ServiceResponse<List<TbThongTinHopDongLaoDong>>> GetHopDongNhanVien(int nhanvienId);
        Task<ServiceResponse<TbThongTinHopDongLaoDong>> CreateHopDong(TbThongTinHopDongLaoDong hopdong);
        Task<ServiceResponse<TbThongTinHopDongLaoDong>> UpdateHopDong(TbThongTinHopDongLaoDong hopdong);
        Task<ServiceResponse<bool>> DeleteHopDong(int hopdongId);
    }
}
