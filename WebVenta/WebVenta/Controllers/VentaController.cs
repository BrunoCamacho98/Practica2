using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVenta.Models;
using WebVenta.Services;

namespace WebVenta.Controllers
{
    public class VentaController : Controller
    {
        IVentaService venservice;

        public VentaController()
        {
            venservice = new VentaService();
        }

        public List<Venta> listventa { get; private set; }
        // GET: Venta
        public ActionResult Index()
        {
            var read = venservice.ReadVenta();
            var result = venservice.Reporte();
            ViewBag.montmayor = $"{result.ventmayor}";
            ViewBag.montmenor = $"{result.vnetmenor}";
            ViewBag.prodmayor = $"{result.vmayor.Producto}";
            ViewBag.prodmenor = $"{result.vmenor.Producto}";
            return View(read);
        }

        // GET: Venta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Venta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Venta/Create
        [HttpPost]
        public ActionResult Create(Venta v)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (venservice.CreateVenta(v))
                    {
                        ViewBag.Message = "Producto Registrado";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Venta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Venta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Venta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Venta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
