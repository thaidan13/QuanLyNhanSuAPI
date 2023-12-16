using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class DaoTaoCuMoiDTO
    {
        public List<TbQuaTrinhDaoTaoCuMoi> DaoTaos { get; set; }

        public TbQuaTrinhDaoTaoCuMoi DaoTao { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }
    }
}
