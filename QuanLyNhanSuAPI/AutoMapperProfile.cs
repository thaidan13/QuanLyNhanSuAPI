using AutoMapper;
using QuanLyNhanSuAPI.DTO.HoSoNhanSuDTO;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<TbThongTinNhanVien, TbThongTinNhanVienDTO>();
            CreateMap<TbThongTinDoanDangDTO, TbThongTinDoanDang>();
        }
    }
}
