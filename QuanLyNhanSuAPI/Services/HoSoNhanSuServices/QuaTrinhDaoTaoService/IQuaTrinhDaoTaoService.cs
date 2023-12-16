using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhDaoTaoService
{
    public interface IQuaTrinhDaoTaoService
    {
        Task<ServiceResponse<List<TbQuaTrinhDaoTao>>> GetQuaTrinhDaoTaosAsync();
        Task<ServiceResponse<TbQuaTrinhDaoTao>> GetQuaTrinhDaoTaoAsync(int qtdtid);
        Task<ServiceResponse<List<TbQuaTrinhDaoTao>>> GetDaoTaoNhanVien(int nhanvienId);
        Task<ServiceResponse<TbQuaTrinhDaoTao>> CreateQuaTrinhDaoTao(TbQuaTrinhDaoTao qtdt);
        Task<ServiceResponse<TbQuaTrinhDaoTao>> UpdateQuaTrinhDaoTao(TbQuaTrinhDaoTao qtdt);
        Task<ServiceResponse<bool>> DeleteQuaTrinhDaoTao(int qtdtid);
    }
}
