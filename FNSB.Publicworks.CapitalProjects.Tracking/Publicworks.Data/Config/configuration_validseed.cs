using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using Publicworks.Entities.Admin;
using Publicworks.Entities.Agents;
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


                //Contractor List
                var crs = new List<Contractor>
                {
                    new Contractor
                    {
                        Description = "Summit Enterprise (Contractor)",
                        ContractorName = "Summit Enterprise",
                        ContractorID = Guid.NewGuid()
                        
                    },

                    new Contractor
                    {
                        Description = "Groundhogs, LLC (Contractor)",
                        ContractorName = "Groundhogs, LLC",
                        ContractorID = Guid.NewGuid()
                    }
                };

                crs.ForEach(s => context.Contractors.AddOrUpdate(p => p.ContractorID, s));
                context.SaveChanges();


                //Consultants List
                var cns = new List<Consultant>
                {
                    new Consultant
                    {
                        Description = "Stantec Consulting Services, Inc. (Consultant)",
                        ConsultantName = "Stantec Consulting Services, Inc.",
                        ConsultantID = Guid.NewGuid()
                    },

                    new Consultant
                    {
                        Description = "Stutzman Engineering Associates, Inc. (Consultant)",
                        ConsultantName = "Stutzman Engineering Associates, Inc.",
                        ConsultantID = Guid.NewGuid()
                    }
                };

                cns.ForEach(s => context.Consultants.AddOrUpdate(p => p.ConsultantID, s));
                context.SaveChanges();

                //Secretarys List
                var scs = new List<Secretary>
                {
                    new Secretary
                    {
                        FirstName = "April",
                        LastName = "Newman",
                        SecretaryID = Guid.NewGuid()
                    },
                    new Secretary
                    {
                        FirstName = "Suzn",
                        LastName = "Hanson",
                        SecretaryID = Guid.NewGuid()
                    }
                };


                scs.ForEach(s => context.Secretaries.AddOrUpdate(p => p.SecretaryID, s));
                context.SaveChanges();



                //Architect Engineer List

                var erl = new List<ArchitectEngineer>
                {

                    new ArchitectEngineer
                    {
                        FirstName = "Dave",
                        LastName = "Vanairsdale",
                        ArchitectEngineerID = Guid.NewGuid()
                    },


                    new ArchitectEngineer
                    {
                        FirstName = "Janet",
                        LastName = "Smith",
                        ArchitectEngineerID = Guid.NewGuid()
                    }
                };

                erl.ForEach(s => context.ArchitectEngineers.AddOrUpdate(p => p.ArchitectEngineerID, s));
                context.SaveChanges();


                //ProjectManager List

                var pml = new List<ProjectManager>
                {
                    new ProjectManager
                    {

                        FirstName = "Benjamin",
                        LastName = "Loeffler",
                        ProjectManagerID = Guid.NewGuid()
                    },

                    new ProjectManager
                    {

                        FirstName = "Dan",
                        LastName = "Sloan",
                        ProjectManagerID = Guid.NewGuid()
                    }
                };

                pml.ForEach(s => context.ProjectManagers.AddOrUpdate(p => p.ProjectManagerID, s));
                context.SaveChanges();

                //ProjectType List

                var ptl = new List<ProjectType>
                {
                    new ProjectType
                    {
                        Name = "Unassigned",
                        Description = "Currently Unassigned",
                        ProjectTypeID = Guid.NewGuid()
                    },

                    new ProjectType
                    {
                        Name =  "Schools",
                        Description = "Project related to all schools",
                        ProjectTypeID = Guid.NewGuid()
                    },

                    new ProjectType
                    {
                        Name = "Parks and Recreation",
                        Description = "Parks and Recreation Capital Projects"
                    }
                };

                ptl.ForEach(s => context.ProjectTypes.AddOrUpdate(p => p.ProjectTypeID, s));
                context.SaveChanges();


                var pul = new List<ProjectUser>
                {
                    new ProjectUser
                    {
                        FirstName = "Melissa",
                        LastName = "Harter",
                        ProjectUserID = Guid.NewGuid()
                    },

                    new ProjectUser
                    {
                        FirstName = "Dan",
                        LastName = "Sloan",
                        ProjectUserID = Guid.NewGuid()
                    },

                    new ProjectUser
                    {
                        FirstName = "Mary Ellen",
                        LastName = "Baker",
                        ProjectUserID = Guid.NewGuid()
                    }
                };

                pul.ForEach(s => context.Users.AddOrUpdate(p => p.ProjectUserID, s));
                context.SaveChanges();




                var cps = new List<CapitalProject>
                {
                    new CapitalProject()
                    {
                        CapitalProjectID = Guid.NewGuid(),
                        ProjectNumber = "17-BHSPRJ-1",
                        ProjectName = "Birch Hill Fuel Dispensing Station",
                        ActiveDate = new DateTime(2017,12,11,0,0,0),
                        ProjectStatus = true,
                        PercentDesignComplete = 100,
                        ContractorID = crs[0].ContractorID,
                        ConsultantID = cns[0].ConsultantID,
                        ProjectManagerID = pml[0].ProjectManagerID,
                        ArchitectEngineerID = erl[0].ArchitectEngineerID,
                        SecretaryID = scs[0].SecretaryID,
                        ProjectUserID = pul[0].ProjectUserID,
                        ProjectTypeID = ptl[2].ProjectTypeID,
                        StatusDescription = @"Project issued for bid on January 22, 2018.  Bid date February 6, 2018."
                    },

                    new CapitalProject()
                    {
                        CapitalProjectID = Guid.NewGuid(),
                        ProjectNumber = "17-PRGPRJ-1",
                        ProjectName = "Ballfield Dugout Replacement Phase I",
                        ActiveDate = new DateTime(2017,12,06,0,0,0),
                        ProjectStatus = true,
                        PercentDesignComplete = 0,
                        ContractorID = crs[1].ContractorID,
                        ConsultantID = cns[1].ConsultantID,
                        ProjectManagerID = pml[1].ProjectManagerID,
                        ArchitectEngineerID = erl[1].ArchitectEngineerID,
                        SecretaryID = scs[1].SecretaryID,
                        ProjectUserID = pul[1].ProjectUserID,
                        ProjectTypeID = ptl[2].ProjectTypeID,
                        StatusDescription = @"Project setup in progress.",
                        ProjectScope = @"Replace failing roofs at ball fields"
                    },

                    new CapitalProject()
                    {
                        CapitalProjectID = Guid.NewGuid(),
                        ProjectNumber = "17-PRGPRJ-3",
                        ProjectName = "Parks Fencing Repairs/Replacement Phase 1",
                        ActiveDate = new DateTime(2017,12,06,0,0,0),
                        ProjectStatus = true,
                        PercentDesignComplete = 0,
                        ContractorID = crs[0].ContractorID,
                        ConsultantID = cns[0].ConsultantID,
                        ProjectManagerID = pml[0].ProjectManagerID,
                        ArchitectEngineerID = erl[0].ArchitectEngineerID,
                        SecretaryID = scs[0].SecretaryID,
                        ProjectUserID = pul[0].ProjectUserID,
                        ProjectTypeID = ptl[2].ProjectTypeID,
                        StatusDescription = @"Project will be completed through Parks & Recreation Dept.",
                        ProjectScope = "Repair/Replace fencing throughout park facilities"

                    },

                    new CapitalProject()
                    {
                        CapitalProjectID = Guid.NewGuid(),
                        ProjectNumber = "17-RVBPRJ-1",
                        ProjectName = "River Boat Nenana Structural Investigation",
                        ActiveDate = new DateTime(2017,12,06,0,0,0),
                        ProjectStatus = true,
                        PercentDesignComplete = 0,
                        ContractorID = crs[1].ContractorID,
                        ConsultantID = cns[1].ConsultantID,
                        ProjectManagerID = pml[1].ProjectManagerID,
                        ArchitectEngineerID = erl[1].ArchitectEngineerID,
                        SecretaryID = scs[1].SecretaryID,
                        ProjectUserID = pul[1].ProjectUserID,
                        ProjectTypeID = ptl[2].ProjectTypeID,
                        StatusDescription = string.Empty,
                        ProjectScope = @"This project will investigate and report whether the existing structure meets 
                                            the requirements of the current occupancy classification."
                    }
                };

                cps.ForEach(s => context.CapitalProjects.AddOrUpdate(p => p.CapitalProjectID, s));
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
    }
}
