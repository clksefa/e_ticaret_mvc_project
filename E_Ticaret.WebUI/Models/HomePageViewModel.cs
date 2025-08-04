﻿using E_Ticaret.Core.Entities;

namespace E_Ticaret.WebUI.Models
{
    public class HomePageViewModel
    {
        public List<Slider>? Sliders { get; set; } // Boş olabilir o yüzden ? ekledik
        public List<Product>? Products { get; set; }
        public List<News>? News { get; set; }
    }
}
