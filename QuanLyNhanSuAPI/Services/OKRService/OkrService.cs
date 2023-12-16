using QuanLyNhanSuAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Models.HoSoNhanSu;

namespace QuanLyNhanSuAPI.Services.OKRService
{
    public class OkrService : IOkrServices
    {
        private readonly DataContext _context;

        public OkrService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<TbOkr>> CreateOKR(TbOkr okr)
        {
            _context.TbOkrs.Add(okr);
            await _context.SaveChangesAsync();
            return new ServiceResponse<TbOkr> { Data = okr };
        }

        public async Task<ServiceResponse<bool>> DeleteOKRAdmin(int okrid)
        {
            var dbOkr = await _context.TbOkrs.FindAsync(okrid);
            if (dbOkr == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Okr not found."
                };
            }

            dbOkr.IsDelete = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<TbOkr>>> GetOKRAdminsAsync()
        {
            var response = new ServiceResponse<List<TbOkr>>
            {
                Data = await _context.TbOkrs.Where(p => (bool)!p.IsDelete).Include(p => p.LaKetQuaThenChotNavigation).Include(p => p.PhongBanNavigation).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<TbOkr>>> GetOKRNhanViensAsync(string email)
        {
            var taikhoanId = await _context.TbTaiKhoans
                .Where(taikhoan => taikhoan.Email == email)
                .Select(taikhoan => taikhoan.IdNv)
                .FirstOrDefaultAsync();

            var response = new ServiceResponse<List<TbOkr>>
            {
                Data = await _context.TbOkrs
                    .Where(nhanvien => nhanvien.NhanVien == taikhoanId && (bool)!nhanvien.IsDelete).Include(p => p.LaKetQuaThenChotNavigation).Include(p => p.PhongBanNavigation).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TbOkr>> GetOKRNhanVienAsync(int id)
        {
            var response = new ServiceResponse<TbOkr>();

            TbOkr okr = null;

            okr = await _context.TbOkrs.Where(p => (bool)!p.IsDelete).Include(p => p.InverseLaKetQuaThenChotNavigation).FirstOrDefaultAsync(p => p.IdOkr == id);

            if(okr == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = okr;
            }
            return response;
        }

        public async Task<ServiceResponse<TbOkr>> UpdateOKRAdmin(TbOkr okr)
        {
            var dbOkr = await _context.TbOkrs.FirstOrDefaultAsync(p => p.IdOkr == okr.IdOkr);

            if(dbOkr == null)
            {
                return new ServiceResponse<TbOkr>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            dbOkr.Nam = okr.Nam;
            dbOkr.Quy = okr.Quy;
            dbOkr.TieuDe = okr.TieuDe;
            dbOkr.MoTa = okr.MoTa;
            dbOkr.MucTieu = okr.MucTieu;
            dbOkr.KieuOkr = okr.KieuOkr;
            dbOkr.LaKetQuaThenChot = okr.LaKetQuaThenChot;
            dbOkr.Diem = okr.Diem;
            dbOkr.TrongSo = okr.TrongSo;
            dbOkr.ChuSoHuu = okr.ChuSoHuu;
            dbOkr.NhanVien = okr.NhanVien;
            dbOkr.PhongBan = okr.PhongBan;

            await _context.SaveChangesAsync();
            return new ServiceResponse<TbOkr> { Data = okr };

        }

        public async Task<ServiceResponse<TbOkr>> UpdateOKRNhanVien(TbOkr okr)
        {
            var dbOkr = await _context.TbOkrs.FirstOrDefaultAsync(p => p.IdOkr == okr.IdOkr);
            var laydiemthanhcong = await _context.DiemThanhCongCuaOkrs.FirstOrDefaultAsync(p => p.Id == 1);

            if (dbOkr == null)
            {
                return new ServiceResponse<TbOkr>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            double diemokrcon = (double)okr.Diem;

            dbOkr.Diem = okr.Diem;
            //dbOkr.TrongSo = okr.TrongSo;
            //dbOkr.KetQua = okr.KetQua;

            if(dbOkr.KieuOkr == "Cam Kết")
            {
                if (diemokrcon >= 1)
                {
                    okr.KetQua = true;
                    dbOkr.KetQua = okr.KetQua;
                }
                else
                {
                    okr.KetQua = false;
                    dbOkr.KetQua = okr.KetQua;
                }
            }
            else if (dbOkr.KieuOkr == "Khát Vọng")
            {
                if (diemokrcon >= laydiemthanhcong.Diem)
                {
                    okr.KetQua = true;
                    dbOkr.KetQua = okr.KetQua;
                }
                else
                {
                    okr.KetQua = false;
                    dbOkr.KetQua = okr.KetQua;
                }
            }

            await _context.SaveChangesAsync();

            double diemMoi = await TinhDiemOKRCha((int)dbOkr.LaKetQuaThenChot);

            return new ServiceResponse<TbOkr> { Data = okr };
        }

        public async Task<int> CountChildOKRs(int okrChaId)
        {
            int count = await _context.TbOkrs.CountAsync(p => p.LaKetQuaThenChot == okrChaId); return count;
        }

        public async Task<ServiceResponse<DiemThanhCongCuaOkr>> GetDiemThanhCongs()
        {
            var response = new ServiceResponse<DiemThanhCongCuaOkr>();

            DiemThanhCongCuaOkr diemokr = null;

            diemokr = await _context.DiemThanhCongCuaOkrs.FirstOrDefaultAsync(p => p.Id == 1);
            if (diemokr == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = diemokr;
            }

            return response;
            //var response = new ServiceResponse<List<DiemThanhCongCuaOkr>>
            //{
            //    Data = await _context.DiemThanhCongCuaOkrs.FirstOrDefaultAsync(p => p.Id == 1)
            //};
            //return response;
        }

        public async Task<double> TinhDiemOKRCha(int okrChaId)
        {
            var okrCha = await _context.TbOkrs.FindAsync(okrChaId); // Lấy OKR cha từ cơ sở dữ liệu

            if (okrCha == null)
            {
                return 0; // Hoặc xử lý theo cách khác nếu không tìm thấy OKR cha
            }

            var laydiemthanhcong = await _context.DiemThanhCongCuaOkrs.FirstOrDefaultAsync(p => p.Id == 1);

            var okrConList = await _context.TbOkrs.Where(p => p.LaKetQuaThenChot == okrChaId).ToListAsync();
            double diemTongCong = 0;
            double trongSoTongCong = 0;

            if (okrConList.Count > 0)
            {
                foreach (var okrCon in okrConList)
                {
                    diemTongCong += okrCon.Diem.Value * (double)okrCon.TrongSo;
                    trongSoTongCong += (double)okrCon.TrongSo.Value;
                }
            }
                
            if (trongSoTongCong > 0)
            {
                var diemMoi = diemTongCong / trongSoTongCong;

                // Cập nhật giá trị điểm mới vào OKR cha
                okrCha.Diem = diemMoi;

                if(okrCha.KieuOkr == "Cam Kết")
                {
                    if(diemMoi >= 1)
                    {
                        okrCha.KetQua = true;
                    }
                    else
                    {
                        okrCha.KetQua = false;
                    }
                }else if(okrCha.KieuOkr == "Khát Vọng")
                {
                    if(diemMoi >= laydiemthanhcong.Diem)
                    {
                        okrCha.KetQua = true;
                    }
                    else
                    {
                        okrCha.KetQua = false;
                    }
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                _context.Entry(okrCha).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return diemMoi;
            }
            else
            {
                return 0;
            }
        }

        public async Task<ServiceResponse<List<DiemThanhCongCuaOkr>>> GetDiemThanhCong()
        {
            var response = new ServiceResponse<List<DiemThanhCongCuaOkr>>
            {
                Data = await _context.DiemThanhCongCuaOkrs.ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<DiemThanhCongCuaOkr>> UpdateDiemThanhCong(DiemThanhCongCuaOkr diemokr)
        {
            var response = await _context.DiemThanhCongCuaOkrs.FirstOrDefaultAsync(p => p.Id == diemokr.Id);
            if (response == null)
            {
                return new ServiceResponse<DiemThanhCongCuaOkr>
                {
                    Success = false,
                    Message = "Dữ liệu không tồn tại!"
                };
            }

            response.Diem = diemokr.Diem;

            await _context.SaveChangesAsync();
            return new ServiceResponse<DiemThanhCongCuaOkr> { Data = diemokr };
        }

        public async Task<ServiceResponse<DiemThanhCongCuaOkr>> GetDiem(int diemid)
        {
            var response = new ServiceResponse<DiemThanhCongCuaOkr>();
            DiemThanhCongCuaOkr diem = null;
            diem = await _context.DiemThanhCongCuaOkrs.FirstOrDefaultAsync(p => p.Id == diemid);
            if (diem == null)
            {
                response.Success = false;
                response.Message = "Không có dữ liệu!.";
            }
            else
            {
                response.Data = diem;
            }

            return response;
        }
    }
}
