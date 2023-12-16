using QuanLyNhanSuAPI.Models.HoSoNhanSu;
using QuanLyNhanSuAPI.Models;

namespace QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinChinhTriService
{
    public interface IThongTinChinhTriService
    {
        Task<ServiceResponse<List<TbThongTinChinhTri>>> GetChinhTrisAsync();
        Task<ServiceResponse<TbThongTinChinhTri>> GetChinhTriAsync(int chinhtriId);
        Task<ServiceResponse<List<TbThongTinChinhTri>>> GetChinhTriNhanVien(int nhanvienId);
        Task<ServiceResponse<TbThongTinChinhTri>> CreateChinhTri(TbThongTinChinhTri chinhtri);
        Task<ServiceResponse<TbThongTinChinhTri>> UpdateChinhTri(TbThongTinChinhTri chinhtri);
        Task<ServiceResponse<bool>> DeleteChinhTri(int chinhtriId);
    }
}
