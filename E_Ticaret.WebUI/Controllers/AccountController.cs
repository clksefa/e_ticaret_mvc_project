using E_Ticaret.Core.Entities;
using E_Ticaret.Data;
using E_Ticaret.Service.Abstract;
using E_Ticaret.WebUI.Models;
using Microsoft.AspNetCore.Authentication; // login
using Microsoft.AspNetCore.Authorization; // login
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims; // login kütüphanesi

namespace E_Ticaret.WebUI.Controllers
{
    public class AccountController : Controller
    {
        //private readonly DatabaseContext _context;

        //public AccountController(DatabaseContext context)
        //{
        //    _context = context;
        //}

        private readonly IService<AppUser> _service;

        public AccountController(IService<AppUser> service)
        {
            _service = service;
        }

        [Authorize]
        public async Task<IActionResult> IndexAsync()
        {
            AppUser user = await _service.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            if (user is null)
            { return NotFound(); }
            var model = new UserEditViewModel()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Phone = user.Phone,
                SurName = user.SurName,
            };
            return View(model);
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> IndexAsync(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser user = await _service.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
                    if (user is not null)
                    {
                        user.SurName = model.SurName;
                        user.Email = model.Email;
                        user.Phone = model.Phone;
                        user.Name = model.Name;
                        user.Password = model.Password;
                        _service.Update(user);
                        var sonuc = _service.SaveChanges();
                        if (sonuc > 0)
                        {
                            TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
  <strong>Kullanıcı Bilgileriniz Güncellenmiştir!</strong> 
  <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
</div>";
                            // await MailHelper.SendMailAsync(contact);  BURAYI AKTİF ETTİĞİMİZDE MAİL SİSTEMİ ÇALIŞACAK
                            return RedirectToAction("Index");
                        }
                    }

                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Hata oluştu!");
                }
            }
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = await _service.GetAsync(x => x.Email == loginViewModel.Email & x.Password == loginViewModel.Password & x.IsActive);
                    if (account == null)
                    {
                        ModelState.AddModelError("", "Giriş Başarısız!");
                    }
                    else
                    {
                        var claims = new List<Claim>()
                    {
                            new(ClaimTypes.Name, account.Name),
                            new(ClaimTypes.Role, account.IsAdmin ? "Admin" : "Müşteri"),
                            new(ClaimTypes.Email, account.Email),
                            new("UserId", account.Id.ToString()),
                            new("UserGuid", account.UserGuid.ToString()),
                        };
                        var userIdentity = new ClaimsIdentity(claims, "Login");
                        ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                        await HttpContext.SignInAsync(userPrincipal);
                        return Redirect(string.IsNullOrEmpty(loginViewModel.ReturnUrl) ? "/" : loginViewModel.ReturnUrl);
                    }
                }
                catch (Exception hata)
                {
                    // loglama
                    ModelState.AddModelError("", "Hata oluştu!");

                }
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUpAsync(AppUser appUser)
        {
            appUser.IsAdmin = false;
            appUser.IsActive = true;
            if (ModelState.IsValid)
            {
                await _service.AddAsync(appUser);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(IndexAsync));
            }
            return View(appUser);
        }
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}
