﻿using E_Ticaret.Core.Entities;

namespace E_Ticaret.WebUI.Models
{
	public class CartViewModel
	{
        public List<CartLine>? CartLines { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
