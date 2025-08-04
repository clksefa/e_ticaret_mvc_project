using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.WebUI.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress), Required(ErrorMessage = "Email Boş Geçilemez!")]
        public string Email { get; set; } // Email kısmını ekledik
        [Display(Name = "Şifre")]
        [DataType(DataType.Password), Required(ErrorMessage = "Şifre Boş Geçilemez!")]
        public string Password { get; set; } // Şifre kısmını ekledik
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }

    }
}
