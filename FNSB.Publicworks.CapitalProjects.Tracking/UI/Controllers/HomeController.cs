using System.Web.Mvc;
using FNSB.PW.Projects.Web.Models;

namespace FNSB.PW.Projects.Web.Controllers
{
    public class HomeController : Controller
    {

        private PubworksModel db = new PubworksModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}