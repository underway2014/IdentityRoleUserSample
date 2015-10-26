namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProductAddCoverUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CoverUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "CoverUrl");
        }
    }
}
