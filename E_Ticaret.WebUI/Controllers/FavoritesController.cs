﻿using E_Ticaret.Core.Entities;
using E_Ticaret.Data;
using E_Ticaret.Service.Abstract;
using E_Ticaret.WebUI.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret.WebUI.Controllers
{
    public class FavoritesController : Controller
    {
        //private readonly DatabaseContext _context;

        //public FavoritesController(DatabaseContext context)
        //{
        //	_context = context;
        //}

        private readonly IService<Product> _service;

        public FavoritesController(IService<Product> service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var favoriler = GetFavorites();
            return View(favoriler);
        }
        private List<Product> GetFavorites()
        {
            return HttpContext.Session.GetJson<List<Product>>("GetFavorites") ?? [];
        }

		public IActionResult Add(int ProductId)
		{
			var favoriler = GetFavorites();
			var product = _service.Find(ProductId);
			if (product != null && !favoriler.Any(p => p.Id == ProductId)) ; 
			{ 
				favoriler.Add(product);
				HttpContext.Session.SetJson("GetFavorites", favoriler);
			}
			return RedirectToAction("Index");
		}

        public IActionResult Remove(int ProductId)
        {
            var favoriler = GetFavorites();
            var product = _service.Find(ProductId);
            if (product != null && favoriler.Any(p => p.Id == ProductId)) ;
            {
                favoriler.RemoveAll(i=> i.Id == product.Id);
                HttpContext.Session.SetJson("GetFavorites", favoriler);
            }
            return RedirectToAction("Index");
        }
    }
}
