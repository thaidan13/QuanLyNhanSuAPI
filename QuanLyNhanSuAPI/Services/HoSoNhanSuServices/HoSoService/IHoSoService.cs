using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.HoSoService
{
    public interface IHoSoService
    {
        Task<ServiceResponse<List<TbHoSo>>> GetHoSosAsync();
        Task<ServiceResponse<TbHoSo>> GetHoSoAsync(int hosoId);
        Task<ServiceResponse<List<TbHoSo>>> GetHoSoLienQuanNhanVien(int nhanvienId);
        Task<ServiceResponse<List<TbHoSo>>> GetHoSoTuyenDungNhanVien(int nhanvienId);
        Task<ServiceResponse<TbHoSo>> CreateHoSo(TbHoSo hoso);
        Task<ServiceResponse<TbHoSo>> UpdateHoSo(TbHoSo hoso);
        Task<ServiceResponse<bool>> DeleteHoSo(int hosoId);
    }
}
