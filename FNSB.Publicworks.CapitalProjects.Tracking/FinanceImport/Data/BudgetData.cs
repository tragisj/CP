using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Publicworks.Finance.OneSolution.Domain;
using Publicworks.Finance.OneSolution.Domain.Helpers;
using Publicworks.Finance.OneSolution.Properties;

namespace Publicworks.Finance.OneSolution.Data
{
    public class BudgetData
    {

        public List<Budget> GetBudgetIndexValuesByGlKey(string key)
        {
            try
            {

                var result = new List<Budget>();

                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.PSQL_DB))
                using (SqlCommand sqlCommand = new SqlCommand("Publicworks.SelectBudgetIndexByKey", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@GlKey", key);
                    sqlCommand.Parameters.Add("@FiscalYearOut", SqlDbType.Int).Direction = ParameterDirection.Output;

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var bd = new Budget
                            {
                                //GlKey = key,
                                //GlObject = Convert.ToString(reader["glba_obj"]),
                                //FiscalYear = Convert.ToInt32(sqlCommand.Parameters["@FiscalYearOut"].Value),
                                Budget01 = Convert.ToDecimal(reader["glb_budget01"]),
                                Budget02 = Convert.ToDecimal(reader["glb_budget02"]),
                                Budget03 = Convert.ToDecimal(reader["glb_budget03"]),
                                Budget04 = Convert.ToDecimal(reader["glb_budget04"]),
                                Budget05 = Convert.ToDecimal(reader["glb_budget05"]),
                                Budget06 = Convert.ToDecimal(reader["glb_budget06"]),
                                Budget07 = Convert.ToDecimal(reader["glb_budget07"]),
                                Budget08 = Convert.ToDecimal(reader["glb_budget08"]),
                                Budget09 = Convert.ToDecimal(reader["glb_budget09"]),
                                Budget10 = Convert.ToDecimal(reader["glb_budget10"]),
                                Budget11 = Convert.ToDecimal(reader["glb_budget11"]),
                            };

                            result.Add(bd);
                        }
                    }
                }

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        /// <summary>
        /// Returns all the budget field values (1-12) and corresponding GlKey/Objects in a list of KeyObjects. These are not aggregated values
        /// because the budget index values are not passed and the certain GLKeys will contain multiple objects.
        /// </summary>
        /// <param name="fiscalYear"></param>
        /// <returns></returns>
        public List<OneSolutionBudgetActualDataList> GetBudgetIndexValuesForCurrentFiscalYear(out int fiscalYear)
        {
            try
            {
                var result = new List<OneSolutionBudgetActualDataList>();

                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.PSQL_DB))
                using (SqlCommand sqlCommand = new SqlCommand("Publicworks.SelectBudgetIndexesByCurrentFiscalYear", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@FiscalYearOut", SqlDbType.Int).Direction = ParameterDirection.Output;
                    
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var budget = new Budget
                            {
                                Budget01 = Convert.ToDecimal(reader["glb_budget01"]),
                                Budget02 = Convert.ToDecimal(reader["glb_budget02"]),
                                Budget03 = Convert.ToDecimal(reader["glb_budget03"]),
                                Budget04 = Convert.ToDecimal(reader["glb_budget04"]),
                                Budget05 = Convert.ToDecimal(reader["glb_budget05"]),
                                Budget06 = Convert.ToDecimal(reader["glb_budget06"]),
                                Budget07 = Convert.ToDecimal(reader["glb_budget07"]),
                                Budget08 = Convert.ToDecimal(reader["glb_budget08"]),
                                Budget09 = Convert.ToDecimal(reader["glb_budget09"]),
                                Budget10 = Convert.ToDecimal(reader["glb_budget10"]),
                                Budget11 = Convert.ToDecimal(reader["glb_budget11"]),
                                Budget12 = Convert.ToDecimal(reader["glb_budget12"])
                            };

                            var kd = new OneSolutionBudgetActualDataList
                            {
                                Key = Convert.ToString(reader["glba_key"]).TrimEnd(),
                                Object = Convert.ToString(reader["glba_obj"]).TrimEnd(),
                                FiscalYear = Convert.ToInt32(reader["glba_fy"]),
                                Budget = budget
                            };

                            result.Add(kd);
                        }
                    }

                    fiscalYear = Convert.ToInt32(sqlCommand.Parameters["@FiscalYearOut"].Value);
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



        /// <summary>
        /// Performs SQL server stored procedure execution to retrieve budget version data from OneSolution tables
        /// </summary>
        /// <returns>List<list type="BudgetVersions"></list></returns>
        public List<BudgetVersions> GetAllBudgetVersions()
        {
            try
            {
                var result = new List<BudgetVersions>();
                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.PSQL_DB))
                using (SqlCommand sqlCommand = new SqlCommand("Publicworks.SelectAllOSBudgetVersions", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var bv = new BudgetVersions();

                            if (reader[0] != null)
                            {
                                var budgetCalc = reader[0].ToString().TrimEnd();
                                bv.Calc = budgetCalc;
                            }

                            if (reader[1] != null)
                            {
                                var budgetIndex = (short) reader[1];
                                bv.Index = budgetIndex;
                            }

                            if (reader[2] != null)
                            {
                                var budgetCode = reader[2].ToString().TrimEnd();
                                bv.Code = budgetCode;
                            }

                            if (reader[3] != null)
                            {
                                var budgetDesc = reader[3].ToString();
                                bv.Desc = budgetDesc;
                            }

                            result.Add(bv);
                        }
                    }
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



    }
}
