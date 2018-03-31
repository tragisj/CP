using System;
using System.Data.SqlClient;
using Publicworks.Finance.OneSolution.Properties;

namespace Publicworks.Finance.OneSolution.Repository
{
    public class CalendarData
    {
  
        /// <summary>
        /// Returns the current fiscal year based on custom SQL Function to calculate FiscalYear based on the current FiscalYEar start
        /// date of 7/1/YYYY
        /// </summary>
        /// <returns>Integer</returns>
        public int CurrentFiscalYear()
        {
            try
            {
                int result = 0;
                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.v13Pro))
                using (SqlCommand sqlCommand = new SqlCommand("dbo.CurrentFiscalYear", sqlConnection))
                {
                    sqlConnection.Open();

                    var cmd = new SqlCommand(sqlCommand.CommandText, sqlConnection);
                    result = (int)cmd.ExecuteScalar();
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
        /// Returns the number of months between the start of the fiscal year and the current month. 
        /// Use to calculate Encumbrance and Actual values from OneSolution fiscal system
        /// </summary>
        /// <returns>Integer</returns>
        public int BudActSystemPeriod()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.v13Pro))
                using (SqlCommand sqlCommand = new SqlCommand("dbo.PayPeriodOffset", sqlConnection))
                {
                    sqlConnection.Open();
                    var cmd = new SqlCommand(sqlCommand.CommandText, sqlConnection);
                    return (int)cmd.ExecuteScalar();
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
