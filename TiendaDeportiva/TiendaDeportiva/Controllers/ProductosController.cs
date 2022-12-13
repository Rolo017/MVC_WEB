using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaDeportiva.Entities;
using TiendaDeportiva.Models;

namespace TiendaDeportiva.Controllers
{
    public class ProductosController : Controller
    {
        //private readonly ILogger<Usuario> _logger;

        ProductosObj ProducE = new ProductosObj();
        ProductosModel prod = new ProductosModel();
        // GET: ProductosController

        // GET: ProductosController
        public ActionResult Index()
        {
            List<ProductosObj> _Productos = new List<ProductosObj>();
            _Productos = prod.GetProductos().ToList();
            return View(_Productos);

        }

        // GET: ProductosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductosObj prodC)
        {
            try
            {
                prod.PostProductos(prodC);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            ProducE = prod.GetProductos(id);
            return View(ProducE);
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductosObj Procd, IFormCollection collection)
        {
            try
            {
                prod.PUTProductos(Procd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            prod.EliminarProductos(id);
            return RedirectToAction("Index", "Productos");

        }

        // POST: ProductosController/Delete/5
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
