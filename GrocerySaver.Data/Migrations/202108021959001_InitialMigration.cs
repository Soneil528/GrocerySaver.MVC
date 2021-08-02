namespace GrocerySaver.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dairy", "GroceryId", "dbo.AllGroceries");
            DropForeignKey("dbo.Fruit", "GroceryId", "dbo.AllGroceries");
            DropForeignKey("dbo.Meat", "GroceryId", "dbo.AllGroceries");
            DropForeignKey("dbo.Vegetable", "GroceryId", "dbo.AllGroceries");
            DropIndex("dbo.Dairy", new[] { "GroceryId" });
            DropIndex("dbo.Fruit", new[] { "GroceryId" });
            DropIndex("dbo.Meat", new[] { "GroceryId" });
            DropIndex("dbo.Vegetable", new[] { "GroceryId" });
            AddColumn("dbo.AllGroceries", "DairyId", c => c.Int(nullable: false));
            AddColumn("dbo.AllGroceries", "FruitId", c => c.Int(nullable: false));
            AddColumn("dbo.AllGroceries", "MeatId", c => c.Int(nullable: false));
            AddColumn("dbo.AllGroceries", "VegetableId", c => c.Int(nullable: false));
            CreateIndex("dbo.AllGroceries", "DairyId");
            CreateIndex("dbo.AllGroceries", "FruitId");
            CreateIndex("dbo.AllGroceries", "MeatId");
            CreateIndex("dbo.AllGroceries", "VegetableId");
            AddForeignKey("dbo.AllGroceries", "DairyId", "dbo.Dairy", "DairyId", cascadeDelete: true);
            AddForeignKey("dbo.AllGroceries", "FruitId", "dbo.Fruit", "FruitId", cascadeDelete: true);
            AddForeignKey("dbo.AllGroceries", "MeatId", "dbo.Meat", "MeatId", cascadeDelete: true);
            AddForeignKey("dbo.AllGroceries", "VegetableId", "dbo.Vegetable", "VegetableId", cascadeDelete: true);
            DropColumn("dbo.Dairy", "GroceryId");
            DropColumn("dbo.Fruit", "GroceryId");
            DropColumn("dbo.Meat", "GroceryId");
            DropColumn("dbo.Vegetable", "GroceryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vegetable", "GroceryId", c => c.Int(nullable: false));
            AddColumn("dbo.Meat", "GroceryId", c => c.Int(nullable: false));
            AddColumn("dbo.Fruit", "GroceryId", c => c.Int(nullable: false));
            AddColumn("dbo.Dairy", "GroceryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AllGroceries", "VegetableId", "dbo.Vegetable");
            DropForeignKey("dbo.AllGroceries", "MeatId", "dbo.Meat");
            DropForeignKey("dbo.AllGroceries", "FruitId", "dbo.Fruit");
            DropForeignKey("dbo.AllGroceries", "DairyId", "dbo.Dairy");
            DropIndex("dbo.AllGroceries", new[] { "VegetableId" });
            DropIndex("dbo.AllGroceries", new[] { "MeatId" });
            DropIndex("dbo.AllGroceries", new[] { "FruitId" });
            DropIndex("dbo.AllGroceries", new[] { "DairyId" });
            DropColumn("dbo.AllGroceries", "VegetableId");
            DropColumn("dbo.AllGroceries", "MeatId");
            DropColumn("dbo.AllGroceries", "FruitId");
            DropColumn("dbo.AllGroceries", "DairyId");
            CreateIndex("dbo.Vegetable", "GroceryId");
            CreateIndex("dbo.Meat", "GroceryId");
            CreateIndex("dbo.Fruit", "GroceryId");
            CreateIndex("dbo.Dairy", "GroceryId");
            AddForeignKey("dbo.Vegetable", "GroceryId", "dbo.AllGroceries", "GroceryId", cascadeDelete: true);
            AddForeignKey("dbo.Meat", "GroceryId", "dbo.AllGroceries", "GroceryId", cascadeDelete: true);
            AddForeignKey("dbo.Fruit", "GroceryId", "dbo.AllGroceries", "GroceryId", cascadeDelete: true);
            AddForeignKey("dbo.Dairy", "GroceryId", "dbo.AllGroceries", "GroceryId", cascadeDelete: true);
        }
    }
}
