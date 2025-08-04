using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Core.Entities
{
    public class Brand : IEntity // internal kısmını public yaptık
    {
        // Markalarımızı tutacağımız sınıf burası

        public int Id { get; set; } // IEntity bölümünü eklememiz için bunu yazmamız gerekiyor.
		[Display(Name = "Adı")] 
        public string Name { get; set; } // Markanın ismi
		[Display(Name = "Açıklama")] 
        public string? Description { get; set; }
        public string? Logo { get; set; }

		[Display(Name = "Aktif ?")] 
        public bool IsActive { get; set; } // bir markayı aktif veya pasif edebilmek için bunu ekledik.
										   // böylece panelden tek tıkla tüm markaya ait içerikleri sistemden kaldırabiliriz
		[Display(Name = "Sıra NO")] 
        public int OrderNo { get; set; } // Sır Numarası ekledik
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public IList<Product>? Products { get; set; }
    }
}
