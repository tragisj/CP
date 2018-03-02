namespace Publicworks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitPro3 : DbMigration
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
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ArchitectEngineerID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Guid(nullable: false),
                        ProjectNumber = c.String(nullable: false, maxLength: 20),
                        ProjectName = c.String(nullable: false, maxLength: 128),
                        StatusDescription = c.String(maxLength: 1000),
                        ProjectScope = c.String(maxLength: 4000),
                        ActiveProject = c.Boolean(nullable: false),
                        CompletedProject = c.Boolean(nullable: false),
                        Activated = c.DateTime(nullable: false),
                        Inactived = c.DateTime(),
                        AgendaSetting = c.DateTime(),
                        AssemblyApproval = c.DateTime(),
                        AdvertiseForBid = c.DateTime(),
                        OriginalBidDate = c.DateTime(),
                        BidOpening = c.DateTime(),
                        ConsultantBidAward = c.DateTime(),
                        ConstructionBidAward = c.DateTime(),
                        DesignCompleted = c.DateTime(),
                        NoticeToProceed = c.DateTime(),
                        SubstantialCompletion = c.DateTime(),
                        FinalInspection = c.DateTime(),
                        WarrantyPeriodEnds = c.DateTime(),
                        ClosedDate = c.DateTime(),
                        ContractAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContractAmendments = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChangeOrders = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConsultantFees = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PercentDesignComplete = c.Int(nullable: false),
                        PercentConstructionComplete = c.Int(nullable: false),
                        ContractorID = c.Guid(nullable: false),
                        ConsultantID = c.Guid(nullable: false),
                        SecretaryID = c.Guid(nullable: false),
                        ArchitectEngineerID = c.Guid(nullable: false),
                        ProjectManagerID = c.Guid(nullable: false),
                        ProjectTypeID = c.Guid(nullable: false),
                        ProjectUserID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
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
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultantID);
            
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        ContractorID = c.Guid(nullable: false),
                        ContractorName = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 255),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContractorID);
            
            CreateTable(
                "dbo.GeneralLedgerKeys",
                c => new
                    {
                        GeneralLedgerKeyID = c.Guid(nullable: false),
                        GLKey = c.String(nullable: false),
                        FinanceImportDate = c.DateTime(nullable: false),
                        ActiveKey = c.Boolean(nullable: false),
                        ProjectID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.GeneralLedgerKeyID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectManagers",
                c => new
                    {
                        ProjectManagerID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectManagerID);
            
            CreateTable(
                "dbo.ProjectTypes",
                c => new
                    {
                        ProjectTypeID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 128),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectTypeID);
            
            CreateTable(
                "dbo.ProjectUsers",
                c => new
                    {
                        ProjectUserID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Department = c.String(maxLength: 50),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectUserID);
            
            CreateTable(
                "dbo.Secretaries",
                c => new
                    {
                        SecretaryID = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SecretaryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "SecretaryID", "dbo.Secretaries");
            DropForeignKey("dbo.Projects", "ProjectUserID", "dbo.ProjectUsers");
            DropForeignKey("dbo.Projects", "ProjectTypeID", "dbo.ProjectTypes");
            DropForeignKey("dbo.Projects", "ProjectManagerID", "dbo.ProjectManagers");
            DropForeignKey("dbo.GeneralLedgerKeys", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ContractorID", "dbo.Contractors");
            DropForeignKey("dbo.Projects", "ConsultantID", "dbo.Consultants");
            DropForeignKey("dbo.Projects", "ArchitectEngineerID", "dbo.ArchitectEngineers");
            DropIndex("dbo.GeneralLedgerKeys", new[] { "ProjectID" });
            DropIndex("dbo.Projects", new[] { "ProjectUserID" });
            DropIndex("dbo.Projects", new[] { "ProjectTypeID" });
            DropIndex("dbo.Projects", new[] { "ProjectManagerID" });
            DropIndex("dbo.Projects", new[] { "ArchitectEngineerID" });
            DropIndex("dbo.Projects", new[] { "SecretaryID" });
            DropIndex("dbo.Projects", new[] { "ConsultantID" });
            DropIndex("dbo.Projects", new[] { "ContractorID" });
            DropTable("dbo.Secretaries");
            DropTable("dbo.ProjectUsers");
            DropTable("dbo.ProjectTypes");
            DropTable("dbo.ProjectManagers");
            DropTable("dbo.GeneralLedgerKeys");
            DropTable("dbo.Contractors");
            DropTable("dbo.Consultants");
            DropTable("dbo.Projects");
            DropTable("dbo.ArchitectEngineers");
        }
    }
}
