using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class QuaTrinhDaoTaoDTO
    {
        public List<TbQuaTrinhDaoTao> QuaTrinhDaoTaos { get; set; }
        public List<TbThongTinNgoaiNgu> NgoaiNgus { get; set; }
        public List<TbThongTinViTinh> ViTinhs { get; set; }
        public List<TbThongTinChinhTri> ChinhTris { get; set; }

        public TbQuaTrinhDaoTao QuaTrinhDaoTao { get; set; }
        public TbThongTinNgoaiNgu NgoaiNgu { get; set; }
        public TbThongTinViTinh ViTinh { get; set; }
        public TbThongTinChinhTri ChinhTri { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }
    }
}
