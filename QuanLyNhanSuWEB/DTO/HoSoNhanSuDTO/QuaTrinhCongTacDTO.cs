using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class QuaTrinhCongTacDTO
    {
        public List<TbQuaTrinhCongTac> NgoaiCongTacs { get; set; }
        public List<TbQuaTrinhCongTac> TrongCongTacs { get; set; }

        public TbQuaTrinhCongTac CongTac { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }
    }
}
