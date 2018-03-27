using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using Publicworks.Conversion.Properties;
using Publicworks.Entities.Funds;
using Publicworks.Entities.Projects;

namespace Publicworks.Conversion.Conversions
{
    public class ProjectConversion
    {

        public List<ProjectData> GetProjectCore()
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = @"[Publicworks].[SelectViewProjectAgency]";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                List<ProjectData> list = new List<ProjectData>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            //if (reader[2].ToString().TrimEnd() != "05-TWOPRJ-1") continue;

                            var ap = new ProjectData()
                            {
                                ActiveProject = (bool) reader[0],
                                CompletedProject = (bool) reader[1],
                                ProjectNumber = reader[2].ToString().TrimEnd(),
                                ProjectName = reader[3].ToString().TrimEnd(),
                                StatusDesc = reader[4].ToString().TrimEnd(),
                                ProjectScope = reader[5].ToString().TrimEnd(),
                                ChangeOrders = (decimal) reader[6],
                                ContractAmendments = (decimal) reader[7],
                                ConsultantFees = (decimal) reader[8],
                                ContractAmount = (decimal) reader[9],
                                PercentConstructionComplete = (int) reader[10],
                                PercentDesignComplete = (int) reader[11],
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
                                Activated = (DateTime) reader[23],
                                Inactivated = (DateTime) reader[24],
                                AgendaSetting = (DateTime) reader[25],
                                AssemblyApproval = (DateTime) reader[26],
                                AdvertiseForBid = (DateTime) reader[27],
                                BidOpening = (DateTime) reader[28],
                                OriginalBidDate = (DateTime) reader[29],
                                ConstructionBidAward = (DateTime) reader[30],
                                ConsultantBidAward = (DateTime) reader[31],
                                DesignCompleted = (DateTime) reader[32],
                                NoticeToProceed = (DateTime) reader[33],
                                SubstantialCompletion = (DateTime) reader[34],
                                FinalInspection = (DateTime) reader[35],
                                WarrantyPeriodEnds = (DateTime) reader[36],
                                ClosedDate = (DateTime) reader[37]
                            };
                            list.Add(ap);
                        }

                        return list;
                    }

                    return null;
                }
            }
        }

        public void MigrateProjects(List<ProjectData> projects)
        {

            var context = new Publicworks.Data.Context.ApplicationDbContext();

            var cps = new List<Project>();
            {
                foreach (var x in projects)
                {
                    var c = new Project()
                    {
                        ProjectID = Guid.NewGuid(),
                        ActiveProject = x.ActiveProject,
                        CompletedProject = x.CompletedProject,
                        ProjectNumber = x.ProjectNumber,
                        ProjectName = x.ProjectName,
                        StatusDescription = x.StatusDesc,
                        ProjectScope = x.ProjectScope,
                        ChangeOrders = x.ChangeOrders,
                        ContractAmendments = x.ContractAmendments,
                        ConsultantFees = x.ConsultantFees,
                        ContractAmount = x.ContractAmount,
                        PercentConstructionComplete = x.PercentConstructionComplete,
                        PercentDesignComplete = x.PercentDesignComplete,
                        ProjectUserID =
                            GetAgencyIdFromFirstLast(context, x.ProjectUserFirst, x.ProjectUserLast, "user"),
                        ArchitectEngineerID =
                            GetAgencyIdFromFirstLast(context, x.ArchitectFirst, x.ArchitectLast, "arc"),
                        ProjectManagerID =
                            GetAgencyIdFromFirstLast(context, x.ProjectManagerFirst, x.ProjectManagerLast, "pm"),
                        SecretaryID = GetAgencyIdFromFirstLast(context, x.SecretaryFirst, x.SecretaryLast, "sec"),
                        ProjectTypeID = GetAgencyIdFromFirstLast(context, x.ProjectType, "", "type"),
                        ConsultantID = GetAgencyIdFromFirstLast(context, x.ConsultantName, "", "csn"),
                        ContractorID = GetAgencyIdFromFirstLast(context, x.ContractorName, "", "con"),
                        Activated = x.Activated,
                        Inactived = BoroDateNull(x.Inactivated),
                        AgendaSetting = BoroDateNull(x.AgendaSetting),
                        AssemblyApproval = BoroDateNull(x.AssemblyApproval),
                        AdvertiseForBid = BoroDateNull(x.AdvertiseForBid),
                        BidOpening = BoroDateNull(x.BidOpening),
                        OriginalBidDate = BoroDateNull(x.OriginalBidDate),
                        ConstructionBidAward = BoroDateNull(x.ConstructionBidAward),
                        ConsultantBidAward = BoroDateNull(x.ConsultantBidAward),
                        DesignCompleted = BoroDateNull(x.DesignCompleted),
                        NoticeToProceed = BoroDateNull(x.NoticeToProceed),
                        SubstantialCompletion = BoroDateNull(x.SubstantialCompletion),
                        FinalInspection = BoroDateNull(x.FinalInspection),
                        WarrantyPeriodEnds = BoroDateNull(x.WarrantyPeriodEnds),
                        ClosedDate = BoroDateNull(x.ClosedDate)
                    };

                    cps.Add(c);
                }

                cps.ForEach(s => context.Projects.AddOrUpdate(p => p.ProjectID, s));
              context.SaveChanges();

            }
        }

        public void MigrateGlKeys(List<ProjectFundKey> funds)
        {

            var context = new Publicworks.Data.Context.ApplicationDbContext();

            //var pt = context.Projects.FirstOrDefault(p => p.ProjectNumber == "04-TJHPRJ-1").ProjectID;

            var cpf = new List<GeneralLedgerKey>();

            foreach (var x in funds)
            {
                var c = new GeneralLedgerKey
                {
                    GeneralLedgerKeyID = Guid.NewGuid(),
                    ActiveKey = true,
                    FinanceImportDate = DateTime.Today,
                    GLKey = x.Glkey,
                    ProjectID = context.Projects.FirstOrDefault(p => p.ProjectNumber == x.ProjectNo).ProjectID
                };

                cpf.Add(c);
            }



            cpf.ForEach(s => context.GeneralLedgerKeys.AddOrUpdate(p => p.GeneralLedgerKeyID, s));
            context.SaveChanges();

        }

    
        private DateTime? BoroDateNull(DateTime borodate)
        {
            DateTime bday = new DateTime(1964, 6, 30, 0, 0, 0);

            if (borodate != bday)
            {
                return borodate;
            }

            return null;
        }

        private Guid GetAgencyIdFromFirstLast(Publicworks.Data.Context.ApplicationDbContext context, string first,
            string last, string agency)
        {

            switch (agency)
            {
                case "arc":
                    return context.ArchitectEngineers
                        .FirstOrDefault(f => f.FirstName == first && f.LastName == last).ArchitectEngineerID;
                case "pm":
                    return context.ProjectManagers
                        .FirstOrDefault(f => f.FirstName == first && f.LastName == last).ProjectManagerID;
                case "user":
                    return context.Users
                        .FirstOrDefault(f => f.FirstName == first && f.LastName == last).ProjectUserID;
                case "sec":
                    return context.Secretaries
                        .FirstOrDefault(f => f.FirstName == first && f.LastName == last).SecretaryID;
                case "type":
                    return context.ProjectTypes.FirstOrDefault(f => f.Name == first).ProjectTypeID;
                case "csn":
                    return context.Consultants.FirstOrDefault(f => f.ConsultantName == first).ConsultantID;
                case "con":
                    return context.Contractors.FirstOrDefault(f => f.ContractorName == first).ContractorID;
            }

            return Guid.Empty;
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

            //public string GlKey { get; set; }
            //public string GlKeyDesc { get; set; }

        }
    }
}

