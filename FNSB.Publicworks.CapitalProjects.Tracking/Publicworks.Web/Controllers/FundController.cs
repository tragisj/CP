using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Publicworks.Data.Funds;

namespace Publicworks.Web.Controllers
{
    public class FundController : Controller
    {


        // GET: Fund
        public ActionResult Index()
        {
            var repo = new FundsRepository();
            var fundsList = repo.GetOneSolutionGeneralLedgerKeyStatusDesc(true);
            return View(fundsList);
        }


        public ActionResult KeyPartDetail(string glkey)
        {

            var repo = new FundsRepository();
            var keyparts = repo.GetOneSolutionGeneralLedgerKeyPartDetail(glkey);
            return View(keyparts);

        }

        public ActionResult KeyPartBalance(string glkey)
        {
            var repo = new FundsRepository();
            var keydetail = repo.GetOneSolutionBudgetActualDetail(glkey);
            return View(keydetail);
        }

        public ActionResult KeyPartDetail(Guid projectId)
        {

            var repo = new FundsRepository();
            var keydetailList = repo.GetGlKeyDataByProjectId(projectId);
            return View(keydetailList);
        }


    }
}