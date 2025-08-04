using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Core.Entities
{
    public class Product : IEntity // internal kısmını public yaptık.
    {
        // Duyuru, Bildirim, Haber, Kampanya için bu kısmı kullanacağız.

        public int Id { get; set; } // IEntity bölümünü eklememiz için bunu yazmamız gerekiyor
		[Display(Name = "Adı")] 
        public string Name { get; set; } // Markanın ismi
		[Display(Name = "Açıklama")] 
        public string? Description { get; set; }
		[Display(Name = "Resim")] 
        public string? Image { get; set; } // Kategoriye müşteri resim kullanmak isteyebilir

		[Display(Name = "Fiyat")] 
        public decimal Price { get; set; } // Ürünün fiyatı için bu kısmı ekledik.

		[Display(Name = "Ürün Kodu")] 
        public string? ProductCode { get; set; } // Ürün kodu için bu kısmı ekledik.

		[Display(Name = "Stok")] 
        public int Stock {  get; set; }
		[Display(Name = "Aktif?")] 
        public bool IsActive { get; set; } // bir markayı aktif veya pasif edebilmek için bunu ekledik.
										   // böylece panelden tek tıkla tüm markaya ait içerikleri 
		[Display(Name = "Anasayfada Göster")] 
        public bool IsHome { get; set; } // Böylece ürünü anasayfada gösterebilicez
		[Display(Name = "Kategori ID")] 
        public int? CategoryID { get; set; }
		[Display(Name = "Kategori")]
		public Category? Category { get; set; } // Böylece Navigation Property üzerinden ürünün kategori bilgisine ulaşabilicez
		[Display(Name = "Marka ID")] 
        public int? BrandID { get; set; } // Marka ID'si için bu kısmı ekledik.
		[Display(Name = "Marka")]
		public Brand? Brand { get; set; } // Böylece Navigation Property üzerinden ürünün kategori bilgisine ulaşabilicez
		[Display(Name = "Sıra NO")] 
		public int OrderNo { get; set; } // Sıra Numarası 
		[Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)] 
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
