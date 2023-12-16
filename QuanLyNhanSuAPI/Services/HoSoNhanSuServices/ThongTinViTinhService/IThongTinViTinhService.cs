using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinViTinhService
{
    public interface IThongTinViTinhService
    {
        Task<ServiceResponse<List<TbThongTinViTinh>>> GetViTinhsAsync();
        Task<ServiceResponse<TbThongTinViTinh>> GetViTinhAsync(int vitinhId);
        Task<ServiceResponse<List<TbThongTinViTinh>>> GetViTinhNhanVien(int nhanvienId);
        Task<ServiceResponse<TbThongTinViTinh>> CreateViTinh(TbThongTinViTinh vitinh);
        Task<ServiceResponse<TbThongTinViTinh>> UpdateViTinh(TbThongTinViTinh vitinh);
        Task<ServiceResponse<bool>> DeleteViTinh(int vitinhId);
    }
}
