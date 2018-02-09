using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Publicworks.Entities;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Entities.Admin;
using Publicworks.Entities.Agents;
using Publicworks.Entities.Funds;
using Publicworks.Entities.Projects;

namespace Publicworks.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("ApplicationDbContext")
        {

        }

        
        public DbSet<CapitalProject> CapitalProjects { get; set; }
        public DbSet<Entities.Projects.ProjectType> ProjectTypes { get; set; }
        public DbSet<GeneralLedgerKey> GeneralLedgetKeys { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<ArchitectEngineer> ArchitectEngineers { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<ProjectUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }


    }
}
