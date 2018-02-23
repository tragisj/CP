using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Publicworks.Data.Admin;
using Publicworks.Data.Agents;
using Publicworks.Entities.Projects.ViewModels.Admin;

namespace Publicworks.Web.Controllers
{
    public class SecretaryController : Controller
    {
        // GET: Secretary
        public ActionResult Index()
        {

            var repo = new SecretaryRepository();
            var secretaries = repo.GetSecretaries();
            return View(secretaries);
        }


        public ActionResult Create()
        {
            var repo = new SecretaryRepository();
            var sec = repo.CreateSecretary();
            return View(sec);

        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "SecretaryID, FirstName, LastName")]
            SecretaryEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new SecretaryRepository();
                    bool saved = repo.SaveSecretary(model);
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
                bool isGuid = Guid.TryParse(id, out Guid secretaryId);
                if (isGuid && secretaryId != Guid.Empty)
                {
                    var repo = new SecretaryRepository();
                    var model = repo.GetSecretary(secretaryId);
                    return View(model);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SecretaryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new SecretaryRepository();
                var saved = repo.UpdateSecretary(model);
                if (saved)
                {
                    bool isGuid = Guid.TryParse(model.SecretaryID, out Guid secretaryId);
                    if (isGuid)
                    {
                        var modelUpdate = repo.GetSecretary(secretaryId);
                        ViewBag.EditMessage = "Success";
                        return View(modelUpdate);
                    }
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }



    }
}