using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using FNSB.PW.Finance.Import.Data;
using FNSB.PW.Finance.Import.Domain;
using FNSB.PW.Finance.Import.Domain.Helpers;
using BudgetVersion = FNSB.PW.Finance.Import.Domain.Helpers.BudgetVersions;

namespace FNSB.PW.Finance.Import
{
    public class Program
    {
        public static List<BudgetVersion> BudgetVersions { get; set; }

        static void Main(string[] args)
        {
            //KeyObject class is the primary class used to acquire the publicworks projects tracking import data

            //KeyObjectFinanceBuilder calls the Data.FinanceKeyData class to query the database to 
            //select the keys, objects, budget, encumbrance, actual, description, fiscal year
            var builder = new KeyObjectFinanceBuilder();

            var budgetActualData = builder.OneSolutionBudgetActualsList;      //full budact data package in List<OneSolutionBudgetActualDataList> 
            var glKeyList = builder.GeneralLedgerKeyList;        //distinct key list


            //BUDGET
            var budgetsCalcs = new BudgetCalculations(ref budgetActualData, ref glKeyList);
            var balance = budgetsCalcs.BuildBudgetBalances(LocalResource.BudgetVersions.WorkingBudget, 2018);



            //ACTUAL
            var actualsCalcs = new ActualsCalculations(ref budgetActualData, ref glKeyList);
            var actual = actualsCalcs.BuildActualsBalances();



            //ENCUMBRANCE
            var encumbranceCalcs = new EncumbrancesCalculations(ref budgetActualData, ref glKeyList);
            var encumbrance = encumbranceCalcs.BuildEncumbranceBalances();



            //list of the class that builds the PW payload back to app, report, etc.
            var fileBuilderList = (from key in glKeyList
                let keyObjectRecord = budgetActualData.First(k => k.Key == key)
                let br = balance.Single(p => p.Key == key)
                let ar = actual.Single(p => p.Key == key)
                let er = encumbrance.Single(p => p.Key == key)

                select new ProjectTrackingFinance
                {
                    GeneralLedgerKey = keyObjectRecord.Key,
                    JobLedgerProject = keyObjectRecord.JobLedgerKey,
                    GeneralLedgerDesc = keyObjectRecord.LongDesc,
                    BudgetBalance = br.Value.Amount,
                    ActualsBalance = ar.Value.Amount,
                    EncumbranceBalance = er.Value.Amount
                }).ToList();

            InsertDatabaseNonZeroFinanceProjectRecords(fileBuilderList);

            //loop keys to get the sum values for the balance,actual,encumbrance
        }


        public List<string> ActiveProjectGlKeysList()
        {

            var proData = new PublicworksProjectData();
            var keylist = new List<string>();
            return keylist;

        }


        public static void InsertDatabaseNonZeroFinanceProjectRecords(List<ProjectTrackingFinance> projectRecords)
        {

            var zeroBaseProjects = projectRecords
                .Where(r => r.ActualsBalance == 0 && r.BudgetBalance == 0 && r.EncumbranceBalance == 0)
                .Select(k => k.GeneralLedgerKey).ToList();

            foreach (var key in zeroBaseProjects)
            {
                projectRecords.RemoveAll(k => k.GeneralLedgerKey == key);
            }

            var proData = new PublicworksProjectData();
            var data = proData.PublicInsertProjectFundingRecords(projectRecords);


        }



    }
}
