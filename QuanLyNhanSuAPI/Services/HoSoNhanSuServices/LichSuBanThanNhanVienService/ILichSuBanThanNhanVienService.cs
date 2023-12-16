using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.LichSuBanThanNhanVienService
{
    public interface ILichSuBanThanNhanVienService
    {
        Task<ServiceResponse<List<TbLichSuBanThanNhanVien>>> GetLichSuNhanViensAsync();
        Task<ServiceResponse<TbLichSuBanThanNhanVien>> GetLichSuNhanVienAsync(int lichsuId);
        Task<ServiceResponse<List<TbLichSuBanThanNhanVien>>> GetNhanVien(int nhanvienId);
        Task<ServiceResponse<TbLichSuBanThanNhanVien>> CreateLichSuNhanVien(TbLichSuBanThanNhanVien lichsu);
        Task<ServiceResponse<TbLichSuBanThanNhanVien>> UpdateLichSuNhanVien(TbLichSuBanThanNhanVien lichsu);
        Task<ServiceResponse<bool>> DeleteLichSuNhanVien(int lichsuId);
    }
}
