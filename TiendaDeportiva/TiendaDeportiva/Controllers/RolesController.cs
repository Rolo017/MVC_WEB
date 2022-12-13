using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;


using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using TiendaDeportiva.Models;
using TiendaDeportiva.Entities;
using System.Data;


namespace TiendaDeportiva.Controllers
{
    public class RolesController : Controller
    {
        RolesObj rolE = new RolesObj();
        RolesModel rol = new RolesModel();

        // GET: RolesController
        public ActionResult Index()
        {

            List<RolesObj> _rol = new List<RolesObj>();
            _rol = rol.GetRoles().ToList();
            return View(_rol);
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound(HttpStatusCode.BadRequest);
            }

            if (rolE == null)
            {
                return NotFound();
            }
            return View(rolE);
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            //ViewBag.CodigoProveedor = new SelectList(db.Proveedores, "CodigoProveedor", "Nombre");
            return View();
        }



        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolesObj rolesC)
        {
            rol.PostRoles(rolesC);
            return RedirectToAction("Index", "Roles");
            //else
            //{
            //    ErrorViewModel error = new ErrorViewModel();
            //    error.RequestId = "01";
            //    return View("Error", error);
            //}
        }

        // GET: RolesController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            rolE = rol.GetRoles(id);
            
            if (rolE == null)
            {
                return NotFound();
            }
            //ViewBag.CodigoProveedor = new SelectList(db.Proveedores, "CodigoProveedor", "Nombre", articulos.CodigoProveedor);
            return View(rolE);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RolesObj rolesC)
        {
            if (ModelState.IsValid)
            {
                rol.PUTRoles(rolesC);
                return RedirectToAction("Index", "Roles");
            }
            //ViewBag.CodigoProveedor = new SelectList(db.Proveedores, "CodigoProveedor", "Nombre", articulos.CodigoProveedor);
            return View(rolesC);
        }

        // GET: RolesController/Delete/5
        public ActionResult Delete(int id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            rol.EliminarRoles(id);
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Roles");
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
