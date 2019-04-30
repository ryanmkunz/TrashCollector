namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "WeeklyPickupDay", c => c.String());
            AlterColumn("dbo.Customers", "Bill", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Bill", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "WeeklyPickupDay", c => c.Int(nullable: false));
        }
    }
}
