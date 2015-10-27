namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAwardAndActivitiesTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CoverUrl = c.String(),
                        BeginTime = c.DateTimeOffset(nullable: false, precision: 7),
                        EndTime = c.DateTimeOffset(nullable: false, precision: 7),
                        Count = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CreateTime = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifyTime = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CoverUrl = c.String(),
                        Quantity = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CreateTime = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifyTime = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AwardActivities",
                c => new
                    {
                        Award_Id = c.String(nullable: false, maxLength: 128),
                        Activity_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Award_Id, t.Activity_Id })
                .ForeignKey("dbo.Awards", t => t.Award_Id, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_Id, cascadeDelete: true)
                .Index(t => t.Award_Id)
                .Index(t => t.Activity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AwardActivities", "Activity_Id", "dbo.Activities");
            DropForeignKey("dbo.AwardActivities", "Award_Id", "dbo.Awards");
            DropIndex("dbo.AwardActivities", new[] { "Activity_Id" });
            DropIndex("dbo.AwardActivities", new[] { "Award_Id" });
            DropTable("dbo.AwardActivities");
            DropTable("dbo.Awards");
            DropTable("dbo.Activities");
        }
    }
}
