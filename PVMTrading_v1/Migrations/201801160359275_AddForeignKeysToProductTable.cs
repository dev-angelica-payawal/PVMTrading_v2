namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeysToProductTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "ProductCondition_Id", "dbo.ProductConditions");
            DropIndex("dbo.Products", new[] { "Branch_Id" });
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            DropIndex("dbo.Products", new[] { "ProductCategory_Id" });
            DropIndex("dbo.Products", new[] { "ProductCondition_Id" });
            RenameColumn(table: "dbo.Products", name: "Branch_Id", newName: "BranchId");
            RenameColumn(table: "dbo.Products", name: "Brand_Id", newName: "BrandId");
            RenameColumn(table: "dbo.Products", name: "ProductCategory_Id", newName: "ProductCategoryId");
            RenameColumn(table: "dbo.Products", name: "ProductCondition_Id", newName: "ProductConditionId");
            AlterColumn("dbo.Products", "BranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BrandId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductConditionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "BrandId");
            CreateIndex("dbo.Products", "ProductCategoryId");
            CreateIndex("dbo.Products", "ProductConditionId");
            CreateIndex("dbo.Products", "BranchId");
            AddForeignKey("dbo.Products", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ProductConditionId", "dbo.ProductConditions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductConditionId", "dbo.ProductConditions");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Products", "BranchId", "dbo.Branches");
            DropIndex("dbo.Products", new[] { "BranchId" });
            DropIndex("dbo.Products", new[] { "ProductConditionId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            AlterColumn("dbo.Products", "ProductConditionId", c => c.Int());
            AlterColumn("dbo.Products", "ProductCategoryId", c => c.Int());
            AlterColumn("dbo.Products", "BrandId", c => c.Int());
            AlterColumn("dbo.Products", "BranchId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "ProductConditionId", newName: "ProductCondition_Id");
            RenameColumn(table: "dbo.Products", name: "ProductCategoryId", newName: "ProductCategory_Id");
            RenameColumn(table: "dbo.Products", name: "BrandId", newName: "Brand_Id");
            RenameColumn(table: "dbo.Products", name: "BranchId", newName: "Branch_Id");
            CreateIndex("dbo.Products", "ProductCondition_Id");
            CreateIndex("dbo.Products", "ProductCategory_Id");
            CreateIndex("dbo.Products", "Brand_Id");
            CreateIndex("dbo.Products", "Branch_Id");
            AddForeignKey("dbo.Products", "ProductCondition_Id", "dbo.ProductConditions", "Id");
            AddForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories", "Id");
            AddForeignKey("dbo.Products", "Brand_Id", "dbo.Brands", "Id");
            AddForeignKey("dbo.Products", "Branch_Id", "dbo.Branches", "Id");
        }
    }
}
