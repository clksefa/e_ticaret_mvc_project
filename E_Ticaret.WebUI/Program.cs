using E_Ticaret.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using E_Ticaret.Service.Abstract;
using E_Ticaret.Service.Concrete;

namespace E_Ticaret.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".Eticaret.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.IOTimeout = TimeSpan.FromMinutes(10);
            });

		    builder.Services.AddDbContext<DatabaseContext>();

            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                x=> { x.LoginPath = "/Account/SignIn";
                    x.AccessDeniedPath = "/AccessDenied"; // eriþim engellendi ekraný
                    x.Cookie.Name = "Account";
                    x.Cookie.MaxAge = TimeSpan.FromDays(1); // yaþam süresi yani kullanýcý oturum açtýðýnda geçerlilik süresi
                    x.Cookie.IsEssential = true; // kalýcý cookie oluþmasýný saðlýyoruz
                                                                         }
                      );

            builder.Services.AddAuthorization(x=> {
                x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
                x.AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User", "Customer"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession(); // session kullanýlacak

            app.UseAuthentication(); // BU ÖNCE GELÝCEK - ÖNCE OTURUM AÇMA
            app.UseAuthorization(); // SONRA YETKÝLENDÝRME

            app.MapControllerRoute( // Scaffoldingi projemize eklemek için bunu kullandýk.
            name: "admin", // name kýsmýný admin yaptýk
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"); // controllerdaki Home kýsmýný Main olarak deðiþtirdik.

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
