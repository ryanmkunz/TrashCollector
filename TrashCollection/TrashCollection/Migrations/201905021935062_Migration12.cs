namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "WeeklyPickupDay", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "OneTimePickupDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "OneTimePickupDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "WeeklyPickupDay", c => c.String());
        }
    }
}
