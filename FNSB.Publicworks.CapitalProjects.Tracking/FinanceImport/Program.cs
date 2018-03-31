using System;
using System.Collections.Generic;
using System.Linq;
using Publicworks.Finance.OneSolution.Entities;
using Publicworks.Finance.OneSolution.Repository;

namespace Publicworks.Finance.OneSolution
{
    public class Program
    {

        public static void Main(string[] args)
        {

            BudgetData bd = new BudgetData();
            EncumbranceData en = new EncumbranceData();
            ActualsData ac = new ActualsData();

            List<string> kt = new List<string>
            {
                "S18TCU",
                "S18TBQ",
                "S18NFD",
                "S18LPE",
                "NRALWC",
                "LTFNWT",
                "LSCTTI",
                "LSCTTH",
                "LSCTTG",
            };


            List<ProjectTrackingFinance> tst  = new List<ProjectTrackingFinance>();

            foreach (var x in kt)
            {

                List<BudgetBalance> blist = bd.GetBudgetBalanceForGlKey(x);
                decimal enVal = en.GetEncubranceBalanceForGlKey(x);
                decimal acVal = ac.GetActualsBalanceForGlKey(x);

                var ptf = new ProjectTrackingFinance
                {
                    GeneralLedgerKey = x,
                    JobLedgerProject = "TEST",
                    GeneralLedgerDesc = "TEST DATA FOR KEY",
                    BudgetBalance = blist.Sum(s => s.Amount),
                    EncumbranceBalance = enVal,
                    ActualsBalance = acVal

                };

                tst.Add(ptf);
            }

            //Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");

            foreach (var p in tst)
            {

                Console.WriteLine($"{p.GeneralLedgerKey},{p.BudgetBalance}, {p.ActualsBalance}, {p.EncumbranceBalance}");
                
            }

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
