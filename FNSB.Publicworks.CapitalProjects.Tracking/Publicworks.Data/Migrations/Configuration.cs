using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Globalization;
using Publicworks.Conversion;
using Publicworks.Entities.Admin;
using Publicworks.Entities.Agents;
using Publicworks.Entities.Funds;
using Publicworks.Entities.Projects;

namespace Publicworks.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Publicworks.Data.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Publicworks.Data.Context.ApplicationDbContext";
        }

        protected override void Seed(Publicworks.Data.Context.ApplicationDbContext context)
        {

            try
            {
                var ac = new Publicworks.Conversion.AdminConversion();
                List<AgencyAdminPerson> arclist = ac.GetArchitectFirstLast();
                List<AgencyAdminPerson> pmlist = ac.GetProjectMgrFirstLast();
                List<AgencyAdminPerson> seclist = ac.GetSecretaryFirstLast();
                List<AgencyAdminPerson> userlist = ac.GetUserFirstLast();
                List<AgencyName> consultantlist = ac.GetConsultantName();
                List<AgencyName> contractorlist = ac.GetContractorName();
                List<AgencyName> protypelist = ac.GetProjectTypeName();

                var pc = new Publicworks.Conversion.ProjectConversion();
                List<ProjectData> corelist = pc.GetProjectCore();

                //Contractor List
                var crs = new List<Contractor>();
                {
                    foreach (var x in contractorlist)
                    {
                        var c = new Contractor
                        {
                            ContractorName = x.Name,
                            ContractorID = Guid.NewGuid(),
                            Active = false
                        };
                        crs.Add(c);
                    }
                };

                crs.ForEach(s => context.Contractors.AddOrUpdate(p => p.ContractorID, s));
                context.SaveChanges();


                var cns = new List<Consultant>();
                {
                    foreach (var x in consultantlist)
                    {
                        var c = new Consultant()
                        {
                            ConsultantName = x.Name,
                            ConsultantID = Guid.NewGuid(),
                            Active = false
                        };
                        cns.Add(c);
                    }
                };

                cns.ForEach(s => context.Consultants.AddOrUpdate(p => p.ConsultantID, s));
                context.SaveChanges();

                //Secretary List
                var scs = new List<Secretary>();
                {
                    foreach (var x in seclist)
                    {
                        var c = new Secretary()
                        {
                            FirstName = x.First,
                            LastName = x.Last,
                            SecretaryID = Guid.NewGuid(),
                            Active = false
                        };
                        scs.Add(c);
                    }
                };

                scs.ForEach(s => context.Secretaries.AddOrUpdate(p => p.SecretaryID, s));
                context.SaveChanges();



                //Architect Engineer List
                var erl = new List<ArchitectEngineer>();
                {
                    foreach (var x in arclist)
                    {
                        var c = new ArchitectEngineer()
                        {
                            FirstName = x.First,
                            LastName = x.Last,
                            ArchitectEngineerID = Guid.NewGuid(),
                            Active = false
                        };
                        erl.Add(c);
                    }
                };

                erl.ForEach(s => context.ArchitectEngineers.AddOrUpdate(p => p.ArchitectEngineerID, s));
                context.SaveChanges();


                //ProjectManager List

                var pml = new List<ProjectManager>();
                {
                    foreach (var x in pmlist)
                    {
                        var c = new ProjectManager()
                        {
                            FirstName = x.First,
                            LastName = x.Last,
                            ProjectManagerID = Guid.NewGuid(),
                            Active = false
                        };
                        pml.Add(c);
                    }
                };

                pml.ForEach(s => context.ProjectManagers.AddOrUpdate(p => p.ProjectManagerID, s));
                context.SaveChanges();

                //ProjectType List

                var ptl = new List<ProjectType>();
                {
                    foreach (var x in protypelist)
                    {
                        var c = new ProjectType()
                        {
                            Name = x.Name,
                            ProjectTypeID = Guid.NewGuid(),
                            Active = false
                        };
                        ptl.Add(c);
                    }
                };

                ptl.ForEach(s => context.ProjectTypes.AddOrUpdate(p => p.ProjectTypeID, s));
                context.SaveChanges();



                var pul = new List<ProjectUser>();
                {
                    foreach (var x in userlist)
                    {
                        var c = new ProjectUser()
                        {
                            FirstName = x.First,
                            LastName = x.Last,
                            ProjectUserID = Guid.NewGuid(),
                            Active = false
                        };
                        pul.Add(c);
                    }
                };

                pul.ForEach(s => context.Users.AddOrUpdate(p => p.ProjectUserID, s));
                context.SaveChanges();


                //FUNDS

                //var kl = new FNSB.PW.Finance.Import.Data.PublicworksProjectData();
                //List<string> glkeys = kl.GetProjectConnectedFunds();

                //var keys = new List<GeneralLedgerKey>();
                //foreach (var x in glkeys)
                //{
                //    var fk = new GeneralLedgerKey
                //    {
                //        GeneralLedgerKeyID = Guid.NewGuid(),
                //        GLKey = x.Trim()
                //    };

                //    keys.Add(fk);
                //}

                //keys.ForEach(s => context.GeneralLedgerKeys.AddOrUpdate(p => p.GeneralLedgerKeyID, s));
                //context.SaveChanges();


                //someValue = condition ? newValue : someValue;

                DateTime? foo;
                foo = true ? (DateTime?)null : new DateTime(0);

                var cps = new List<Project>();
                {
                    foreach (var x in corelist)
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
                            ProjectUserID = GetAgencyIdFromFirstLast(context, x.ProjectUserFirst, x.ProjectUserLast, "user"),
                            ArchitectEngineerID = GetAgencyIdFromFirstLast(context, x.ArchitectFirst, x.ArchitectLast, "arc"),
                            ProjectManagerID = GetAgencyIdFromFirstLast(context, x.ProjectManagerFirst, x.ProjectManagerLast, "pm"),
                            SecretaryID = GetAgencyIdFromFirstLast(context, x.SecretaryFirst, x.SecretaryLast, "sec"),
                            ProjectTypeID = GetAgencyIdFromFirstLast(context, x.ProjectType, "",  "type"),
                            ConsultantID = GetAgencyIdFromFirstLast(context, x.ConsultantName, "",  "csn"),
                            ContractorID = GetAgencyIdFromFirstLast(context, x.ContractorName, "",  "con"),
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
                            NoticeToProceed  = BoroDateNull(x.NoticeToProceed),
                            SubstantialCompletion = BoroDateNull(x.SubstantialCompletion),
                            FinalInspection = BoroDateNull(x.FinalInspection),
                            WarrantyPeriodEnds = BoroDateNull(x.WarrantyPeriodEnds),
                            ClosedDate = BoroDateNull(x.ClosedDate)
                        };

                        cps.Add(c);
                    }
                };

                cps.ForEach(s => context.Projects.AddOrUpdate(p => p.ProjectID, s));
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                SqlException sqlException = (SqlException)updateException.InnerException;

                foreach (SqlError error in sqlException.Errors)
                {
                    // TODO: Do something with your errors
                }
            }
        }



        private DateTime? BoroDateNull(DateTime borodate)
        {
            DateTime bday = new DateTime(1964,6,30,0,0,0);

            if (borodate != bday)
            {
                return borodate;
            }

            return null;
        }


        private Guid GetAgencyIdFromFirstLast(Publicworks.Data.Context.ApplicationDbContext context, string first, string last, string agency) 
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



    }
}
