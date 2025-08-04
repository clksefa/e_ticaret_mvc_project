using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Core.Entities
{
    public class News : IEntity // internal kısmını public yaptık.
    {
        // Duyuru, Bildirim, Haber, Kampanya için bu kısmı kullanacağız.

        public int Id { get; set; } // IEntity bölümünü eklememiz için bunu yazmamız gerekiyor

		[Display(Name = "Adı")] 
        public string Name { get; set; }

		[Display(Name = "Açıklama")] 
        public string? Description { get; set; }

		[Display(Name = "Resim")] 
        public string? Image {  get; set; }

		[Display(Name = "Aktif ?")] 
        public bool IsActive { get; set; }

		[Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)] 
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
