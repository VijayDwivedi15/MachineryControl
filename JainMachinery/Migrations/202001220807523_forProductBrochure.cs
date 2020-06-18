namespace JainMachinery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forProductBrochure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductBrochures",
                c => new
                    {
                        BrochureID = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Brochure = c.String(),
                        UploadedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BrochureID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductBrochures");
        }
    }
}
