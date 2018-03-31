using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Publicworks.Finance.OneSolution.Entities;
using Publicworks.Finance.OneSolution.Helpers;
using Publicworks.Finance.OneSolution.Properties;

namespace Publicworks.Finance.OneSolution.Repository
{
    public class BudgetData
    {


        //BudgetData = new BudgetData();
        ////stores the BudgetVersion data into the public property BudgetVersions
        private List<BudgetVersions> BudgetVersions { get; }
        //private BudgetData BudgetData { get; }

        public BudgetData()
        {
            BudgetVersions = new List<BudgetVersions>(GetAllBudgetVersions());
        }


        public List<BudgetBalance> GetBudgetBalanceForGlKey(string glkey)
        {

            List<Budget> bl = GetBudgetIndexValuesByGlKey(2018, glkey);
            decimal budget = BuildWorkingBudgetBalanceForGlKeyByFiscalYear(2018, glkey, bl, out var budgetcode);

            List<BudgetBalance> bb = new List<BudgetBalance>();
            BudgetBalance budgetBalance = new BudgetBalance
            {
                Amount = budget,
                BudgetVersion = budgetcode,
                FiscalYear = 2018
            };

            bb.Add(budgetBalance);
            return bb;
        }



        /// <summary>
        /// Returns all the budget field values (1-12) and corresponding GlKey/Objects in a list of KeyObjects. These are not aggregated values
        /// because the budget index values are not passed and the certain GLKeys will contain multiple objects.
        /// </summary>
        /// <param name="fiscalYear"></param>
        /// <returns></returns>
        private List<Budget> GetBudgetIndexValuesByGlKey(int fiscalyear, string glkey)
        {
            try
            {
                var result = new List<Budget>();

                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.v13Pro))
                using (SqlCommand sqlCommand = new SqlCommand("dbo.SelectBudgetIndexByKeyForCurrentFiscalYear", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@GlKey", glkey);
                    sqlCommand.Parameters.AddWithValue("@FiscalYear", fiscalyear);
                    //sqlCommand.Parameters.Add("@FiscalYearOut", SqlDbType.Int).Direction = ParameterDirection.Output;

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var bd = new Budget
                            {
                                //GlKey = key,
                                //GlObject = Convert.ToString(reader["glba_obj"]),
                                //FiscalYear = Convert.ToInt32(sqlCommand.Parameters["@FiscalYearOut"].Value),
                                Budget01 = Convert.ToDecimal(reader["bu01"]),
                                Budget02 = Convert.ToDecimal(reader["bu02"]),
                                Budget03 = Convert.ToDecimal(reader["bu03"]),
                                Budget04 = Convert.ToDecimal(reader["bu04"]),
                                Budget05 = Convert.ToDecimal(reader["bu05"]),
                                Budget06 = Convert.ToDecimal(reader["bu06"]),
                                Budget07 = Convert.ToDecimal(reader["bu07"]),
                                Budget08 = Convert.ToDecimal(reader["bu08"]),
                                Budget09 = Convert.ToDecimal(reader["bu09"]),
                                Budget10 = Convert.ToDecimal(reader["bu10"]),
                                Budget11 = Convert.ToDecimal(reader["bu11"]),
                                Budget12 = Convert.ToDecimal(reader["bu12"]),
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
        /// Performs SQL server stored procedure execution to retrieve budget version data from OneSolution tables
        /// </summary>
        /// <returns>List<list type="BudgetVersions"></list></returns>
        private List<BudgetVersions> GetAllBudgetVersions()
        {
            try
            {
                var result = new List<BudgetVersions>();
                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.v13Pro))
                using (SqlCommand sqlCommand = new SqlCommand("dbo.SelectAllOSBudgetVersions", sqlConnection))
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


        /// <summary>
        /// Reduces the provided Budget Version down to database index values
        /// </summary>
        /// <param name="budgetVersion"></param>
        /// <returns>List<list type="short"></list></returns>
        private List<short> BuildBudgetVersionIndexList(string budgetVersion)
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


        private decimal BuildWorkingBudgetBalanceForGlKeyByFiscalYear(int fiscalYear, string key,
            List<Budget> budgetData, out string budgetcode)
        {

            budgetcode = LocalResource.BudgetVersions.WorkingBudget;
            //budget calculations
            var budgetIndexList = BuildBudgetVersionIndexList(LocalResource.BudgetVersions.WorkingBudget);

            //loop the unique list of Keys

            decimal budgetTotal = 0M;
            foreach (var budget in budgetData)
            {
                decimal[] keyBudgetSum =
                {
                    budget.Budget01,
                    budget.Budget02,
                    budget.Budget03,
                    budget.Budget04,
                    budget.Budget05,
                    budget.Budget06,
                    budget.Budget07,
                    budget.Budget08,
                    budget.Budget09,
                    budget.Budget10,
                    budget.Budget11,
                    budget.Budget12
                };

                foreach (short value in budgetIndexList)
                {
                    budgetTotal += keyBudgetSum[value - 1];
                }
            }

            return budgetTotal; ;
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
        private BudgetVersions GetBudgetVersion(string budgetCode)
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
