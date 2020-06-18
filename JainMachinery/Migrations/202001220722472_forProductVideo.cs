namespace JainMachinery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forProductVideo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductVideos",
                c => new
                    {
                        VideoID = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Video = c.String(),
                        UploadedDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.VideoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductVideos");
        }
    }
}
