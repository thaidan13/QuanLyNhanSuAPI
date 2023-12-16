using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class QuaTrinhLamViecCuaThanNhanDTO
    {
        public List<TbQuaTrinhLamViecCuaThanNhan> LamViecs { get; set; }

        public TbQuaTrinhLamViecCuaThanNhan LamViec { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }
        public TbThongTinGiaDinh GiaDinh { get; set; }
    }
}
