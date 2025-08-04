using E_Ticaret.Core.Entities;
using E_Ticaret.Data;
using E_Ticaret.Service.Abstract;
using E_Ticaret.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly DatabaseContext _context;

        //public ProductsController(DatabaseContext context)
        //{
        //    _context = context;
        //}


        private readonly IService<Product> _serviceProduct;

        public ProductsController(IService<Product> serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }

        public async Task<IActionResult> Index(string arama = "")
        {
            var databaseContext = _serviceProduct.GetAllAsync(p => p.IsActive && p.Name.Contains(arama) || p.Description.Contains(arama));
            return View(await databaseContext); // Aktif olmayan ürünlerin gelmemesi için IsActive kullandık.     
        } // Böylelikle products içindeki bütün ürünleri listelicez.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _serviceProduct.GetQueryable()
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductDetailViewModel() { Product = product, 
                RelatedProducts = _serviceProduct.GetQueryable().Where(p => p.IsActive && p.CategoryID == product.CategoryID && p.Id != product.Id) };
            return View(model);
        }
    }
}
