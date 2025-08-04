using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Core.Entities
{
    public class AppUser : IEntity // internal ifadesini public ile değiştirdik.
                                   // IEntity kısmını buraya ekledik.
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

		[Display(Name = "Kullanıcı Adı")] 
        public string? Username { get; set; } // Kullanıcı Adı kısmını ekledik

		[Display(Name = "Aktif ?")] 
        public bool IsActive { get; set; } // Aktif üyeler için boolean veritipinde ekledik

		[Display(Name = "Admin ?")] 
        public bool IsAdmin { get; set; } // Admin için boolean veritipinde 

		[Display(Name = "Kayıt Tarihi") , ScaffoldColumn(false)] 
        public DateTime CreateDate { get; set; } = DateTime.Now; // Tarih ekledik
        
        [ScaffoldColumn(false)]
        public Guid? UserGuid { get; set; } = Guid.NewGuid(); // Eğer boşsa yeni bir Guid değeri oluştursun


    }
}
