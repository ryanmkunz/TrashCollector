namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migraton9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "OneTimePickupDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "TempStopStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "TempStopEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "TempStopEnd", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "TempStopStart", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "OneTimePickupDay", c => c.Int(nullable: false));
        }
    }
}
