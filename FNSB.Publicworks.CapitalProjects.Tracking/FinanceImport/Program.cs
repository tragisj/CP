using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Publicworks.Finance.OneSolution.Data;
using Publicworks.Finance.OneSolution.Data.Repository;
using Publicworks.Finance.OneSolution.Entities;
namespace Publicworks.Finance.OneSolution
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var repo = new PubworksRepository();
            //ProjectTrackingFinance pt = repo.GetGlKeyBalanceByKey("LSA04Z");

            List<string> glkeys = new List<string> {"D46MGG", "LPB6WC", "LPB1SR", "LPB6TB", "LSACSS" };

            List<ProjectTrackingFinance> ptl = repo.GetGlKeyBalanceByKeyList(glkeys);
            Debug.WriteLine(ptl[0].Budget);


        }


        //Possible Container of data for UI delivery to view
        //var fileBuilderList = (from key in glKeyList
        //                       let keyObjectRecord = budgetActualData.First(k => k.Key == key)
        //                       let br = balance.Single(p => p.Key == key)
        //                       let ar = actual.Single(p => p.Key == key)
        //                       let er = encumbrance.Single(p => p.Key == key)

        //                       select new ProjectTrackingFinance
        //                       {
        //                           GeneralLedgerKey = keyObjectRecord.Key,
        //                           JobLedgerProject = keyObjectRecord.JobLedgerKey,
        //                           GeneralLedgerDesc = keyObjectRecord.LongDesc,
        //                           BudgetBalance = br.Value.Amount,
        //                           ActualsBalance = ar.Value.Amount,
        //                           EncumbranceBalance = er.Value.Amount
        //                       }).ToList();

        //InsertDatabaseNonZeroFinanceProjectRecords(fileBuilderList);

        //return fileBuilderList;



    }
}
