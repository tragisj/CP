using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Publicworks.Data.Admin;
using Publicworks.Entities.Projects.ViewModels;
using Publicworks.Entities.Projects.ViewModels.Admin;

namespace Publicworks.Web.Controllers
{
    public class ProjectManagerController : Controller
    {
        // GET: ProjectManager
        public ActionResult Index()
        {
            var repo = new ProjectManagerRepository();
            var pml = repo.GetProjectManagers();
            return View(pml);
        }

        public ActionResult Create()
        {
            var repo = new ProjectManagerRepository();
            var manager = repo.CreateProjectManager();
            return View(manager);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ProjectManagerID, FirstName, LastName")] ProjectManagerEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new ProjectManagerRepository();
                    bool saved = repo.SaveProjectManager(model);
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
                bool isGuid = Guid.TryParse(id, out Guid managerId);

                if (isGuid && managerId != Guid.Empty)
                {
                    var repo = new ProjectManagerRepository();
                    var model = repo.GetProjectManager(managerId);
                    return View(model);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectManagerEditViewModel model)
        { 
            if (ModelState.IsValid)
            {
                var repo = new ProjectManagerRepository();
                var saved = repo.UpdateProjectManager(model);
                if (saved)
                {
                    bool isGuid = Guid.TryParse(model.ProjectManagerID, out Guid managerId);
                    if (isGuid)
                    {
                        var modelUpdate = repo.GetProjectManager(managerId);
                        ViewBag.EditMessage = "Success";
                        return View(modelUpdate);
                    }
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}