using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class KhenThuongKyLuatDTO
    {
        public List<TbKhenThuongKyLuat> KhenThuongKyLuats { get; set; }

        public TbKhenThuongKyLuat KhenThuongKyLuat { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }
    }
}
