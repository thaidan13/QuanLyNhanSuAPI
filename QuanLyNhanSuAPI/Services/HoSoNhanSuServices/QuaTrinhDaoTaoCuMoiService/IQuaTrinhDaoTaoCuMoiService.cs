using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhDaoTaoCuMoiService
{
    public interface IQuaTrinhDaoTaoCuMoiService
    {
        Task<ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>> GetDaoTaoCuMoisAsync();
        Task<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>> GetDaoTaoCuMoiAsync(int daotaoid);
        Task<ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>> GetDaoTaoCuNhanVien(int nhanvienId);
        Task<ServiceResponse<List<TbQuaTrinhDaoTaoCuMoi>>> GetDaoTaoMoiNhanVien(int nhanvienId);
        Task<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>> CreateDaoTaoCuMoi(TbQuaTrinhDaoTaoCuMoi daotao);
        Task<ServiceResponse<TbQuaTrinhDaoTaoCuMoi>> UpdateDaoTaoCuMoi(TbQuaTrinhDaoTaoCuMoi daotao);
        Task<ServiceResponse<bool>> DeleteDaoTaoCuMoi(int daotaoid);
    }
}
