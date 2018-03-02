using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Conversion.Properties;

namespace Publicworks.Conversion
{
    public class FundConversion
    {

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
