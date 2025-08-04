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
                    x.AccessDeniedPath = "/AccessDenied"; // eri�im engellendi ekran�
                    x.Cookie.Name = "Account";
                    x.Cookie.MaxAge = TimeSpan.FromDays(1); // ya�am s�resi yani kullan�c� oturum a�t���nda ge�erlilik s�resi
                    x.Cookie.IsEssential = true; // kal�c� cookie olu�mas�n� sa�l�yoruz
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
            app.UseSession(); // session kullan�lacak

            app.UseAuthentication(); // BU �NCE GEL�CEK - �NCE OTURUM A�MA
            app.UseAuthorization(); // SONRA YETK�LEND�RME

            app.MapControllerRoute( // Scaffoldingi projemize eklemek i�in bunu kulland�k.
            name: "admin", // name k�sm�n� admin yapt�k
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"); // controllerdaki Home k�sm�n� Main olarak de�i�tirdik.

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
