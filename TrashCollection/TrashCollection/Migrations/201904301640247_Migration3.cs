namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Employees", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropIndex("dbo.Employees", new[] { "AddressId" });
            AddColumn("dbo.Customers", "Street", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "State", c => c.String());
            AddColumn("dbo.Customers", "Zip", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Street", c => c.String());
            AddColumn("dbo.Employees", "City", c => c.String());
            AddColumn("dbo.Employees", "State", c => c.String());
            AddColumn("dbo.Employees", "Zip", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "AddressId");
            DropColumn("dbo.Employees", "AddressId");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "AddressId", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Zip");
            DropColumn("dbo.Employees", "State");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "Street");
            DropColumn("dbo.Customers", "Zip");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Street");
            CreateIndex("dbo.Employees", "AddressId");
            CreateIndex("dbo.Customers", "AddressId");
            AddForeignKey("dbo.Employees", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
