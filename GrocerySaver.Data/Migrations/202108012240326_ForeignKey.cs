namespace GrocerySaver.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllGroceries",
                c => new
                    {
                        GroceryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.GroceryId);
            
            CreateTable(
                "dbo.Beverage",
                c => new
                    {
                        BeverageId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        ShelfLifeInDays = c.Int(nullable: false),
                        AmountInOunces = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        GroceryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeverageId)
                .ForeignKey("dbo.AllGroceries", t => t.GroceryId, cascadeDelete: true)
                .Index(t => t.GroceryId);
            
            CreateTable(
                "dbo.Dairy",
                c => new
                    {
                        DairyId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        ShelfLifeInDays = c.Int(nullable: false),
                        AmountInOunces = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        GroceryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DairyId)
                .ForeignKey("dbo.AllGroceries", t => t.GroceryId, cascadeDelete: true)
                .Index(t => t.GroceryId);
            
            CreateTable(
                "dbo.Fruit",
                c => new
                    {
                        FruitId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        ShelfLifeInDays = c.Int(nullable: false),
                        AmountInOunces = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        GroceryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FruitId)
                .ForeignKey("dbo.AllGroceries", t => t.GroceryId, cascadeDelete: true)
                .Index(t => t.GroceryId);
            
            CreateTable(
                "dbo.Meat",
                c => new
                    {
                        MeatId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        ShelfLifeInDays = c.Int(nullable: false),
                        AmountInOunces = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        GroceryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MeatId)
                .ForeignKey("dbo.AllGroceries", t => t.GroceryId, cascadeDelete: true)
                .Index(t => t.GroceryId);
            
            CreateTable(
                "dbo.Vegetable",
                c => new
                    {
                        VegetableId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        ShelfLifeInDays = c.Int(nullable: false),
                        AmountInOunces = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        GroceryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VegetableId)
                .ForeignKey("dbo.AllGroceries", t => t.GroceryId, cascadeDelete: true)
                .Index(t => t.GroceryId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Vegetable", "GroceryId", "dbo.AllGroceries");
            DropForeignKey("dbo.Meat", "GroceryId", "dbo.AllGroceries");
            DropForeignKey("dbo.Fruit", "GroceryId", "dbo.AllGroceries");
            DropForeignKey("dbo.Dairy", "GroceryId", "dbo.AllGroceries");
            DropForeignKey("dbo.Beverage", "GroceryId", "dbo.AllGroceries");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Vegetable", new[] { "GroceryId" });
            DropIndex("dbo.Meat", new[] { "GroceryId" });
            DropIndex("dbo.Fruit", new[] { "GroceryId" });
            DropIndex("dbo.Dairy", new[] { "GroceryId" });
            DropIndex("dbo.Beverage", new[] { "GroceryId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Vegetable");
            DropTable("dbo.Meat");
            DropTable("dbo.Fruit");
            DropTable("dbo.Dairy");
            DropTable("dbo.Beverage");
            DropTable("dbo.AllGroceries");
        }
    }
}
