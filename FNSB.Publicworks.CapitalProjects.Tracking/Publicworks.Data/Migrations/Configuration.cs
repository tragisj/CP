using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Globalization;
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
                var crs = new List<Contractor>
                {
                    new Contractor
                    {
                        Description = "Flintstones",
                        ContractorName = "Flintstones Enterprise",
                        ContractorID = Guid.NewGuid()

                    }
                };

                crs.ForEach(s => context.Contractors.AddOrUpdate(p => p.ContractorID, s));
                context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
