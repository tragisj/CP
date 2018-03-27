using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Publicworks.Conversion.Properties;

namespace Publicworks.Conversion.Conversions
{
    public class FundConversion
    {

        public List<ProjectFundKey> GetProjectConnectedFunds()
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {

                sqlConn.Open();
                sqlCmd.CommandText = @"SELECT f.ppf_glkey, p.PPM_Project_Number 
                    FROM Publicworks.Funds f
                    INNER JOIN Publicworks.Projects p
                    ON f.ppm_recordid = p.PPM_Recordid;";

                sqlCmd.CommandType = CommandType.Text;

                List<ProjectFundKey> glkeys = new List<ProjectFundKey>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProjectFundKey key = new ProjectFundKey
                        {
                            Glkey = reader[0].ToString().TrimEnd(),
                            ProjectNo = reader[1].ToString().TrimEnd()
                        };
                        glkeys.Add(key);
                    }
                }
                return glkeys;
            }
        }
    }


    public class ProjectFundKey
    {
        public string Glkey { get; set; }
        public string ProjectNo { get; set; }

    }


}
