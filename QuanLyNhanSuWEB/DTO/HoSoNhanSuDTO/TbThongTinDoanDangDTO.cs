using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class TbThongTinDoanDangDTO
    {
        public List<TbThongTinDoanDang> DoanDangs { get; set; }

        public TbThongTinDoanDang DoanDang { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }
    }
}
