using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class HopDongLaoDongDTO
    {
        public List<TbThongTinHopDongLaoDong> HopDongs { get; set; }
        public IFormFile File { get; set; }
        public IFormFile FileQuyetDinh { get; set; }

        public TbThongTinHopDongLaoDong HopDong { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }
    }
}
