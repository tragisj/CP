using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FNSB.PW.Finance.Import.Data;
using FNSB.PW.Projects.Web.Models;

namespace FNSB.PW.Projects.Web.Controllers
{
    public class FinanceController : Controller
    {

        private PubworksModel db = new PubworksModel();

        // GET: Finance
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Import()
        {
            return View();
        }


        public ActionResult GlKeys()
        {
            return View();
        }


        public PartialViewResult GlKeyDetail(string keySearch)
        {
            IEnumerable<Fund> funds;

            if (keySearch != null)
            {
                funds = db.Funds.Where(k => k.ppf_glkey.Contains(keySearch)).ToList();
            }
            else
            {
                funds = db.Funds.ToList();
            }

            return PartialView(funds);
        }

        public PartialViewResult KeyPart(string id)
        {

            var kpd = new OneSolutionKeyPart();
            var result = kpd.KeyPartData(id);

            var kpm = new List<KeyPartData>();

            foreach (var detail in result)
            {
                var kd = new KeyPartData
                {
                    Id = detail.Id,
                    Description = detail.Description,
                    Name = detail.Name,
                    Number = detail.Number,
                    Value = detail.Value
                };
                
                kpm.Add(kd);
            }

            

            return PartialView(kpm);
        }


        //public PartialViewResult GlKeySearch(string glKey)
        //{

        //    var keyObjectFinanceBuilder = new KeyObjectFinanceBuilder();
        //    var glKeyList = keyObjectFinanceBuilder.GeneralLedgerKeyList.ToList();        //distinct key list

        //    var keyData = glKeyList.Contains(glKey);

        //    if (!keyData)
        //    {
        //        ViewBag.glKey = glKeyList;
        //    }

        //    return PartialView(glKeyList);
        //}


    }
}