using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FNSB.PW.Projects.Web.Models;

namespace FNSB.PW.Projects.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private PubworksModel db = new PubworksModel();

        // GET: Projects
        public PartialViewResult ActiveProjectsData(string projectSearch, int? page, string selectedStatus = "Active")
        {

            Project.SelectStatus selected = (Project.SelectStatus)Enum.Parse(typeof(Project.SelectStatus), selectedStatus);
            IEnumerable<Project> data;

            switch (selected)
            {
                case Project.SelectStatus.Active:

                    data = projectSearch != null
                        ? db.Projects.Where(s => s.PPM_Project_Name.Contains(projectSearch) &&
                                                 s.PPM_Project_Active == true)
                            .OrderByDescending(p => p.PPM_Active_Date)
                        : db.Projects.Where(s => s.PPM_Project_Active == true)
                            .OrderByDescending(p => p.PPM_Active_Date);
                    break;

                case Project.SelectStatus.Inactive:
                    data = projectSearch != null
                        ? db.Projects.Where(s => s.PPM_Project_Name.Contains(projectSearch) &&
                                                 s.PPM_Project_Active == false)
                            .OrderByDescending(p => p.PPM_Active_Date)
                        : db.Projects.Where(s => s.PPM_Project_Active == false)
                            .OrderByDescending(p => p.PPM_Active_Date);
                    break;
                case Project.SelectStatus.All:
                    data = projectSearch != null
                        ? db.Projects.Where(s => s.PPM_Project_Name.Contains(projectSearch))
                            .OrderByDescending(p => p.PPM_Active_Date)
                        : db.Projects.OrderByDescending(p => p.PPM_Active_Date);
                    break;
                default:
                    data = db.Projects.OrderByDescending(p => p.PPM_Active_Date);
                    break;
            }

            return PartialView(data);
        }

        public ActionResult ActiveProjects()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string prefix)
        {
            
            var name = db.Projects.Where(p => p.PPM_Project_Name.StartsWith(prefix));
            return Json(name, JsonRequestBehavior.AllowGet);
        }


        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PPM_Recordid,PPM_Project_Name,PPM_Project_Number,PPM_Active_Date,PPM_Inactive_Date,PPM_Project_Active,PPM_Status_Desc,PPM_Per_Des_Complete,PPM_Proj_Scope,PPM_MSA_Update,PPM_Consultant_Fee,PPM_Contract_Amount,PPM_Contract_Amendments,PPM_CO,PPM_Per_Const_Complete,PPM_IFB_RFQ,PPM_User_Letter,PPM_RFP_Number,NDI_RFP,NDI_Scope,NDI_Advertise_for_Bid,NDI_Original_Bid_Date,NDI_Bid_Opening,NDI_Gen_Serv_Review,NDI_Consultant_Award,NDI_Construction_Bid_Award,NDI_Design_Complete,NDI_Agenda_Setting,NDI_Assembly_Approval,NDI_NTP,NDI_Substantial_Completion,NDI_Final,NDI_Warranty_Period_Ends,NDI_Closed,PPS_Recordid,PPU_Recordid,PPT_Recordid,PPR_Recordid,PPC_Recordid,PPA_Recordid,PPN_Recordid,NOU_Recordid,FFM_Recordid,ppm_project_complete")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PPM_Recordid,PPM_Project_Name,PPM_Project_Number,PPM_Active_Date,PPM_Inactive_Date,PPM_Project_Active,PPM_Status_Desc,PPM_Per_Des_Complete,PPM_Proj_Scope,PPM_MSA_Update,PPM_Consultant_Fee,PPM_Contract_Amount,PPM_Contract_Amendments,PPM_CO,PPM_Per_Const_Complete,PPM_IFB_RFQ,PPM_User_Letter,PPM_RFP_Number,NDI_RFP,NDI_Scope,NDI_Advertise_for_Bid,NDI_Original_Bid_Date,NDI_Bid_Opening,NDI_Gen_Serv_Review,NDI_Consultant_Award,NDI_Construction_Bid_Award,NDI_Design_Complete,NDI_Agenda_Setting,NDI_Assembly_Approval,NDI_NTP,NDI_Substantial_Completion,NDI_Final,NDI_Warranty_Period_Ends,NDI_Closed,PPS_Recordid,PPU_Recordid,PPT_Recordid,PPR_Recordid,PPC_Recordid,PPA_Recordid,PPN_Recordid,NOU_Recordid,FFM_Recordid,ppm_project_complete")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
    }
}
