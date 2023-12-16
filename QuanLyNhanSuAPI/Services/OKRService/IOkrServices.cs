using QuanLyNhanSuAPI.Models;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.OKRService
{
    public interface IOkrServices
    {
        Task<int> CountChildOKRs(int okrChaId);

        Task<double> TinhDiemOKRCha(int okrChaId);

        Task<ServiceResponse<DiemThanhCongCuaOkr>> GetDiem(int diemid);

        Task<ServiceResponse<DiemThanhCongCuaOkr>> GetDiemThanhCongs();

        Task<ServiceResponse<List<DiemThanhCongCuaOkr>>> GetDiemThanhCong();

        Task<ServiceResponse<List<TbOkr>>> GetOKRAdminsAsync();

        Task<ServiceResponse<List<TbOkr>>> GetOKRNhanViensAsync(string email);

        Task<ServiceResponse<TbOkr>> GetOKRNhanVienAsync(int id);

        Task<ServiceResponse<TbOkr>> CreateOKR(TbOkr okr);

        Task<ServiceResponse<TbOkr>> UpdateOKRAdmin(TbOkr okr);

        Task<ServiceResponse<TbOkr>> UpdateOKRNhanVien(TbOkr okr);

        Task<ServiceResponse<DiemThanhCongCuaOkr>> UpdateDiemThanhCong(DiemThanhCongCuaOkr diemokr);

        Task<ServiceResponse<bool>> DeleteOKRAdmin(int okrid);
    }
}
