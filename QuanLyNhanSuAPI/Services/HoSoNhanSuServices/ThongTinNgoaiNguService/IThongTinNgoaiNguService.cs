using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinNgoaiNguService
{
    public interface IThongTinNgoaiNguService
    {
        Task<ServiceResponse<List<TbThongTinNgoaiNgu>>> GetNgoaiNgusAsync();
        Task<ServiceResponse<TbThongTinNgoaiNgu>> GetNgoaiNguAsync(int ngoainguId);
        Task<ServiceResponse<List<TbThongTinNgoaiNgu>>> GetNgoaiNguNhanVien(int nhanvienId);
        Task<ServiceResponse<TbThongTinNgoaiNgu>> CreateNgoaiNgu(TbThongTinNgoaiNgu ngoaingu);
        Task<ServiceResponse<TbThongTinNgoaiNgu>> UpdateNgoaiNgu(TbThongTinNgoaiNgu ngoaingu);
        Task<ServiceResponse<bool>> DeleteNgoaiNgu(int ngoainguId);
    }
}
