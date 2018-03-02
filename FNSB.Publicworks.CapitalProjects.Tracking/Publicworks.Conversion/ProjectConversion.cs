using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Conversion.Properties;

namespace Publicworks.Conversion
{
    public class ProjectConversion
    {

        public List<ProjectData> GetProjectCore()
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = @"[Publicworks].[SelectViewProjectAgencyGlKeys]";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                List<ProjectData> list = new List<ProjectData>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var ap = new ProjectData()
                            {
                                ActiveProject = (bool)reader[0],
                                CompletedProject = (bool)reader[1],
                                ProjectNumber = reader[2].ToString().TrimEnd(),
                                ProjectName = reader[3].ToString().TrimEnd(),
                                StatusDesc = reader[4].ToString().TrimEnd(),
                                ProjectScope = reader[5].ToString().TrimEnd(),
                                ChangeOrders = (decimal)reader[6],
                                ContractAmendments = (decimal)reader[7],
                                ConsultantFees = (decimal)reader[8],
                                ContractAmount = (decimal)reader[9],
                                PercentConstructionComplete = (int)reader[10],
                                PercentDesignComplete = (int)reader[11],
                                ArchitectFirst = reader[12].ToString().TrimEnd(),
                                ArchitectLast = reader[13].ToString().TrimEnd(), 
                                SecretaryFirst = reader[14].ToString().TrimEnd(), 
                                SecretaryLast = reader[15].ToString().TrimEnd(),
                                ProjectManagerFirst = reader[16].ToString().TrimEnd(),
                                ProjectManagerLast = reader[17].ToString().TrimEnd(),
                                ProjectUserFirst = reader[18].ToString().TrimEnd(),
                                ProjectUserLast = reader[19].ToString().TrimEnd(),
                                ContractorName = reader[20].ToString().TrimEnd(),
                                ConsultantName = reader[21].ToString().TrimEnd(),
                                ProjectType = reader[22].ToString().TrimEnd(),
                                Activated = (DateTime)reader[23],
                                Inactivated = (DateTime)reader[24],
                                AgendaSetting = (DateTime)reader[25],
                                AssemblyApproval = (DateTime)reader[26],
                                AdvertiseForBid = (DateTime)reader[27],
                                BidOpening = (DateTime)reader[28],
                                OriginalBidDate = (DateTime)reader[29],
                                ConstructionBidAward = (DateTime)reader[30],
                                ConsultantBidAward = (DateTime)reader[31],
                                DesignCompleted = (DateTime)reader[32],
                                NoticeToProceed = (DateTime)reader[33],
                                SubstantialCompletion = (DateTime)reader[34],
                                FinalInspection = (DateTime)reader[35],
                                WarrantyPeriodEnds = (DateTime)reader[36],
                                ClosedDate = (DateTime)reader[37],
                                GlKey = reader[38].ToString().TrimEnd(),
                                GlKeyDesc = reader[39].ToString().TrimEnd()
                            };
                            list.Add(ap);
                        }
                        return list;
                    }
                    return null;
                }
            }
        }

    }

    public class ProjectData
    {
        //CORE
        public bool ActiveProject { get; set; }
        public bool CompletedProject { get; set; }
      
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }

        public string StatusDesc { get; set; }
        public string ProjectScope { get; set; }


        //FEES and CONTRACTORS
        public decimal ChangeOrders { get; set; }
        public decimal ContractAmendments { get; set; }
        public decimal ConsultantFees { get; set; }
        public decimal ContractAmount { get; set; }

        //ADMIN
        public int PercentConstructionComplete { get; set; }
        public int PercentDesignComplete { get; set; }

        public string ArchitectFirst { get; set; }
        public string ArchitectLast { get; set; }

        public string SecretaryFirst { get; set; }
        public string SecretaryLast { get; set; }

        public string ProjectManagerFirst { get; set; }
        public string ProjectManagerLast { get; set; }

        public string ProjectUserFirst { get; set; }
        public string ProjectUserLast { get; set; }

        public string ContractorName { get; set; }
        public string ConsultantName { get; set; }
        public string ProjectType { get; set; }


        //KEY DATES
        public DateTime Activated { get; set; }
        public DateTime Inactivated { get; set; }

        public DateTime AgendaSetting { get; set; }
        public DateTime AssemblyApproval { get; set; }

        public DateTime AdvertiseForBid { get; set; }
        public DateTime BidOpening { get; set; }
        public DateTime OriginalBidDate { get; set; }

        public DateTime ConstructionBidAward { get; set; }
        public DateTime ConsultantBidAward { get; set; }
        public DateTime DesignCompleted { get; set; }
        public DateTime NoticeToProceed { get; set; }

        public DateTime SubstantialCompletion { get; set; }
        public DateTime FinalInspection { get; set; }
        public DateTime WarrantyPeriodEnds { get; set; }
        public DateTime ClosedDate { get; set; }

        public string GlKey { get; set; }
        public string GlKeyDesc { get; set; }

    }




}
