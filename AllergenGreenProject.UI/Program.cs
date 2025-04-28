using AllergenGreenProject.UI.Context;
using AllergenGreenProject.UI.Entities;
using AlergenProject.UI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;



// Serilog loglama yapılandırması
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Serilog'u etkinleştiriyoruz
builder.Host.UseSerilog();

// MVC ve oturum servisi ekliyoruz
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// DbContext konfigürasyonu
builder.Services.AddDbContext<AllergenDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity konfigürasyonu
builder.Services.AddIdentity<Kullanicilar, AppRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // Email doğrulama istemiyoruz
})
.AddEntityFrameworkStores<AllergenDbContext>()
.AddDefaultTokenProviders(); // Token sağlayıcılar (şifre resetleme vs.)

// Cookie ayarları
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Kullanici/Misafir";                // Giriş yapmadıysa buraya yönlendir
    options.AccessDeniedPath = "/Kullanici/ErisimYok";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);     // 5 dakika oturum süresi
    options.SlidingExpiration = false;                    // Süre uzamasın
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    options.Cookie.Name = "LoveGreenAuth";                // Cookie adı
});

var app = builder.Build();

// Hatalar için middleware'ler
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Standart middleware sırası
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePagesWithReExecute("/Kullanici/ErisimYok");



// Route ayarı
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Kullanici}/{action=Misafir}/{id?}");

app.MapRazorPages();
app.Run();
