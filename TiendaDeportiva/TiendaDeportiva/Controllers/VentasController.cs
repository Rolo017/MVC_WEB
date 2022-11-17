using Microsoft.AspNetCore.Mvc;

namespace TiendaDeportiva.Controllers
{
    public class VentasController : Controller
    {
        // GET: VentasController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: VentasController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VentasController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentasController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: VentasController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VentasController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: VentasController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VentasController1/Delete/5
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
