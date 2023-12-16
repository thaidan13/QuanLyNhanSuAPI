using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ChucVuService
{
    public interface IChucVuService
    {
        Task<ServiceResponse<List<TbChucVu>>> GetChucVusAsync();
        Task<ServiceResponse<TbChucVu>> GetChucVuAsync(int chucvuId);
        Task<ServiceResponse<int>> CreateChucVu(TbChucVu chucvu);
        Task<ServiceResponse<TbChucVu>> UpdateChucVu(TbChucVu chucvu);
        Task<ServiceResponse<bool>> DeleteChucVu(int chucvuId);
    }
}
