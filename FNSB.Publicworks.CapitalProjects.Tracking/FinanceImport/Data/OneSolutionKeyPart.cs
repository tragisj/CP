using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Publicworks.Finance.OneSolution.Entities;
using Publicworks.Finance.OneSolution.Properties;

namespace Publicworks.Finance.OneSolution.Data
{
    public class OneSolutionKeyPart
    {

        private List<KeyPartDetail> KeyPartData(string glKey)
        {
            //Example layout
            //PartNo PartValue   GroupId GroupName   GroupLongDesc

            //01  3           FGRP Fund Group Capital Projects Fund Group
            //02  31          FUND Fund    State Grants
            //03  7           FUNC Function    Capital outlay
            //04  160         AGCY Funding Agency SLA 2012 SENATE BILL 160
            //05  08          DEPT Department  Public works
            //06  415         DIVN Division    DESIGN & CONSTRUCTION
            //07  999         SECT Section/ SVC Area N/ A
            //08  ATF SUBS    Sub Section FAIRBANKS YOUTH SOCCER

            var keyPartDetails = new List<KeyPartDetail>();
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.v13Pro))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = "[Publicworks].[SelectPartCodesByGroupFieldGLKey]";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@GlKey", SqlDbType.Char, 10);

                sqlCmd.Parameters[0].Value = glKey;

                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var detail = new KeyPartDetail
                        {
                            Number = reader["PartNo"].ToString().TrimEnd(),
                            Value = reader["PartValue"].ToString().TrimEnd(),
                            Id = reader["GroupId"].ToString().TrimEnd(),
                            Name = reader["GroupName"].ToString().TrimEnd(),
                            Description = reader["GroupLongDesc"].ToString().TrimEnd()
                        };

                        keyPartDetails.Add(detail);
                    }
                }
            }

            return keyPartDetails;
        }


    }
}
