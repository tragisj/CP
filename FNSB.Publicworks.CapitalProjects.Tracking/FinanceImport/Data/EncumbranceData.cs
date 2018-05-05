using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Publicworks.Finance.OneSolution.Entities;
using Publicworks.Finance.OneSolution.Properties;

namespace Publicworks.Finance.OneSolution.Data
{
    public class EncumbranceData
    {
       
        public decimal GetEncubranceBalanceForGlKey(string glkey)
        {
            List<Encumbrance> ecl = GetEncumbrancesValuesByGlKey(glkey);
            return CalculateEncumbranceBalance(ecl);
        }


        /// <summary>
        /// Returns the Encumbrance fields from the OneSolution table bud_act_mstr matching the parameters fiscal year and glkey
        /// </summary>
        /// <param name="fiscalyear">Fiscal Year</param>
        /// <param name="glkey">GL Key</param>
        /// <returns></returns>
        private List<Encumbrance> GetEncumbrancesValuesByGlKey(string glkey)
        { 
            var result = new List<Encumbrance>();
            using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.v13Pro))
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "dbo.SelectEncumbranceIndexByKeyForCurrentFiscalYear";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("GlKey", glkey);

                using (var reader = sqlCommand.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var en = new Encumbrance
                        {
                            En01 = (decimal)reader[0],
                            En02 = (decimal)reader[1],
                            En03 = (decimal)reader[2],
                            En04 = (decimal)reader[3],
                            En05 = (decimal)reader[4],
                            En06 = (decimal)reader[5],
                            En07 = (decimal)reader[6],
                            En08 = (decimal)reader[7],
                            En09 = (decimal)reader[8],
                            En10 = (decimal)reader[9],
                            En11 = (decimal)reader[10],
                            En12 = (decimal)reader[11]
                        };

                        result.Add(en);
                    }
                }
            }

            return result;
        }


        private decimal CalculateEncumbranceBalance(List<Encumbrance> encumbrances)
        {
            try
            {

                var calCalcs = new CalendarData();
                return CalculateEncumbrances(encumbrances, calCalcs.BudActSystemPeriod());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



        private decimal CalculateEncumbrances(IEnumerable<Encumbrance> enc, int sysPeriod)
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
