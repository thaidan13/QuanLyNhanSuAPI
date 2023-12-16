using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuWEB.DTO.HoSoNhanSuDTO
{
    public class DiNuocNgoaiDTO
    {

        public List<TbDiNuocNgoai> NuocNgoais { get; set; }

        public TbDiNuocNgoai NuocNgoai { get; set; }
        public TbThongTinNhanVien NhanVien { get; set; }


    }
}
