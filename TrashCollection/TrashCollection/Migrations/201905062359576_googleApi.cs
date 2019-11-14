namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class googleApi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "FullAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "FullAddress");
        }
    }
}
