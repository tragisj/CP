using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNSB.PW.Finance.Import.Domain;
using FNSB.PW.Finance.Import.Properties;

namespace FNSB.PW.Finance.Import.Data
{
    public class PublicworksProjectData
    {

        public int PublicInsertProjectFundingRecords(List<ProjectTrackingFinance> projectList)
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = "[Publicworks].[InsertOneSolutionFinanceRecord]";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@GlKey", SqlDbType.Char, 20);
                sqlCmd.Parameters.Add("@GlKeyDescription", SqlDbType.NVarChar, 255);
                sqlCmd.Parameters.Add("@Budget", SqlDbType.Decimal, 20);
                sqlCmd.Parameters.Add("@Actuals", SqlDbType.Decimal, 20);
                sqlCmd.Parameters.Add("@Encumbrance", SqlDbType.Decimal, 20);
                sqlCmd.Parameters.Add("@JobLedgerProject", SqlDbType.NVarChar, 20);

                foreach (var project in projectList)
                {
                    sqlCmd.Parameters[0].Value = project.GeneralLedgerKey;
                    sqlCmd.Parameters[1].Value = project.GeneralLedgerDesc;
                    sqlCmd.Parameters[2].Value = project.BudgetBalance;
                    sqlCmd.Parameters[3].Value = project.ActualsBalance;
                    sqlCmd.Parameters[4].Value = project.EncumbranceBalance;
                    sqlCmd.Parameters[5].Value = project.JobLedgerProject;
                    var result = sqlCmd.ExecuteScalar();
                }

                sqlCmd.CommandText = "[Publicworks].[InsertOneSolutionKeyPartData]";
                return 1;
            }
        }

        public List<string> GetProjectConnectedFunds()
        {

            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {

                sqlConn.Open();
                sqlCmd.CommandText = @"SELECT [GLkey],[MediumDesc] FROM [Publicworks].[GlKeysToProjects]";
                sqlCmd.CommandType = CommandType.Text;

                List<string> glkeys = new List<string>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        glkeys.Add(reader[0].ToString().TrimEnd());
                    }
                }

                return glkeys;
            }
        }
    }
}


//public List<string> PublicWorksProjectFundGlKeys()
        //{
        //    using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
        //    using (SqlCommand sqlCmd = sqlConn.CreateCommand())
        //    {
        //        sqlConn.Open();
        //        sqlCmd.CommandText = "[Publicworks].[SelectProjectFundsKeys]";
        //        sqlCmd.CommandType = CommandType.StoredProcedure;

        //        using (var reader = sqlCmd.ExecuteReader())
        //        {
        //            while (reader.Read())

        //                if (reader[0] != null)
        //                {
        //                    var glkey = reader[0].ToString().TrimEnd();
        //                }


        //        }

        //    }

        //
