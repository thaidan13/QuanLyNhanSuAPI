using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Models
{
    public class NhanVienViewModel
    {
        public IEnumerable<TbThongTinNhanVien> Entities { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
