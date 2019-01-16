namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBTablesUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pickups", "EmployeeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pickups", "EmployeeName");
        }
    }
}
