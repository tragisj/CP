using System.Collections.Generic;
using System.Linq;
using Publicworks.Finance.OneSolution.Data;

namespace Publicworks.Finance.OneSolution.Domain.Helpers
{
    public class BudgetCalculations
    {
        private List<OneSolutionBudgetActualDataList> KeyObjectFinanceList { get; }
        private List<string> GeneralLedgerKeyList { get; set; }
        private List<BudgetVersions> BudgetVersions { get; }
        private BudgetData BudgetData { get; }


        public Dictionary<string, decimal> BudgetCalculationsByKeyList(List<string> glKeysList)
        {

            foreach (var key in glKeysList)
            {


                
            }

            var result = new Dictionary<string, decimal>();
            return result;

        }


        /// <summary>
        /// Object Initialization - loads the full budget list into BudgetVersions public field value
        /// </summary>
        public BudgetCalculations(ref List<OneSolutionBudgetActualDataList> keyObjectList, ref List<string> uniqueKeyList)
        {
            //query the DB for all Budget Versions
            BudgetData = new BudgetData();
            //stores the BudgetVersion data into the public property BudgetVersions
            BudgetVersions = new List<BudgetVersions>(BudgetData.GetAllBudgetVersions());

            KeyObjectFinanceList = keyObjectList;
            GeneralLedgerKeyList = uniqueKeyList;
        }


        /// <summary>
        /// Reads from OS budact table and builds a list of KeyObjects
        /// </summary>
        /// <param name="fiscalYear"></param>
        /// <returns></returns>
        public List<OneSolutionBudgetActualDataList> CurrentFiscalYearBudgetKeyObjects(out int fiscalYear)
        {
            var result = new List<OneSolutionBudgetActualDataList>();
            //current fiscal year raw KeyObjects List
            return BudgetData.GetBudgetIndexValuesForCurrentFiscalYear(out fiscalYear);
        }

        /// <summary>
        /// Reduces the provided Budget Version down to database index values
        /// </summary>
        /// <param name="budgetVersion"></param>
        /// <returns>List<list type="short"></list></returns>
        public List<short> BuildBudgetVersionIndexList(string budgetVersion)
        {

            var bvIndexList = new List<short>();

            //recursive breakdown of budget calculations stored in database
            var res = GetIndexList(budgetVersion);

            //isolates index values that build the budget - not calc fields
            foreach (var index in res)
            {
                var isCalc = CalculatedBudgetField(index);
                if (!isCalc)
                    bvIndexList.Add(index);
            }
            return bvIndexList;
        }

        public Dictionary<string, BudgetBalance> BuildBudgetBalances(string budgetVersion, int fiscalYear)
        {
            //budget calculations
            var budgetIndexList = BuildBudgetVersionIndexList(LocalResource.BudgetVersions.WorkingBudget);

            //returns a unique list of GLKeys contained in the KeyObjects list. Use to loop and Sum
            GeneralLedgerKeyList = KeyObjectFinanceList.Select(k => k.Key).Distinct().ToList();

            //return value object
            var pbworksBalanceList = new Dictionary<string, BudgetBalance>();

            //loop the unique list of Keys
            foreach (var key in GeneralLedgerKeyList)
            {
                decimal[] keyBudgetSum =
                {
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget01),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget02),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget03),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget04),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget05),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget06),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget07),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget08),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget09),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget10),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget11),
                    KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == fiscalYear).Sum(b => b.Budget.Budget12)
                };

                decimal keyBudgetTotal = 0M;

                foreach (short value in budgetIndexList)
                {
                    keyBudgetTotal += keyBudgetSum[value - 1];
                }

                var keyobject = new BudgetBalance
                {
                    Amount = keyBudgetTotal,
                    BudgetVersion = LocalResource.BudgetVersions.WorkingBudget,
                    FiscalYear = fiscalYear
                };

                pbworksBalanceList.Add(key, keyobject);
            }
            return pbworksBalanceList;
        }


        /// <summary>
        /// Returns a list of all budget index values used to maintain a version of a OneSolution Finance system budget 
        /// </summary>
        /// <param name="budgetCode">OneSolution budget code value</param>
        /// <returns><list type="short"></list></returns>
        private IEnumerable<short> GetIndexList(string budgetCode)
        {
            //return list
            var budgetIndexList = new List<short>();

            //gets the budget version using the budget code parameter
            var budget = GetBudgetVersion(budgetCode);

            //adds the initial budget code index value
            budgetIndexList.Add(budget.Index);

            //check to see if the 'budget' is a calculated budget field - exit check for recursion
            if (budget.Calc != string.Empty) //calculated
            {
                var calculation = SplitBudgetCodes(budget.Calc); //split codes to List
                foreach (var cc in calculation) //loop list of budget codes
                {
                    budgetIndexList.AddRange(GetIndexList(cc)); //recursive call to check for calc budget
                }
            }

            //return budget code list
            return budgetIndexList;
        }

        /// <summary>
        /// Returns a single budget version instance based on the budget code input value
        /// </summary>
        /// <param name="budgetCode">2 character budget code to base BudgetVersion class object on</param>
        /// <returns>single instance of BudgetVersion class objet</returns>
        public BudgetVersions GetBudgetVersion(string budgetCode)
        {
            return BudgetVersions.Single(bc => bc.Code == budgetCode);
        }

        /// <summary>
        /// Boolean method determines if the budget is calculated based on the supplied index value
        /// </summary>
        /// <param name="budgetIndex"></param>
        /// <returns>Boolean value</returns>
        private bool CalculatedBudgetField(short budgetIndex)
        {
            return BudgetVersions.Where(c => c.Index == budgetIndex).Any(d => d.Calc != string.Empty);
        }

        /// <summary>
        /// Accepts a calculated budget string and parses it into individual budget code values
        /// </summary>
        /// <param name="calculation">calculated budget value</param>
        /// <returns>string list of budget code values</returns>
        private static IEnumerable<string> SplitBudgetCodes(string calculation)
        {
            return calculation.Split('+').ToList();
        }
    }
}

