using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinDoanDangService
{
    public interface IThongTinDoanDangService
    {
        Task<ServiceResponse<List<TbThongTinDoanDang>>> GetDoanDangsAsync();
        Task<ServiceResponse<TbThongTinDoanDang>> GetDoanDangAsync(int doandangId);
        Task<ServiceResponse<TbThongTinDoanDang>> GetDoanDangNhanVien(int nhanvienId);
        Task<ServiceResponse<TbThongTinDoanDang>> CreateDoanDang(TbThongTinDoanDangDTO doandang);
        Task<ServiceResponse<TbThongTinDoanDang>> UpdateDoanDang(TbThongTinDoanDang doandang);
        //Task<ServiceResponse<bool>> DeleteDoanDang(int doandangId);
    }
}
