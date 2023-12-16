using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhLamViecCuaThanNhanService
{
    public interface IQuaTrinhLamViecCuaThanNhanService
    {
        Task<ServiceResponse<List<TbQuaTrinhLamViecCuaThanNhan>>> GetThanNhanLamViecsAsync(int thannhanId);
        Task<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>> GetThanNhanLamViecAsync(int thannhanlamviecId);
        //Task<ServiceResponse<List<TbQuaTrinhLamViecCuaThanNhan>>> GetNuocNgoaiNhanVien(int nhanvienId);
        Task<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>> CreateThanNhanLamViec(TbQuaTrinhLamViecCuaThanNhan thannhanlamviec);
        Task<ServiceResponse<TbQuaTrinhLamViecCuaThanNhan>> UpdateThanNhanLamViec(TbQuaTrinhLamViecCuaThanNhan thannhanlamviec);
        Task<ServiceResponse<bool>> DeleteThanNhanLamViec(int thannhanlamviecIdId);
    }
}
