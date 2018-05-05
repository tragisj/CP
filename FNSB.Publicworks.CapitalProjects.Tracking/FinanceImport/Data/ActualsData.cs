using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Publicworks.Finance.OneSolution.Entities;
using Publicworks.Finance.OneSolution.Properties;

namespace Publicworks.Finance.OneSolution.Data
{
    public class ActualsData
    {



        public decimal GetActualsBalanceForGlKey(string glkey)
        {
            ActualsData ad = new ActualsData();
            List<Actuals> acl = QueryForActualsValuesByGlKey(glkey);
            return CalculateActualBalance(acl);

        }


        private List<Actuals> QueryForActualsValuesByGlKey(string glkey)
        {

            var result = new List<Actuals>();
            using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.v13Pro))
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "dbo.SelectActualsIndexByKeyForCurrentFiscalYear";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("GlKey", glkey);

                using (var reader = sqlCommand.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var en = new Actuals
                        {
                            Actuals01 = (decimal)reader[0],
                            Actuals02 = (decimal)reader[1],
                            Actuals03 = (decimal)reader[2],
                            Actuals04 = (decimal)reader[3],
                            Actuals05 = (decimal)reader[4],
                            Actuals06 = (decimal)reader[5],
                            Actuals07 = (decimal)reader[6],
                            Actuals08 = (decimal)reader[7],
                            Actuals09 = (decimal)reader[8],
                            Actuals10 = (decimal)reader[9],
                            Actuals11 = (decimal)reader[10],
                            Actuals12 = (decimal)reader[11],
                            Actuals13 = (decimal)reader[12],
                            Actuals14 = (decimal)reader[13],
                            FiscalYear = (int)reader[14]

                        };

                        result.Add(en);
                    }
                }
            }
            return result;
        }




        private Dictionary<string, List<Actuals>> GetActualsValuesByActivePubworksProjects()
        {

            return null;

        }





        /// <summary>
        /// Returns the ActualBalances calculated from the KeyObjectFinanceList
        /// Use the SystemPeriod variable to extract Actual01 ... SystemPeriod integer
        /// and sum for each GlKey in the list
        /// </summary>
        /// <returns></returns>
        public decimal CalculateActualBalance(List<Actuals> actuals)
        {
            try
            {
                var calCalcs = new CalendarData();
                int sp = calCalcs.BudActSystemPeriod();
                int fy = calCalcs.CurrentFiscalYear();
                decimal cfy = CalculateActuals(actuals.Where(f => f.FiscalYear == fy), sp);
                decimal pfy = CalculateActuals(actuals.Where(f => f.FiscalYear < fy), 14);


                return (cfy + pfy);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private decimal CalculateActuals(IEnumerable<Actuals> actuals, int sysPeriod)
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
