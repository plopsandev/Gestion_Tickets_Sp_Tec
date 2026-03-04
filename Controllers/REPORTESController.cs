using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestion_Tickets_Sp_Tec.Models;

namespace Gestion_Tickets_Sp_Tec.Controllers
{
    public class REPORTESController : Controller
    {
        private SOPORTE_TECNICOEntities db = new SOPORTE_TECNICOEntities();

        // GET: REPORTES
        public ActionResult Index()
        {
            var rEPORTES = db.REPORTES.Include(r => r.USUARIOS).Include(r => r.USUARIOS1);
            return View(rEPORTES.ToList());
        }

        // GET: REPORTES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTES rEPORTES = db.REPORTES.Find(id);
            if (rEPORTES == null)
            {
                return HttpNotFound();
            }
            return View(rEPORTES);
        }

        // GET: REPORTES/Create
        public ActionResult Create()
        {
            ViewBag.ID_TECNICO = new SelectList(db.USUARIOS, "ID_USUARIO", "NOMBRE");
            var listaTecnicos = db.USUARIOS.Where(u => u.ID_ROL == 2).ToList();
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOS, "ID_USUARIO", "NOMBRE");         
            return View();
        }

        // POST: REPORTES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REPORTE,FECHA_REPORTE,DESCRIPCION,PRIORIDAD,ESTADO,ID_USUARIO,ID_TECNICO,FECHA_SOLUCION,OBSERVACIONES")] REPORTES rEPORTES)
        {
            if (ModelState.IsValid)
            {
                db.REPORTES.Add(rEPORTES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TECNICO = new SelectList(db.USUARIOS, "ID_USUARIO", "NOMBRE", rEPORTES.ID_TECNICO);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOS, "ID_USUARIO", "NOMBRE", rEPORTES.ID_USUARIO);
            return View(rEPORTES);
        }

        // GET: REPORTES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTES rEPORTES = db.REPORTES.Find(id);
            if (rEPORTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TECNICO = new SelectList(db.USUARIOS, "ID_USUARIO", "NOMBRE", rEPORTES.ID_TECNICO);
            var listaTecnicos = db.USUARIOS.Where(u => u.ID_ROL == 2).ToList();
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOS, "ID_USUARIO", "NOMBRE", rEPORTES.ID_USUARIO);
            return View(rEPORTES);
        }

        // POST: REPORTES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_REPORTE,FECHA_REPORTE,DESCRIPCION,PRIORIDAD,ESTADO,ID_USUARIO,ID_TECNICO,FECHA_SOLUCION,OBSERVACIONES")] REPORTES rEPORTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEPORTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TECNICO = new SelectList(db.USUARIOS, "ID_USUARIO", "NOMBRE", rEPORTES.ID_TECNICO);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOS, "ID_USUARIO", "NOMBRE", rEPORTES.ID_USUARIO);
            return View(rEPORTES);
        }

        // GET: REPORTES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTES rEPORTES = db.REPORTES.Find(id);
            if (rEPORTES == null)
            {
                return HttpNotFound();
            }
            return View(rEPORTES);
        }

        // POST: REPORTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REPORTES rEPORTES = db.REPORTES.Find(id);
            db.REPORTES.Remove(rEPORTES);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Agregar Usuarios al sistema
        // GET: REPORTES/NuevoUsuario
        public ActionResult NuevoUsuario()
        {
            int nuevoId = 1;
            if (db.USUARIOS.Any())
            {
                nuevoId = db.USUARIOS.Max(u => u.ID_USUARIO) + 1;
            }

            ViewBag.SiguienteID = nuevoId;

            // Cargar listas desplegables para la vista
            ViewBag.ID_DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPARTAMENTO", "DEPARTAMENTO");
            ViewBag.ID_ROL = new SelectList(db.ROLES, "ID_ROL", "ROL");

            return View();
        }

        // POST: REPORTES/NuevoUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoUsuario([Bind(Include = "ID_USUARIO,NOMBRE,APELLIDOS,CORREO,ID_DEPARTAMENTO,ID_ROL")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.USUARIOS.Add(uSUARIOS);
                    db.SaveChanges();
                    // Redirecciona a la creación de reporte tras éxito
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al guardar: " + ex.Message);
                }
            }

            // Si algo falla, recargamos los datos para no perder la vista
            ViewBag.SiguienteID = uSUARIOS.ID_USUARIO;
            ViewBag.ID_DEPARTAMENTO = new SelectList(db.DEPARTAMENTOS, "ID_DEPARTAMENTO", "DEPARTAMENTO", uSUARIOS.ID_DEPARTAMENTO);
            ViewBag.ID_ROL = new SelectList(db.ROLES, "ID_ROL", "ROL", uSUARIOS.ID_ROL);
            return View(uSUARIOS);
        }
    }
}


