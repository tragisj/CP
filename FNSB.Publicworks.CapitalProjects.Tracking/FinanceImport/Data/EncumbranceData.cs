using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FNSB.PW.Finance.Import.Domain;
using FNSB.PW.Finance.Import.Properties;

namespace FNSB.PW.Finance.Import.Data
{
    public class EncumbranceData
    {



        /// <summary>
        /// Returns the Encumbrance fields from the OneSolution table bud_act_mstr matching the parameters fiscal year and glkey
        /// </summary>
        /// <param name="fiscalyear">Fiscal Year</param>
        /// <param name="glkey">GL Key</param>
        /// <returns></returns>
        List<Encumbrance> ValuesByGlKey(int fiscalyear, string glkey)
        {
            var result = new List<Encumbrance>();
            using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "Publicworks.SelectEncumbranceByGlKey";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FiscalYear", fiscalyear);
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



        ///// <summary>
        ///// Sums the Encumbrance values for the provided GLkey and fiscal year
        ///// </summary>
        ///// <param name="glKey">GL Key</param>
        ///// <param name="fiscalYear">Fiscal Year</param>
        ///// <returns></returns>
        //public decimal CurrentEncumbranceTotalsByKey(string glKey, int fiscalYear)
        //{

        //    var encs = ValuesByGlKey(fiscalYear, glKey);
        //    int offset = CurrentOffset();
        //    decimal ens = 0;

        //    switch (offset)
        //    {
        //        case (int)Encumbrance.OffsetField.En01:
        //            ens = encs.Select(d => d.En01).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En02:
        //            ens = encs.Select(d => d.En02).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En03:
        //            ens = encs.Select(d => d.En03).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En04:
        //            ens = encs.Select(d => d.En04).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En05:
        //            ens = encs.Select(d => d.En05).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En06:
        //            ens = encs.Select(d => d.En06).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En07:
        //            ens = encs.Select(d => d.En07).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En08:
        //            ens = encs.Select(d => d.En08).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En09:
        //            ens = encs.Select(d => d.En09).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En10:
        //            ens = encs.Select(d => d.En10).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En11:
        //            ens = encs.Select(d => d.En11).Sum();
        //            break;
        //        case (int)Encumbrance.OffsetField.En12:
        //            ens = encs.Select(d => d.En12).Sum();
        //            break;
        //        default:
        //            break;
        //    }
        //    return ens;
        //}
        
    }
}
