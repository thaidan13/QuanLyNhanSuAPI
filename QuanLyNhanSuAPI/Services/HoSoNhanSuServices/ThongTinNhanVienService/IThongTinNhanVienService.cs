using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinNhanVienService
{
    public interface IThongTinNhanVienService
    {
        Task<ServiceResponse<List<TbThongTinNhanVien>>> GetNhanViensAsync();
        Task<ServiceResponse<TbThongTinNhanVien>> GetNhanVienAsync(int nhanvienId);
        Task<ServiceResponse<TbThongTinNhanVien>> CreateNhanVien(TbThongTinNhanVien nhanvien);
        Task<ServiceResponse<TbThongTinNhanVien>> UpdateNhanVien(TbThongTinNhanVien nhanvien);
        Task<ServiceResponse<bool>> DeleteNhanVien(int nhanvienId);


        //Task<ServiceResponse<IEnumerable<TbThongTinNhanVien>>> GetPagedEntities(int pageNumber, int pageSize);
        //Task<ServiceResponse<int>> TotalEntityCount();
    }
}
