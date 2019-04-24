namespace MicroPOS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductGroups", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ProductGroupId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        PriceWithVat = c.Double(nullable: false),
                        VatRate = c.Double(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupId)
                .Index(t => t.ProductGroupId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.ProductId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductGroupId", "dbo.ProductGroups");
            DropForeignKey("dbo.ProductGroups", "ParentId", "dbo.ProductGroups");
            DropIndex("dbo.Stocks", new[] { "StoreId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ProductGroupId" });
            DropIndex("dbo.ProductGroups", new[] { "ParentId" });
            DropTable("dbo.Stores");
            DropTable("dbo.Stocks");
            DropTable("dbo.Products");
            DropTable("dbo.ProductGroups");
        }
    }
}
