using System;
using System.Collections.Generic;
using System.Linq;

namespace FNSB.PW.Finance.Import.Domain.Helpers
{
    public class EncumbrancesCalculations
    {

        private int SystemPeriod { get; }
        private int CurrentFiscalYear { get; }
        private List<OneSolutionBudgetActualDataList> KeyObjectFinanceList { get; }
        private List<string> GeneralLedgerKeyList { get; }


        public EncumbrancesCalculations(ref List<OneSolutionBudgetActualDataList> keyObjectsList, ref List<string> generalLedgerKeyList)
        {
            KeyObjectFinanceList = keyObjectsList;
            GeneralLedgerKeyList = generalLedgerKeyList;

            //new instance of CalendarCalcs to get SystemPeriod integer and CurrentFiscalYear integer
            var calCalcs = new CalendarCalculations();

            //fiscal dates and periods
            SystemPeriod = calCalcs.BudActSystemPeriod();
            CurrentFiscalYear = calCalcs.CurrentFiscalYear();
        }


        public Dictionary<string, EncumbranceBalance> BuildEncumbranceBalances()
        {
            try
            {
                var result = new Dictionary<string, EncumbranceBalance>();

                //loop the unique GL keys list and 
                foreach (var key in GeneralLedgerKeyList)
                {
                    var ab = new EncumbranceBalance();
                    var cfyEncumbrances = CalculateEncumbrances(
                        KeyObjectFinanceList.Where(k => k.Key == key && k.FiscalYear == CurrentFiscalYear)
                            .Select(a => a.Encumbrance), SystemPeriod);

                    ab.Amount = cfyEncumbrances;
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



        private static decimal CalculateEncumbrances(IEnumerable<Encumbrance> enc, int sysPeriod)
        {
            try
            {
                decimal keyEncumbranceSum;

                switch (sysPeriod)
                {
                    case 1:
                        keyEncumbranceSum = enc.Sum(d => d.En01);
                        break;
                    case 2:
                        keyEncumbranceSum = enc.Sum(d => d.En02);
                        break;
                    case 3:
                        keyEncumbranceSum = enc.Sum(d => d.En03);
                        break;
                    case 4:
                        keyEncumbranceSum = enc.Sum(d => d.En04);
                        break;
                    case 5:
                        keyEncumbranceSum = enc.Sum(d => d.En05);
                        break;
                    case 6:
                        keyEncumbranceSum = enc.Sum(d => d.En06);
                        break;
                    case 7:
                        keyEncumbranceSum = enc.Sum(d => d.En07);
                        break;
                    case 8:
                        keyEncumbranceSum = enc.Sum(d => d.En08);
                        break;
                    case 9:
                        keyEncumbranceSum = enc.Sum(d => d.En09);
                        break;
                    case 10:
                        keyEncumbranceSum = enc.Sum(d => d.En10);
                        break;
                    case 11:
                        keyEncumbranceSum = enc.Sum(d => d.En11);
                        break;
                    case 12:
                        keyEncumbranceSum = enc.Sum(d => d.En12);
                        break;
                    case 13:
                        keyEncumbranceSum = enc.Sum(d => d.En13);
                        break;
                    default:
                        keyEncumbranceSum = enc.Sum(d => d.En14);
                        break;
                }

                return keyEncumbranceSum;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }






    }
}
