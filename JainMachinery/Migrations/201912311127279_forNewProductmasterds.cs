namespace JainMachinery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forNewProductmasterds : DbMigration
    {
        public override void Up()
        {
            
            
            CreateTable(
                "dbo.ProductMasters",
                c => new
                    {
                        ProductID = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductImage = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.SubProductDetails",
                c => new
                    {
                        SubProductDetailID = c.Long(nullable: false, identity: true),
                        SubProductMainID = c.Long(nullable: false),
                        SubProductName = c.String(),
                        SubProductImage = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SubProductDetailID);
            
            CreateTable(
                "dbo.SubProductMains",
                c => new
                    {
                        SubProductMainID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubProductMainID);
            
          
        }
        
        public override void Down()
        {
            
            
            DropTable("dbo.SubProductMains");
            DropTable("dbo.SubProductDetails");
            DropTable("dbo.ProductMasters");
            
        }
    }
}
