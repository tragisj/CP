using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNSB.PW.Finance.Import.Domain.Helpers
{
    public class ActualsCalculations
    {

        private int SystemPeriod { get; }
        private int CurrentFiscalYear { get; }
        private List<OneSolutionBudgetActualDataList> KeyObjectFinanceList { get;  }
        private List<string> GeneralLedgerKeyList { get; set; }

        public ActualsCalculations(ref List<OneSolutionBudgetActualDataList> keyObjectList, ref List<string> uniqueKeyList)
        {

            KeyObjectFinanceList = keyObjectList;
            GeneralLedgerKeyList = uniqueKeyList;

            //new instance of CalendarCalcs to get SystemPeriod integer and CurrentFiscalYear integer
            var calCalcs = new CalendarCalculations();

            //fiscal dates and periods
            SystemPeriod = calCalcs.BudActSystemPeriod();
            CurrentFiscalYear = calCalcs.CurrentFiscalYear();
        }

        /// <summary>
        /// Returns the ActualBalances calculated from the KeyObjectFinanceList
        /// Use the SystemPeriod variable to extract Actual01 ... SystemPeriod integer
        /// and sum for each GlKey in the list
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, ActualsBalance> BuildActualsBalances()
        {
            try
            {
                var result = new Dictionary<string, ActualsBalance>();

                //loop the unique GL keys list and 
                foreach (var key in GeneralLedgerKeyList)
                {
                    var ab = new ActualsBalance();

                    var cfyActuals = CalculateActuals(
                        KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == CurrentFiscalYear)
                            .Select(a => a.Actuals), SystemPeriod);

                    var pfyActuals = CalculateActuals(
                        KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear < CurrentFiscalYear)
                            .Select(a => a.Actuals), 14);

                    ab.Amount = cfyActuals + pfyActuals;
                    result.Add(key, ab);
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private static decimal CalculateActuals(IEnumerable<Actual> actuals, int sysPeriod)
        {
            try
            {
                decimal keyActualSum = 0;

                switch (sysPeriod)
                {
                    case 1:
                        keyActualSum = actuals.Sum(d => d.Actuals01);
                        break;
                    case 2:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02);
                        break;
                    case 3:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03);
                        break;
                    case 4:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04);
                        break;
                    case 5:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04 + d.Actuals05);
                        break;
                    case 6:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04 + d.Actuals05 + d.Actuals06);
                        break;
                    case 7:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04 + d.Actuals05 + d.Actuals06 +
                            d.Actuals07);
                        break;
                    case 8:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04 + d.Actuals05 + d.Actuals06 +
                            d.Actuals07 + d.Actuals08);
                        break;
                    case 9:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04 + d.Actuals05 + d.Actuals06 +
                            d.Actuals07 + d.Actuals08 + d.Actuals09);
                        break;
                    case 10:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04 + d.Actuals05 + d.Actuals06 +
                            d.Actuals07 + d.Actuals08 + d.Actuals09 + d.Actuals10);
                        break;
                    case 11:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04 + d.Actuals05 + d.Actuals06 +
                            d.Actuals07 + d.Actuals08 + d.Actuals09 + d.Actuals10 + d.Actuals11);
                        break;
                    case 12:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04 + d.Actuals05 + d.Actuals06 +
                            d.Actuals07 + d.Actuals08 + d.Actuals09 + d.Actuals10 + d.Actuals11 + d.Actuals12);
                        break;
                    case 13:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04 + d.Actuals05 + d.Actuals06 +
                            d.Actuals07 + d.Actuals08 + d.Actuals09 + d.Actuals10 + d.Actuals11 + +d.Actuals12 + +d.Actuals13);
                        break;
                    default:
                        keyActualSum = actuals.Sum(d => d.Actuals01 + d.Actuals02 + d.Actuals03 + d.Actuals04 + d.Actuals05 + d.Actuals06 +
                            d.Actuals07 + d.Actuals08 + d.Actuals09 + d.Actuals10 + d.Actuals11 + +d.Actuals12 + d.Actuals13 + d.Actuals14);
                        break;
                }

                return keyActualSum;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
