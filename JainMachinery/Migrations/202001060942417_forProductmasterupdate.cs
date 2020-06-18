namespace JainMachinery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forProductmasterupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductMasters", "ProductDetail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductMasters", "ProductDetail");
        }
    }
}
