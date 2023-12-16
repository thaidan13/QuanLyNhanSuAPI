using Microsoft.EntityFrameworkCore;
using QuanLyNhanSuAPI.Data;
using QuanLyNhanSuAPI.Services.AuthService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ChucVuService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.DiNuocNgoaiService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.HoSoService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.KhenThuongKyLuatService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.LichSuBanThanNhanVienService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.PhongBanService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhCongTacService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhDaoTaoCuMoiService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhDaoTaoService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.QuaTrinhLamViecCuaThanNhanService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinChinhTriService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinDoanDangService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinGiaDinhService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinHopDongLaoDongService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinNgoaiNguService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinNhanVienService;
using QuanLyNhanSuAPI.Services.HoSoNhanSuServices.ThongTinViTinhService;
using QuanLyNhanSuAPI.Services.OKRService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IChucVuService, ChucVuService>();
builder.Services.AddScoped<IPhongBanService, PhongBanService>();
builder.Services.AddScoped<IThongTinNhanVienService, ThongTinNhanVienService>();
builder.Services.AddScoped<IQuaTrinhDaoTaoService, QuaTrinhDaoTaoService>();
builder.Services.AddScoped<IThongTinNgoaiNguService, ThongTinNgoaiNguService>();
builder.Services.AddScoped<IThongTinViTinhService, ThongTinViTinhService>();
builder.Services.AddScoped<IThongTinChinhTriService, ThongTinChinhTriService>();
builder.Services.AddScoped<IThongTinDoanDangService, ThongTinDoanDangService>();
builder.Services.AddScoped<IDiNuocNgoaiService, DiNuocNgoaiService>();
builder.Services.AddScoped<IQuaTrinhDaoTaoCuMoiService, QuaTrinhDaoTaoCuMoiService>();
builder.Services.AddScoped<IKhenThuongKyLuatService, KhenThuongKyLuatService>();
builder.Services.AddScoped<IHoSoService, HoSoService>();
builder.Services.AddScoped<IThongTinGiaDinhService, ThongTinGiaDinhService>();
builder.Services.AddScoped<IQuaTrinhLamViecCuaThanNhanService, QuaTrinhLamViecCuaThanNhanService>();
builder.Services.AddScoped<IThongTinHopDongLaoDongService, ThongTinHopDongLaoDongService>();
builder.Services.AddScoped<IQuaTrinhDaoTaoService,  QuaTrinhDaoTaoService>();
builder.Services.AddScoped<ILichSuBanThanNhanVienService, LichSuBanThanService>();
builder.Services.AddScoped<IQuaTrinhCongTacService, QuaTrinhCongTacService>();


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOkrServices, OkrService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
