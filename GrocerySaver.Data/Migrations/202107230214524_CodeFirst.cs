namespace GrocerySaver.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirst : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Vegetable");
            AddColumn("dbo.Vegetable", "VegetableId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Vegetable", "VegetableId");
            DropColumn("dbo.Vegetable", "DairyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vegetable", "DairyId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Vegetable");
            DropColumn("dbo.Vegetable", "VegetableId");
            AddPrimaryKey("dbo.Vegetable", "DairyId");
        }
    }
}
