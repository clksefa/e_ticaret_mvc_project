using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.WebUI.Models
{
    public class UserEditViewModel
    {
        public int Id { get; set; } // IEntitş bölümünü eklememiz için bunu yazmamız gerekiyor
                                    // IEntity kısmındaki kodları buraya yazdık
        [Display(Name = "Adı")]
        public string Name { get; set; } // Name kısmını ekledik

        [Display(Name = "Soyadı")]
        public string SurName { get; set; } // Soyad kısmını ekledik
        public string Email { get; set; } // Email kısmını ekledik

        [Display(Name = "Telefon NO")]
        public string? Phone { get; set; } // Email kısmını ekledik
                                           // Zorunlu olmasın istiyorsak başına ? koyuyoruz.

        [Display(Name = "Şifre")]
        public string Password { get; set; } // Şifre kısmını ekledik
    }
}
