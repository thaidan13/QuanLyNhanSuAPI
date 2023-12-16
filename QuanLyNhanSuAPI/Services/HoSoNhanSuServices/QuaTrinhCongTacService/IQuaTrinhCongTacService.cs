using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhCongTacService
{
    public interface IQuaTrinhCongTacService
    {
        Task<ServiceResponse<List<TbQuaTrinhCongTac>>> GetCongTacsAsync();
        Task<ServiceResponse<TbQuaTrinhCongTac>> GetCongTacAsync(int congtacId);
        Task<ServiceResponse<List<TbQuaTrinhCongTac>>> GetCongTacNhanVien(int nhanvienId);

        Task<ServiceResponse<List<TbQuaTrinhCongTac>>> GetCongTacNgoaiCongTys(int nhanvienId);
        Task<ServiceResponse<List<TbQuaTrinhCongTac>>> GetCongTacTrongCongTys(int nhanvienId);

        Task<ServiceResponse<TbQuaTrinhCongTac>> CreateCongTac(TbQuaTrinhCongTac congtac);
        Task<ServiceResponse<TbQuaTrinhCongTac>> UpdateCongTac(TbQuaTrinhCongTac congtac);
        Task<ServiceResponse<bool>> DeleteCongTac(int congtacId);
    }
}
