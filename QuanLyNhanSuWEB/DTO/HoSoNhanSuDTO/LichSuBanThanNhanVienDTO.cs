using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class LichSuBanThanNhanVienDTO
    {
        public List<TbLichSuBanThanNhanVien> LichSuNhanViens { get; set; }

        public TbLichSuBanThanNhanVien LichSuNhanVien { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }
    }
}
