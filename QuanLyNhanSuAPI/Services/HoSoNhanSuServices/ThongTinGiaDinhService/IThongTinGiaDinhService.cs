using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinGiaDinhService
{
    public interface IThongTinGiaDinhService
    {
        Task<ServiceResponse<List<TbThongTinGiaDinh>>> GetGiaDinhsAsync();
        Task<ServiceResponse<TbThongTinGiaDinh>> GetGiaDinhAsync(int giadinhId);
        Task<ServiceResponse<List<TbThongTinGiaDinh>>> GetGiaDinhNhanVien(int nhanvienId);
        Task<ServiceResponse<TbThongTinGiaDinh>> CreateGiaDinh(TbThongTinGiaDinh giadinh);
        Task<ServiceResponse<TbThongTinGiaDinh>> UpdateGiaDinh(TbThongTinGiaDinh giadinh);
        Task<ServiceResponse<bool>> DeleteGiaDinh(int giadinhId);
    }
}
