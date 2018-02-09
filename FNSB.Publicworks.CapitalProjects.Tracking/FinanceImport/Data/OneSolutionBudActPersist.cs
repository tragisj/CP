using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FNSB.PW.Finance.Import.Domain;
using FNSB.PW.Finance.Import.Properties;

namespace FNSB.PW.Finance.Import.Data
{
    public class OneSolutionBudActPersist
    {

        public List<OneSolutionBudgetActualDataList> FinancialKeyObjects { get; set; }

        public OneSolutionBudActPersist()
        {
            FinancialKeyObjects = new List<OneSolutionBudgetActualDataList>();
            using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "Publicworks.SelectProjectTrackingBudgetActualEncumbrance";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ko = new OneSolutionBudgetActualDataList
                        {
                            FiscalYear = Convert.ToInt32(reader["budact_fy"].ToString().TrimEnd()),
                            JobLedgerKey = reader["jlkey"].ToString().TrimEnd(),
                            Key = reader["keymstr_key"].ToString().TrimEnd(),
                            Object = reader["objmstr_object"].ToString().TrimEnd(),
                            LongDesc = reader["keymstr_long_title"].ToString().TrimEnd(),

                            Budget = new Budget
                            {
                                Budget01 = (decimal) reader["bu01"],
                                Budget02 = (decimal) reader["bu02"],
                                Budget03 = (decimal) reader["bu03"],
                                Budget04 = (decimal) reader["bu04"],
                                Budget05 = (decimal) reader["bu05"],
                                Budget06 = (decimal) reader["bu06"],
                                Budget07 = (decimal) reader["bu07"],
                                Budget08 = (decimal) reader["bu08"],
                                Budget09 = (decimal) reader["bu09"],
                                Budget10 = (decimal) reader["bu10"],
                                Budget11 = (decimal) reader["bu11"],
                                Budget12 = (decimal) reader["bu12"]
                            },
                            Actuals = new Actual
                            {
                                Actuals01 = (decimal) reader["ac01"],
                                Actuals02 = (decimal) reader["ac02"],
                                Actuals03 = (decimal) reader["ac03"],
                                Actuals04 = (decimal) reader["ac04"],
                                Actuals05 = (decimal) reader["ac05"],
                                Actuals06 = (decimal) reader["ac06"],
                                Actuals07 = (decimal) reader["ac07"],
                                Actuals08 = (decimal) reader["ac08"],
                                Actuals09 = (decimal) reader["ac09"],
                                Actuals10 = (decimal) reader["ac10"],
                                Actuals11 = (decimal) reader["ac11"],
                                Actuals12 = (decimal) reader["ac12"],
                                Actuals13 = (decimal) reader["ac13"],
                                Actuals14 = (decimal) reader["ac14"]
                            },
                            Encumbrances = new Encumbrances
                            {
                                En01 = (decimal) reader["en01"],
                                En02 = (decimal) reader["en02"],
                                En03 = (decimal) reader["en03"],
                                En04 = (decimal) reader["en04"],
                                En05 = (decimal) reader["en05"],
                                En06 = (decimal) reader["en06"],
                                En07 = (decimal) reader["en07"],
                                En08 = (decimal) reader["en08"],
                                En09 = (decimal) reader["en09"],
                                En10 = (decimal) reader["en10"],
                                En11 = (decimal) reader["en11"],
                                En12 = (decimal) reader["en12"],
                                En13 = (decimal) reader["en13"],
                                En14 = (decimal) reader["en14"]
                            }
                        };
                        FinancialKeyObjects.Add(ko);
                    }
                }
            }
        }
    }
}

    
