using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUD.Models;
using MVCCRUD.Models.ViewModels;

namespace MVCCRUD.Controllers
{
    public class TablaController : Controller
    {
        #region READ
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (CrudEntities db = new CrudEntities())
            {
                 lst = (from d in db.tablaDatos
                           select new ListTablaViewModel
                           {
                               Id = d.id,
                               Nombre = d.nombre,
                               Correo = d.correo,
                               FechaNacimiento = d.fecha,
                               Direccion = d.direccion
                           }).ToList();
            }
                return View(lst);
        }
        #endregion

        #region CREATE
        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = new tablaDatos
                        {
                            correo = model.Correo,
                            fecha = model.FechaNacimiento,
                            nombre = model.Nombre,
                            direccion = model.Direccion
                        };

                        db.tablaDatos.Add(oTabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Tabla/");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public ActionResult Editar(int Id)
        {
            TablaViewModel model = new TablaViewModel();
            using (CrudEntities db = new CrudEntities())
            {
                var oTabla = db.tablaDatos.Find(Id);
                model.Nombre = oTabla.nombre;
                model.Correo = oTabla.correo;
                model.FechaNacimiento = oTabla.fecha;
                model.Direccion = oTabla.direccion;
                model.Id = oTabla.id;

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = db.tablaDatos.Find(model.Id);
                        oTabla.correo = model.Correo;
                        oTabla.fecha = model.FechaNacimiento;
                        oTabla.nombre = model.Nombre;
                        oTabla.direccion = model.Direccion;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Tabla/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region DELETE
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
           
            using (CrudEntities db = new CrudEntities())
            {
                var oTabla = db.tablaDatos.Find(Id);
                db.tablaDatos.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("~/Tabla/");
        }
        #endregion
    }
}