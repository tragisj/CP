namespace Publicworks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        CapitalProjectID = c.Guid(nullable: false),
                        ProjectNumber = c.String(nullable: false, maxLength: 20),
                        ProjectName = c.String(nullable: false, maxLength: 128),
                        ProjectStatus = c.Boolean(nullable: false),
                        StatusDescription = c.String(maxLength: 1000),
                        ProjectScope = c.String(maxLength: 4000),
                        ActiveDate = c.DateTime(nullable: false),
                        ClosedDate = c.DateTime(),
                        BidDate = c.DateTime(),
                        OriginalBidDate = c.DateTime(),
                        BidOpen = c.DateTime(),
                        ConstructionBidAward = c.DateTime(),
                        DesignComplete = c.DateTime(),
                        AgendaSetting = c.DateTime(),
                        PercentDesignComplete = c.Int(nullable: false),
                        ContractorID = c.Guid(nullable: false),
                        ConsultantID = c.Guid(nullable: false),
                        SecretaryID = c.Guid(nullable: false),
                        ArchitectEngineerID = c.Guid(nullable: false),
                        ProjectManagerID = c.Guid(nullable: false),
                        ProjectTypeID = c.Guid(nullable: false),
                        ProjectUserID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CapitalProjectID)
                .ForeignKey("dbo.ArchitectEngineers", t => t.ArchitectEngineerID, cascadeDelete: true)
                .ForeignKey("dbo.Consultants", t => t.ConsultantID, cascadeDelete: true)
                .ForeignKey("dbo.Contractors", t => t.ContractorID, cascadeDelete: true)
                .ForeignKey("dbo.ProjectManagers", t => t.ProjectManagerID, cascadeDelete: true)
                .ForeignKey("dbo.ProjectTypes", t => t.ProjectTypeID, cascadeDelete: true)
                .ForeignKey("dbo.ProjectUsers", t => t.ProjectUserID, cascadeDelete: true)
                .ForeignKey("dbo.Secretaries", t => t.SecretaryID, cascadeDelete: true)
                .Index(t => t.ContractorID)
                .Index(t => t.ConsultantID)
                .Index(t => t.SecretaryID)
                .Index(t => t.ArchitectEngineerID)
                .Index(t => t.ProjectManagerID)
                .Index(t => t.ProjectTypeID)
                .Index(t => t.ProjectUserID);
            
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
                "dbo.Secretaries",
                c => new
                    {
                        SecretaryID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.SecretaryID);
            
            CreateTable(
                "dbo.GeneralLedgerKeys",
                c => new
                    {
                        GeneralLedgerKeyID = c.Guid(nullable: false),
                        GLKey = c.String(nullable: false),
                        FinanceImportDate = c.DateTime(nullable: false),
                        Project_CapitalProjectID = c.Guid(),
                    })
                .PrimaryKey(t => t.GeneralLedgerKeyID)
                .ForeignKey("dbo.CapitalProjects", t => t.Project_CapitalProjectID)
                .Index(t => t.Project_CapitalProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralLedgerKeys", "Project_CapitalProjectID", "dbo.CapitalProjects");
            DropForeignKey("dbo.CapitalProjects", "SecretaryID", "dbo.Secretaries");
            DropForeignKey("dbo.CapitalProjects", "ProjectUserID", "dbo.ProjectUsers");
            DropForeignKey("dbo.CapitalProjects", "ProjectTypeID", "dbo.ProjectTypes");
            DropForeignKey("dbo.CapitalProjects", "ProjectManagerID", "dbo.ProjectManagers");
            DropForeignKey("dbo.CapitalProjects", "ContractorID", "dbo.Contractors");
            DropForeignKey("dbo.CapitalProjects", "ConsultantID", "dbo.Consultants");
            DropForeignKey("dbo.CapitalProjects", "ArchitectEngineerID", "dbo.ArchitectEngineers");
            DropIndex("dbo.GeneralLedgerKeys", new[] { "Project_CapitalProjectID" });
            DropIndex("dbo.CapitalProjects", new[] { "ProjectUserID" });
            DropIndex("dbo.CapitalProjects", new[] { "ProjectTypeID" });
            DropIndex("dbo.CapitalProjects", new[] { "ProjectManagerID" });
            DropIndex("dbo.CapitalProjects", new[] { "ArchitectEngineerID" });
            DropIndex("dbo.CapitalProjects", new[] { "SecretaryID" });
            DropIndex("dbo.CapitalProjects", new[] { "ConsultantID" });
            DropIndex("dbo.CapitalProjects", new[] { "ContractorID" });
            DropTable("dbo.GeneralLedgerKeys");
            DropTable("dbo.Secretaries");
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
