namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductAddSalesField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Sales", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Sales");
        }
    }
}
