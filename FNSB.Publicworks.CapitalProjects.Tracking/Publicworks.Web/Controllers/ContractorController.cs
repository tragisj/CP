using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Publicworks.Data.Admin;
using Publicworks.Data.Agents;
using Publicworks.Entities.Projects.ViewModels.Admin;
using Publicworks.Entities.Projects.ViewModels.Agents;

namespace Publicworks.Web.Controllers
{
    public class ContractorController : Controller
    {
        // GET: Contractor
        public ActionResult Index()
        {
            var repo = new AgentsRepository();
            var contractorList = repo.GetContractors();
            return View(contractorList);
        }

        public ActionResult Create()
        { 
            var repo = new AgentsRepository();
            var contractor = repo.CreateContractor();
            return View(contractor);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ContractorID, ContractorName, Description")]
            ContractorEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new AgentsRepository();
                    bool saved = repo.SaveContractor(model);
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
                bool isGuid = Guid.TryParse(id, out Guid contractorId);
                if (isGuid && contractorId != Guid.Empty)
                {
                    var repo = new AgentsRepository();
                    var model = repo.GetContractor(contractorId);
                    return View(model);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContractorEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new AgentsRepository();
                var saved = repo.UpdateContractor(model);
                if (saved)
                {
                    bool isGuid = Guid.TryParse(model.ContractorID, out Guid contractorId);
                    if (isGuid)
                    {
                        var modelUpdate = repo.GetContractor(contractorId);
                        ViewBag.EditMessage = "Success";
                        return View(modelUpdate);
                    }
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}