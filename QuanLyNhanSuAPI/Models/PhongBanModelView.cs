namespace QuanLyNhanSuAPI.Models
{
    public class PhongBanModelView
    {
        public int IdPb { get; set; }

        public int IdNv { get; set; }

        public string TenPhongBan { get; set; } = null!;

        public string QuanLy { get; set; }
    }
}
