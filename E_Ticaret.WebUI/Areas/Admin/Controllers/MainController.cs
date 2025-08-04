using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")] // MainController, Admin bölgesi içinde çalışacak 
    public class MainController : Controller
    {
        public IActionResult Index() // Index'e sağ click yapıp, Add View kısmından Index.cshtml oluşturduk. Böylelikle View ekledik.

            // Views klasöründeki Shared klasörünü kopyaladık, Areas'taki Views klasörüne ekledik.
        {
            return View();
        }
    }
}
