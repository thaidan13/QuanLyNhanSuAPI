using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.DiNuocNgoaiService
{
    public interface IDiNuocNgoaiService
    {
        Task<ServiceResponse<List<TbDiNuocNgoai>>> GetNuocNgoaisAsync();
        Task<ServiceResponse<TbDiNuocNgoai>> GetNuocNgoaiAsync(int nuocngoaiId);
        Task<ServiceResponse<List<TbDiNuocNgoai>>> GetNuocNgoaiNhanVien(int nhanvienId);
        Task<ServiceResponse<TbDiNuocNgoai>> CreateNuocNgoai(TbDiNuocNgoai nuocngoai);
        Task<ServiceResponse<TbDiNuocNgoai>> UpdateNuocNgoai(TbDiNuocNgoai nuocngoai);
        Task<ServiceResponse<bool>> DeleteTbDiNuocNgoai(int nuocngoaiId);
    }
}
