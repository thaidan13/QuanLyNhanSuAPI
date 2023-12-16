using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.KhenThuongKyLuatService
{
    public interface IKhenThuongKyLuatService
    {
        Task<ServiceResponse<List<TbKhenThuongKyLuat>>> GetKhenThuongKyLuatsAsync();
        Task<ServiceResponse<TbKhenThuongKyLuat>> GetKhenThuongKyLuatAsync(int khenThuongKyLuatId);
        Task<ServiceResponse<List<TbKhenThuongKyLuat>>> GetKhenThuongNhanVien(int nhanvienId);
        Task<ServiceResponse<List<TbKhenThuongKyLuat>>> GetKyLuatNhanVien(int nhanvienId);
        Task<ServiceResponse<TbKhenThuongKyLuat>> CreateKhenThuongKyLuat(TbKhenThuongKyLuat khenThuongKyLuat);
        Task<ServiceResponse<TbKhenThuongKyLuat>> UpdateKhenThuongKyLuat(TbKhenThuongKyLuat khenThuongKyLuat);
        Task<ServiceResponse<bool>> DeleteKhenThuongKyLuat(int khenThuongKyLuatId);
    }
}
