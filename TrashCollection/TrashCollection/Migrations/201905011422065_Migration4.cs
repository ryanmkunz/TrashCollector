namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Street");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "State", c => c.String());
            AddColumn("dbo.Employees", "City", c => c.String());
            AddColumn("dbo.Employees", "Street", c => c.String());
        }
    }
}
