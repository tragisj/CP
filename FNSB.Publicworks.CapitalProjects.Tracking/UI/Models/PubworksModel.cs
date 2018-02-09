using System.Data.Entity;

namespace FNSB.PW.Projects.Web.Models
{
    public partial class PubworksModel : DbContext
    {
        public PubworksModel()
            : base("name=PubworksModel")
        {
        }

        public virtual DbSet<ArchitectEngineer> ArchitectEngineers { get; set; }
        public virtual DbSet<Consultant> Consultants { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<FundingType> FundingTypes { get; set; }
        public virtual DbSet<Fund> Funds { get; set; }
        public virtual DbSet<OneSolutionFinance> OneSolutionFinance { get; set; }
        public virtual DbSet<ProjectManager> ProjectManagers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
        public virtual DbSet<Secretary> Secretaries { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fund>()
                .Property(e => e.ppf_budget)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Fund>()
                .Property(e => e.ppf_expenditures)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Fund>()
                .Property(e => e.ppf_encumbrances)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Fund>()
                .Property(e => e.ppf_balance)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Project>()
                .Property(e => e.PPM_Consultant_Fee)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Project>()
                .Property(e => e.PPM_Contract_Amount)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Project>()
                .Property(e => e.PPM_Contract_Amendments)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Project>()
                .Property(e => e.PPM_CO)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Staff>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();
        }
    }
}
