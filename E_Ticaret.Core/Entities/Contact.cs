using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Core.Entities
{
    public class Contact : IEntity // internal kısmını public olarak değiştirdik.
    {
        // İletişim kısmı için bu Class'ı kullanacağız
        public int Id { get; set; } // IEntity bölümünü eklememiz için bunu yazmamız gerekiyor

		[Display(Name = "Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez!")]  
        public string Name { get; set; }

		[Display(Name = "Soyadı"), Required(ErrorMessage = "{0} alanı boş geçilemez!")] 
        public string SurName { get; set; }

        public string? Email { get; set; }

		[Display(Name = "Telefon NO")] 
        public string? Phone { get; set; } // Telefon Zorunlu değil

		[Display(Name = "Mesaj"), Required(ErrorMessage = "{0} alanı boş geçilemez!")] 
        public string Message { get; set; }

		[Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)] 
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
