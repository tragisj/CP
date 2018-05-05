using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Publicworks.Data.Projects;
using Publicworks.Entities.Projects.ViewModels;
using Publicworks.Entities.Projects.ViewModels.Admin;

namespace Publicworks.Web.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {

            var repo = new ProjectsRepository();
            var projects = repo.GetActiveProjects();
            return View(projects);
        }

        public ActionResult Summary(string id)
        {

            if (!String.IsNullOrWhiteSpace(id))
            {
                bool isGuid = Guid.TryParse(id, out Guid projectId);

                if (isGuid && projectId != Guid.Empty)
                {
                    var repo = new ProjectsRepository();
                    var model = repo.LoadProjectSummaryByGlKey(projectId);
                    return View(model);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        public ActionResult Detail(string id)
        {

            if (!String.IsNullOrWhiteSpace(id))
            {
                bool isGuid = Guid.TryParse(id, out Guid projectId);

                if (isGuid && projectId != Guid.Empty)
                {
                    var repo = new ProjectsRepository();
                    var model = repo.GetProject(projectId);
                    return View(model);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        public ActionResult Edit(string id)
        {

            if (!String.IsNullOrWhiteSpace(id))
            {
                bool isGuid = Guid.TryParse(id, out Guid projectId);

                if (isGuid && projectId != Guid.Empty)
                {
                    var repo = new ProjectsRepository();
                    var model = repo.GetProject(projectId);
                    return View(model);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new ProjectsRepository();
                var saved = repo.UpdateProject(model);
                if (saved)
                {
                    bool isGuid = Guid.TryParse(model.ProjectID, out Guid projectUserId);
                    if (isGuid)
                    {
                        var modelUpdate = repo.GetProject(projectUserId);

                        return View(modelUpdate);
                    }
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult FundsIndex()
        {

            var repo = new ProjectsRepository();
            var projects = repo.GetActiveProjects();
            return View(projects);
        }
    }
}