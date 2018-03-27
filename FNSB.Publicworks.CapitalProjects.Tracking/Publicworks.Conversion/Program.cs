using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Conversion.Conversions;
using Publicworks.Entities.Admin;
using Publicworks.Entities.Agents;
using Publicworks.Entities.Projects;

namespace Publicworks.Conversion
{
    class Program
    {
        static void Main(string[] args)
        {



            var ac = new AdminConversion();


            //List<AgencyAdminPerson> arclist = ac.GetArchitectFirstLast();
            //List<AgencyAdminPerson> pmlist = ac.GetProjectMgrFirstLast();
            //List<AgencyAdminPerson> seclist = ac.GetSecretaryFirstLast();
            //List<AgencyAdminPerson> userlist = ac.GetUserFirstLast();
            //List<AgencyName> consultantlist = ac.GetConsultantName();
            //List<AgencyName> contractorlist = ac.GetContractorName();
            //List<AgencyName> protypelist = ac.GetProjectTypeName();



            //using (var context = new Data.Context.ApplicationDbContext())
            //{


            //    //Contractor List
            //    var crs = new List<Contractor>();
            //    {
            //        foreach (var x in contractorlist)
            //        {
            //            var c = new Contractor
            //            {
            //                ContractorName = x.Name,
            //                ContractorID = Guid.NewGuid(),
            //                Active = false
            //            };
            //            crs.Add(c);
            //        }
            //    }
                

            //    crs.ForEach(s => context.Contractors.AddOrUpdate(p => p.ContractorID, s));
            //    context.SaveChanges();


            //    var cns = new List<Consultant>();
            //    {
            //        foreach (var x in consultantlist)
            //        {
            //            var c = new Consultant()
            //            {
            //                ConsultantName = x.Name,
            //                ConsultantID = Guid.NewGuid(),
            //                Active = false
            //            };
            //            cns.Add(c);
            //        }
            //    }


            //    cns.ForEach(s => context.Consultants.AddOrUpdate(p => p.ConsultantID, s));
            //    context.SaveChanges();

            //    //Secretary List
            //    var scs = new List<Secretary>();
            //    {
            //        foreach (var x in seclist)
            //        {
            //            var c = new Secretary()
            //            {
            //                FirstName = x.First,
            //                LastName = x.Last,
            //                SecretaryID = Guid.NewGuid(),
            //                Active = false
            //            };
            //            scs.Add(c);
            //        }
            //    }


            //    scs.ForEach(s => context.Secretaries.AddOrUpdate(p => p.SecretaryID, s));
            //    context.SaveChanges();



            //    //Architect Engineer List
            //    var erl = new List<ArchitectEngineer>();
            //    {
            //        foreach (var x in arclist)
            //        {
            //            var c = new ArchitectEngineer()
            //            {
            //                FirstName = x.First,
            //                LastName = x.Last,
            //                ArchitectEngineerID = Guid.NewGuid(),
            //                Active = false
            //            };
            //            erl.Add(c);
            //        }
            //    }


            //    erl.ForEach(s => context.ArchitectEngineers.AddOrUpdate(p => p.ArchitectEngineerID, s));
            //    context.SaveChanges();


            //    //ProjectManager List
            //    var pml = new List<ProjectManager>();
            //    {
            //        foreach (var x in pmlist)
            //        {
            //            var c = new ProjectManager()
            //            {
            //                FirstName = x.First,
            //                LastName = x.Last,
            //                ProjectManagerID = Guid.NewGuid(),
            //                Active = false
            //            };
            //            pml.Add(c);
            //        }
            //    }


            //    pml.ForEach(s => context.ProjectManagers.AddOrUpdate(p => p.ProjectManagerID, s));
            //    context.SaveChanges();

            //    //ProjectType List

            //    var ptl = new List<ProjectType>();
            //    {
            //        foreach (var x in protypelist)
            //        {
            //            var c = new ProjectType()
            //            {
            //                Name = x.Name,
            //                ProjectTypeID = Guid.NewGuid(),
            //                Active = false
            //            };
            //            ptl.Add(c);
            //        }
            //    }


            //    ptl.ForEach(s => context.ProjectTypes.AddOrUpdate(p => p.ProjectTypeID, s));
            //    context.SaveChanges();



            //    var pul = new List<ProjectUser>();
            //    {
            //        foreach (var x in userlist)
            //        {
            //            var c = new ProjectUser()
            //            {
            //                FirstName = x.First,
            //                LastName = x.Last,
            //                ProjectUserID = Guid.NewGuid(),
            //                Active = false
            //            };
            //            pul.Add(c);
            //        }
            //    }

            //    pul.ForEach(s => context.Users.AddOrUpdate(p => p.ProjectUserID, s));
            //    context.SaveChanges();
            //}


            var pc = new ProjectConversion();
            List<ProjectConversion.ProjectData> corelist = pc.GetProjectCore();
            pc.MigrateProjects(corelist);


            var pf = new FundConversion();
            List<ProjectFundKey> fundslist = pf.GetProjectConnectedFunds();
            pc.MigrateGlKeys(fundslist);

        }
    }
}
