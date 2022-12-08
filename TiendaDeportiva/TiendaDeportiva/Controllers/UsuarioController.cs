using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TiendaDeportiva.Entities;
using TiendaDeportiva.Models;

namespace TiendaDeportiva.Controllers
{
    public class Usuario : Controller
    {
        private readonly ILogger<Usuario> _logger;

        UsuarioObj usuE = new UsuarioObj();
        UsuarioModel use = new UsuarioModel();
        public IActionResult Index()
        {
            List<UsuarioObj> _usuario = new List<UsuarioObj>();
            _usuario = use.GetUsuarios().ToList();
            return View(_usuario);
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