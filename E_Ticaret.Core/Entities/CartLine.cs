using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret.Core.Entities
{
	public class CartLine
	{
		public int Id { get; set; } // id
		public Product Product { get; set; } // ürün
		public int Quantity { get; set; } // miktar
	}
}
