using Microsoft.AspNetCore.Mvc;

namespace TiendaDeportiva.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
