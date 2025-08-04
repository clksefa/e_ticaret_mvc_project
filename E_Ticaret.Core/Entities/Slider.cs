using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Core.Entities
{
    public class Slider : IEntity // internal kısmını public olarak değiştirdik.
    {

        // Giriş sayfamızda dönen alanları temsil edecek.

        public int Id { get; set; } // IEntity bölümünü eklememiz için bunu yazmamız gerekiyor

		[Display(Name = "Başlık")] 
        public string Title { get; set; } // Başlık alanı

		[Display(Name = "Açıklama")] 
        public string? Description { get; set; } // Açıklama alanı

		[Display(Name = "Resim")] 
        public string? Image {  get; set; }

        public string? Link { get; set; } // Kampanya banner'ı koyduğumuzda, resme tıklandığında açılacak sayfa için bu alanı oluşturduk.
    }
}
