using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Publicworks.Entities;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Data.Configurations;
using Publicworks.Entities.Admin;
using Publicworks.Entities.Agents;
using Publicworks.Entities.Funds;
using Publicworks.Entities.Projects;
using Publicworks.Finance.OneSolution.Entities;

namespace Publicworks.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("ApplicationDbContext")
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Entities.Projects.ProjectType> ProjectTypes { get; set; }
        public DbSet<GeneralLedgerKey> GeneralLedgerKeys { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<ArchitectEngineer> ArchitectEngineers { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<ProjectUser> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ActualsViewConfiguration());
        }
    }
}
