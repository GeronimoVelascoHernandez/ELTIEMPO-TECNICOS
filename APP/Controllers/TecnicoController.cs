using BLL.BLL;
using MODEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP.Controllers
{
    public class TecnicoController : Controller
    {
        private TecnicoBLL TecnicoBLL = new TecnicoBLL();
        private ElementoBLL ElementoBLL = new ElementoBLL();
        private SucursalBLL SucursalBLL = new SucursalBLL();
        
        // GET: Tecnico
        public ActionResult Index()
        {
            ViewBag.ElementsList = ElementoBLL.ListElements();
            ViewBag.SucursalsList = SucursalBLL.listSucursals();
            return View(TecnicoBLL.ListTechnicians());
        }

        // POST: Tecnico/Create
        [HttpPost]
        public JsonResult Create(TecnicoViewModel tecnico)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    TecnicoBLL.CreateTechnician(tecnico);
                    var result = new { code = "true", msn = "Transaccion Exitosa" };
                    return Json(result);
                }
                else {
                    foreach (var modelStateVal in ViewData.ModelState.Values)
                    {
                        foreach (var error in modelStateVal.Errors)
                        {
                            var errorMessage = error.ErrorMessage;
                            var exception = error.Exception;
                        }
                    }
                    var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
                    return Json(errors);
                }
                    
            }
            catch
            {
                var result = new { code = "false", msn = "Transaccion fallida" };
                return Json(result);
            }
        }

        // GET: Tecnico/Edit/5
        public JsonResult Edit(string id)
        {   
            var TechElements = TecnicoBLL.FindTechnicianElements(id);
            return Json(new { elements = TechElements}, JsonRequestBehavior.AllowGet);
        }

        // POST: Tecnico/Edit/5
        [HttpPost]
        public JsonResult Edit(string idTecnico, TecnicoViewModel tecnico)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    TecnicoBLL.EditTechnician(tecnico, idTecnico);
                    var result = new { code = "true", msn = "Transacción Exitosa" };
                    return Json(result);     
                }
                else
                {
                    foreach (var modelStateVal in ViewData.ModelState.Values)
                    {
                        foreach (var error in modelStateVal.Errors)
                        {
                            var errorMessage = error.ErrorMessage;
                            var exception = error.Exception;
                        }
                    }
                    var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
                    return Json(errors);
                }

            }
            catch
            {
                var result = new { code = "false", msn = "Transaccion fallida" };
                return Json(result);
            }
        }
        // POST: Tecnico/Delete/5
        [HttpPost]
        public JsonResult Delete(string id, TecnicoViewModel tecnico)
        {
            try
            {
                // TODO: Add delete logic here
                TecnicoBLL.DeleteTechnician(id);
                var result = new { code = "true", msn = "Transacción Exitosa"};
                return Json(result);
            }
            catch
            {
                var result = new { code = "false", msn = "Transacción no Procesada" };
                return Json(result);
            }
        }
    }
}
