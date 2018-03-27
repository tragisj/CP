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


    }
}