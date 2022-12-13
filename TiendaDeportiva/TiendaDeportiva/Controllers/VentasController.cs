using Microsoft.AspNetCore.Mvc;
using TiendaDeportiva.Entities;
using TiendaDeportiva.Models;

namespace TiendaDeportiva.Controllers
{
    public class VentasController : Controller
    {

        VentasObj ventE = new VentasObj();
        VentasModel vent = new VentasModel();

        ProductosObj produc = new ProductosObj();
        public IActionResult Index()
        {
            List<VentasObj> _ventas = new List<VentasObj>();
            _ventas = vent.GetVentas().ToList();
            return View(_ventas);
        }

        // GET: VentasController1/Create
        public ActionResult Create(int id)
        {
            produc = vent.GetProductos(id);
            ventE.Precio = produc.Precio;
            ventE.Producto = produc.IdProducto;
            ventE.Cantidad= produc.Cantidad;
            ventE.Descripcion = produc.Descripcion;
            return View(ventE);
        }

        // POST: VentasController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VentasObj ventE, IFormCollection collection)
        {
            try
            {
                vent.PostVentas(ventE);
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
            ventE = vent.GetVentas(id);
            return View(ventE);
        }

        // POST: VentasController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VentasObj ventE, IFormCollection collection)
        {
            try
            {
                vent.PutVentas(ventE);
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
            vent.EliminarVentas(id);
            return RedirectToAction(nameof(Index));
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
