using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FNSB.PW.Projects.Web.Models;

namespace FNSB.PW.Projects.Web.Controllers
{
    public class ProjectManagersController : Controller
    {
        private PubworksModel db = new PubworksModel();

        // GET: ProjectManagers
        public ActionResult Index()
        {
            return View(db.ProjectManagers.ToList());
        }

        //Active Managers Focuses on getting PM's of active projects up to the surface of the site
        public ActionResult ActiveManagers()
        {
            //select list of all project managers in the system
            var pma = db.ProjectManagers.Select(s => s.ppr_recordid).ToList();

            //fetch a list of all active projects and group them by project manager record ID
            var pa = db.Projects.Where(l => pma.Contains(l.ppr_recordid)).Where(f => f.PPM_Project_Active == true).GroupBy(d => d.ppr_recordid);

            var pml = new List<ProjectManager>();
            var pmp = new List<Project>();

            //dictionary of values for the manager ID and concat name
            Dictionary<int, string> manager = new Dictionary<int, string>();

            //loop the group project list and match the grouped ppr_recordid to the dictionary recordid. Add to the manager dictionary
            foreach (var pm in pa)
            {
                //match located
                if (pma.Contains(pm.Key))
                {
                    //get full ProjectManager record
                    var ds = db.ProjectManagers.FirstOrDefault(d => d.ppr_recordid == pm.Key);
                    if (ds != null)
                        //add to manager - ID is key and value is first+last name
                        manager.Add(ds.ppr_recordid, $"{ds.firstname} {ds.lastname}");
                        pml.Add(ds); //local List to populate the ManagerProjectViewModel

                    //foreach (var project in pm.ToList())
                    //    pmp.Add(project);
                }


            }
            //pass the dictionary to the viewbag
            ViewBag.Managers = manager;
            ViewBag.Projects = pmp;

            return View();
        } 


        // GET: ProjectManagers/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectManager = db.ProjectManagers.Find(id);
            if (projectManager == null)
            {
                return HttpNotFound();
            }

            List<Project> projects = db.Projects.Where(p => p.ppr_recordid == id && p.PPM_Project_Active == true).ToList();

            var mpv = new ManagerProjectViewModel
            {
                ProjectProfileObject = new List<Project>(),
                ProjectManagerProfileObject = new ProjectManager()
            };

            mpv.ProjectManagerProfileObject.ppr_recordid = (int) id;
            mpv.ProjectManagerProfileObject.firstname = projectManager.firstname;
            mpv.ProjectManagerProfileObject.lastname = projectManager.lastname;


            foreach (var project in projects)
                mpv.ProjectProfileObject.Add(project);

            return View(mpv);
        }

        // GET: ProjectManagers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ppr_recordid,firstname,lastname,order")] ProjectManager projectManager)
        {
            if (ModelState.IsValid)
            {
                db.ProjectManagers.Add(projectManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectManager);
        }

        // GET: ProjectManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectManager = db.ProjectManagers.Find(id);
            if (projectManager == null)
            {
                return HttpNotFound();
            }
            return View(projectManager);
        }

        // POST: ProjectManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ppr_recordid,firstname,lastname,order")] ProjectManager projectManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectManager);
        }

        // GET: ProjectManagers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectManager = db.ProjectManagers.Find(id);
            if (projectManager == null)
            {
                return HttpNotFound();
            }
            return View(projectManager);
        }

        // POST: ProjectManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectManager projectManager = db.ProjectManagers.Find(id);
            db.ProjectManagers.Remove(projectManager);
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
