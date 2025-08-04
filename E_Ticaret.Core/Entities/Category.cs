using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Core.Entities
{
    public class Category : IEntity// internal kısmını public yaptık.
    {
        // Kategori adında sınıf oluşturduk.

        public int Id { get; set; } // IEntity bölümünü eklememiz için bunu yazmamız gerekiyor
		[Display(Name = "Adı")]  
        public string Name { get; set; } // Markanın ismi

		[Display(Name = "Açıklama")] 
        public string? Description { get; set; }

		[Display(Name = "Resim")] 
        public string? Image { get; set; } // Kategoriye müşteri resim kullanmak isteyebilir

		[Display(Name = "Aktif?")] 
        public bool IsActive { get; set; } // bir markayı aktif veya pasif edebilmek için bunu ekledik.
										   // böylece panelden tek tıkla tüm markaya ait içerikleri 

		[Display(Name = "Üst Menüde Göster")] 
        public bool IsTopMenu { get; set; } // Üst Menüde Göster 

		[Display(Name = "Üst Kategori")] 
        public int ParentID { get; set; } // Ana kategorinin altına alt kategoriler eklemek için bu özelliği 

		[Display(Name = "Sıra NO")] 
        public int OrderNo { get; set; } // Sıra Numarası 
		[Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)] 
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public IList<Product>? Products { get; set; } // Bu kategorinin ürünleri olabileceği için bu kısmı ekledik
                                                      // Yani bir kategorinin birden fazla ürünü olabilir.
    }
}
