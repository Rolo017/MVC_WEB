using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TiendaDeportiva.Models;

namespace TiendaDeportiva.Controllers
{
    public class Usuario : Controller
    {
        private readonly ILogger<Usuario> _logger;

        public IActionResult Index()
        {
            return View();
        }
        public Usuario(ILogger<Usuario> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult EditarUsuario()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult CrearRol()
        {
            return View();
        }

        public IActionResult EditarRol()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}