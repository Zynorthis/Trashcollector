namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDaysAddPickupsAddressAndStates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Days", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Days", new[] { "Customer_ID" });
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Address1 = c.Int(nullable: false),
                        Address2 = c.Int(nullable: false),
                        Zipcode = c.Int(nullable: false),
                        StateRefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.States", t => t.StateRefID, cascadeDelete: true)
                .Index(t => t.StateRefID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        State = c.String(),
                        StateAbbrivation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PickupDay = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        CompletionDate = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Customers", "AddressRefID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "PickupRefID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "AddressRefID");
            CreateIndex("dbo.Customers", "PickupRefID");
            AddForeignKey("dbo.Customers", "AddressRefID", "dbo.Addresses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "PickupRefID", "dbo.Pickups", "ID", cascadeDelete: true);
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "Zipcode");
            DropColumn("dbo.Customers", "DaysID");
            DropTable("dbo.Days");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        IsWeekDay = c.Boolean(nullable: false),
                        Customer_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Customers", "DaysID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Zipcode", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Address", c => c.String());
            DropForeignKey("dbo.Customers", "PickupRefID", "dbo.Pickups");
            DropForeignKey("dbo.Customers", "AddressRefID", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "StateRefID", "dbo.States");
            DropIndex("dbo.Addresses", new[] { "StateRefID" });
            DropIndex("dbo.Customers", new[] { "PickupRefID" });
            DropIndex("dbo.Customers", new[] { "AddressRefID" });
            DropColumn("dbo.Customers", "PickupRefID");
            DropColumn("dbo.Customers", "AddressRefID");
            DropTable("dbo.Pickups");
            DropTable("dbo.States");
            DropTable("dbo.Addresses");
            CreateIndex("dbo.Days", "Customer_ID");
            AddForeignKey("dbo.Days", "Customer_ID", "dbo.Customers", "ID");
        }
    }
}
