using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaDeportiva.Entities;
using TiendaDeportiva.Models;

namespace TiendaDeportiva.Controllers
{
    public class UsuarioController : Controller
    {
        //private readonly ILogger<Usuario> _logger;

        UsuarioObj usuE = new UsuarioObj();
        UsuarioModel use = new UsuarioModel();
        public ActionResult Login()
        {
            return View();
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            List<UsuarioObj> _usuario = new List<UsuarioObj>();
            _usuario = use.GetUsuarios().ToList();
            return View(_usuario);
        }

        //public Usuario(ILogger<Usuario> logger)
        //{
        //    _logger = logger;
        //}

        // GET: UsuarioController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UsuarioObj user)
        {
            try
            {
                use.PostUsuarios(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult EditarUsuario(int id)
        {
            usuE = use.GetUsuarios(id);
            return View(usuE);

        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(UsuarioObj useE, IFormCollection collection)
        {
            try
            {
                use.PutUsuarios(useE);
                return RedirectToAction("Index", "Usuario");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            use.EliminarUsuario(id);
            return RedirectToAction("Index", "Usuario");
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
