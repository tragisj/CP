using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Publicworks.Data.Admin;
using Publicworks.Entities.Projects.ViewModels.Admin;

namespace Publicworks.Web.Controllers
{
    public class ProjectUserController : Controller
    {
        // GET: ProjectUser
        public ActionResult Index()
        {

            var repo = new ProjectUserRepository();
            var users = repo.GetProjectUsers();
            return View(users);
        }



        public ActionResult Create()
        {
            var repo = new ProjectUserRepository();
            var user = repo.CreateProjectUser();
            return View(user);
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "ProjectUserID, FirstName, LastName")]
            ProjectUserEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new ProjectUserRepository();
                    bool saved = repo.SaveProjectUser(model);
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
                bool isGuid = Guid.TryParse(id, out Guid projectUserId);

                if (isGuid && projectUserId != Guid.Empty)
                {
                    var repo = new ProjectUserRepository();
                    var model = repo.GetProjectUser(projectUserId);
                    return View(model);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectUserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new ProjectUserRepository();
                var saved = repo.UpdateProjectUser(model);
                if (saved)
                {
                    bool isGuid = Guid.TryParse(model.ProjectUserID, out Guid projectUserId);
                    if (isGuid)
                    {
                        var modelUpdate = repo.GetProjectUser(projectUserId);

                        return View(modelUpdate);
                    }
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }




        //[HttpPost]
        //public ActionResult Edit(string id)
        //{

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var repo = new ProjectUserRepository();
        //            var saved = repo.SaveProjectUser(model);
        //            if (saved)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }

        //        return View();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


    }
}