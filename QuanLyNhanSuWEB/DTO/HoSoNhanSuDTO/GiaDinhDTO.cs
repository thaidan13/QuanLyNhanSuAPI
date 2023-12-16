using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class GiaDinhDTO
    {
        public List<TbThongTinGiaDinh> GiaDinhs { get; set; }

        public TbThongTinGiaDinh GiaDinh { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }
    }
}
