using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Publicworks.Data.Admin;
using Publicworks.Entities.Projects.ViewModels.Admin;

namespace Publicworks.Web.Controllers
{
    public class ArchitectEngineerController : Controller
    {
        // GET: ArchitectEngineer
        public ActionResult Index()
        {

            var repo = new ArchitectEngineerRepository();
            var arcList = repo.GetArchitectEngineers();
            return View(arcList);
        }

        public ActionResult Create()
        {
            var repo = new ArchitectEngineerRepository();
            var architectEngineer = repo.CreateArchitectEngineer();
            return View(architectEngineer);
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "ArchitectEngineerID, FirstName, LastName")]
                                    ArchitectEngineerEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new ArchitectEngineerRepository();
                    bool saved = repo.SaveArchitectEngineer(model);
                    if (saved)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {

            if (!String.IsNullOrWhiteSpace(id))
            {
                bool isGuid = Guid.TryParse(id, out Guid architectId);

                if (isGuid && architectId != Guid.Empty)
                {
                    var repo = new ArchitectEngineerRepository();
                    var model = repo.GetArchitectEngineer(architectId);
                    return View(model);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArchitectEngineerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new ArchitectEngineerRepository();
                var saved = repo.UpdateArchitectEngineer(model);
                if (saved)
                {
                    bool isGuid = Guid.TryParse(model.ArchitectEngineerID, out Guid architectId);
                    if (isGuid)
                    {
                        var modelUpdate = repo.GetArchitectEngineer(architectId);
                        ViewBag.EditMessage = "Success";
                        return View(modelUpdate);
                    }
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }




    }
}