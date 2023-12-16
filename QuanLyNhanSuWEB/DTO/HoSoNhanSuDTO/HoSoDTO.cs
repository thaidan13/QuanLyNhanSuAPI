using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class HoSoDTO
    {
        public List<TbHoSo> HoSos { get; set; }

        public TbHoSo HoSo { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }
    }
}
