namespace Publicworks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBidSchedule : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CapitalProjects", "Consultant_ConsultantID", "dbo.Consultants");
            DropForeignKey("dbo.CapitalProjects", "Contractor_ContractorID", "dbo.Contractors");
            DropForeignKey("dbo.GeneralLedgerKeys", "ProjectID", "dbo.CapitalProjects");
            DropIndex("dbo.CapitalProjects", new[] { "Consultant_ConsultantID" });
            DropIndex("dbo.CapitalProjects", new[] { "Contractor_ContractorID" });
            DropIndex("dbo.GeneralLedgerKeys", new[] { "ProjectID" });
            RenameColumn(table: "dbo.GeneralLedgerKeys", name: "ProjectID", newName: "Project_ProjectID");
            CreateTable(
                "dbo.BidSchedules",
                c => new
                    {
                        BidScheduleID = c.Guid(nullable: false),
                        BidDate = c.DateTime(nullable: false),
                        OriginalBidDate = c.DateTime(nullable: false),
                        BidOpen = c.DateTime(nullable: false),
                        GeneralServicesReview = c.DateTime(nullable: false),
                        ConstructionBidAward = c.DateTime(nullable: false),
                        PercentDesignComplete = c.Int(nullable: false),
                        DesignComplete = c.DateTime(nullable: false),
                        AgendaSetting = c.DateTime(nullable: false),
                        GeneralLedgerKeyID = c.Guid(nullable: false),
                        Consultant_ConsultantID = c.Guid(),
                        Contractor_ContractorID = c.Guid(),
                    })
                .PrimaryKey(t => t.BidScheduleID)
                .ForeignKey("dbo.Consultants", t => t.Consultant_ConsultantID)
                .ForeignKey("dbo.Contractors", t => t.Contractor_ContractorID)
                .Index(t => t.Consultant_ConsultantID)
                .Index(t => t.Contractor_ContractorID);
            
            AddColumn("dbo.GeneralLedgerKeys", "BidSchedule_BidScheduleID", c => c.Guid());
            AlterColumn("dbo.GeneralLedgerKeys", "Project_ProjectID", c => c.Guid());
            CreateIndex("dbo.GeneralLedgerKeys", "BidSchedule_BidScheduleID");
            CreateIndex("dbo.GeneralLedgerKeys", "Project_ProjectID");
            AddForeignKey("dbo.GeneralLedgerKeys", "BidSchedule_BidScheduleID", "dbo.BidSchedules", "BidScheduleID");
            AddForeignKey("dbo.GeneralLedgerKeys", "Project_ProjectID", "dbo.CapitalProjects", "ProjectID");
            DropColumn("dbo.CapitalProjects", "Consultant_ConsultantID");
            DropColumn("dbo.CapitalProjects", "Contractor_ContractorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CapitalProjects", "Contractor_ContractorID", c => c.Guid());
            AddColumn("dbo.CapitalProjects", "Consultant_ConsultantID", c => c.Guid());
            DropForeignKey("dbo.GeneralLedgerKeys", "Project_ProjectID", "dbo.CapitalProjects");
            DropForeignKey("dbo.GeneralLedgerKeys", "BidSchedule_BidScheduleID", "dbo.BidSchedules");
            DropForeignKey("dbo.BidSchedules", "Contractor_ContractorID", "dbo.Contractors");
            DropForeignKey("dbo.BidSchedules", "Consultant_ConsultantID", "dbo.Consultants");
            DropIndex("dbo.GeneralLedgerKeys", new[] { "Project_ProjectID" });
            DropIndex("dbo.GeneralLedgerKeys", new[] { "BidSchedule_BidScheduleID" });
            DropIndex("dbo.BidSchedules", new[] { "Contractor_ContractorID" });
            DropIndex("dbo.BidSchedules", new[] { "Consultant_ConsultantID" });
            AlterColumn("dbo.GeneralLedgerKeys", "Project_ProjectID", c => c.Guid(nullable: false));
            DropColumn("dbo.GeneralLedgerKeys", "BidSchedule_BidScheduleID");
            DropTable("dbo.BidSchedules");
            RenameColumn(table: "dbo.GeneralLedgerKeys", name: "Project_ProjectID", newName: "ProjectID");
            CreateIndex("dbo.GeneralLedgerKeys", "ProjectID");
            CreateIndex("dbo.CapitalProjects", "Contractor_ContractorID");
            CreateIndex("dbo.CapitalProjects", "Consultant_ConsultantID");
            AddForeignKey("dbo.GeneralLedgerKeys", "ProjectID", "dbo.CapitalProjects", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.CapitalProjects", "Contractor_ContractorID", "dbo.Contractors", "ContractorID");
            AddForeignKey("dbo.CapitalProjects", "Consultant_ConsultantID", "dbo.Consultants", "ConsultantID");
        }
    }
}
