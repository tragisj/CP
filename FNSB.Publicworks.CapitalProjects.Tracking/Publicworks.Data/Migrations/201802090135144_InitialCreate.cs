namespace Publicworks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArchitectEngineers",
                c => new
                    {
                        ArchitectEngineerID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ArchitectEngineerID);
            
            CreateTable(
                "dbo.CapitalProjects",
                c => new
                    {
                        ProjectID = c.Guid(nullable: false),
                        ProjectNumber = c.String(nullable: false, maxLength: 20),
                        ProjectName = c.String(nullable: false, maxLength: 128),
                        ProjectStatus = c.Boolean(nullable: false),
                        StatusDescription = c.String(maxLength: 1000),
                        ProjectScope = c.String(maxLength: 4000),
                        ActiveDate = c.DateTime(nullable: false),
                        ClosedDate = c.DateTime(nullable: false),
                        ArchitectEngineer_ArchitectEngineerID = c.Guid(),
                        Consultant_ConsultantID = c.Guid(),
                        Contractor_ContractorID = c.Guid(),
                        ProjectManager_ProjectManagerID = c.Guid(),
                        ProjectType_ProjectTypeID = c.Guid(),
                        ProjectUser_ProjectUserID = c.Guid(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.ArchitectEngineers", t => t.ArchitectEngineer_ArchitectEngineerID)
                .ForeignKey("dbo.Consultants", t => t.Consultant_ConsultantID)
                .ForeignKey("dbo.Contractors", t => t.Contractor_ContractorID)
                .ForeignKey("dbo.ProjectManagers", t => t.ProjectManager_ProjectManagerID)
                .ForeignKey("dbo.ProjectTypes", t => t.ProjectType_ProjectTypeID)
                .ForeignKey("dbo.ProjectUsers", t => t.ProjectUser_ProjectUserID)
                .Index(t => t.ArchitectEngineer_ArchitectEngineerID)
                .Index(t => t.Consultant_ConsultantID)
                .Index(t => t.Contractor_ContractorID)
                .Index(t => t.ProjectManager_ProjectManagerID)
                .Index(t => t.ProjectType_ProjectTypeID)
                .Index(t => t.ProjectUser_ProjectUserID);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        ConsultantID = c.Guid(nullable: false),
                        ConsultantName = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ConsultantID);
            
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        ContractorID = c.Guid(nullable: false),
                        ContractorName = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ContractorID);
            
            CreateTable(
                "dbo.ProjectManagers",
                c => new
                    {
                        ProjectManagerID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ProjectManagerID);
            
            CreateTable(
                "dbo.ProjectTypes",
                c => new
                    {
                        ProjectTypeID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProjectTypeID);
            
            CreateTable(
                "dbo.ProjectUsers",
                c => new
                    {
                        ProjectUserID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ProjectUserID);
            
            CreateTable(
                "dbo.GeneralLedgerKeys",
                c => new
                    {
                        GeneralLedgerKeyID = c.Guid(nullable: false),
                        GLKey = c.String(nullable: false),
                        FinanceImportDate = c.DateTime(nullable: false),
                        ProjectID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.GeneralLedgerKeyID)
                .ForeignKey("dbo.CapitalProjects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Secretaries",
                c => new
                    {
                        SecretaryID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.SecretaryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralLedgerKeys", "ProjectID", "dbo.CapitalProjects");
            DropForeignKey("dbo.CapitalProjects", "ProjectUser_ProjectUserID", "dbo.ProjectUsers");
            DropForeignKey("dbo.CapitalProjects", "ProjectType_ProjectTypeID", "dbo.ProjectTypes");
            DropForeignKey("dbo.CapitalProjects", "ProjectManager_ProjectManagerID", "dbo.ProjectManagers");
            DropForeignKey("dbo.CapitalProjects", "Contractor_ContractorID", "dbo.Contractors");
            DropForeignKey("dbo.CapitalProjects", "Consultant_ConsultantID", "dbo.Consultants");
            DropForeignKey("dbo.CapitalProjects", "ArchitectEngineer_ArchitectEngineerID", "dbo.ArchitectEngineers");
            DropIndex("dbo.GeneralLedgerKeys", new[] { "ProjectID" });
            DropIndex("dbo.CapitalProjects", new[] { "ProjectUser_ProjectUserID" });
            DropIndex("dbo.CapitalProjects", new[] { "ProjectType_ProjectTypeID" });
            DropIndex("dbo.CapitalProjects", new[] { "ProjectManager_ProjectManagerID" });
            DropIndex("dbo.CapitalProjects", new[] { "Contractor_ContractorID" });
            DropIndex("dbo.CapitalProjects", new[] { "Consultant_ConsultantID" });
            DropIndex("dbo.CapitalProjects", new[] { "ArchitectEngineer_ArchitectEngineerID" });
            DropTable("dbo.Secretaries");
            DropTable("dbo.GeneralLedgerKeys");
            DropTable("dbo.ProjectUsers");
            DropTable("dbo.ProjectTypes");
            DropTable("dbo.ProjectManagers");
            DropTable("dbo.Contractors");
            DropTable("dbo.Consultants");
            DropTable("dbo.CapitalProjects");
            DropTable("dbo.ArchitectEngineers");
        }
    }
}
