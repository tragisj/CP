﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Publicworks.Data.Agents;
using Publicworks.Entities.Projects.ViewModels;
using Publicworks.Entities.Projects.ViewModels.Agents;

namespace Publicworks.Web.Controllers
{
    public class ConsultantController : Controller
    {
        // GET: Agents
        public ActionResult Index()
        {

            var repo = new AgentsRepository();
            var consultantList = repo.GetConsultants();
            return View(consultantList);
        }

        public ActionResult Create()
        {

            var repo = new AgentsRepository();
            var consultant = repo.CreateConsultant();
            return View(consultant);

        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ConsultantID, ConsultantName, Description")]
            ConsultantEditViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var repo = new AgentsRepository();
                    bool saved = repo.SaveConsultant(model);
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
                bool isGuid = Guid.TryParse(id, out Guid consultantId);
                if (isGuid && consultantId != Guid.Empty)
                {
                    var repo = new AgentsRepository();
                    var model = repo.GetConsultant(consultantId);
                    return View(model);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConsultantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new AgentsRepository();
                var saved = repo.UpdateConsultant(model);
                if (saved)
                {
                    bool isGuid = Guid.TryParse(model.ConsultantID, out Guid consultantId);
                    if (isGuid)
                    {
                        var modelUpdate = repo.GetConsultant(consultantId);
                        ViewBag.EditMessage = "Success";
                        return View(modelUpdate);
                    }
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


    }
}