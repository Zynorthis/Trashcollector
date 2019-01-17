namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBTaleUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AspNetUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "AspNetUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "AspNetUserID");
            CreateIndex("dbo.Employees", "AspNetUserID");
            AddForeignKey("dbo.Customers", "AspNetUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "AspNetUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "AspNetUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "AspNetUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "AspNetUserID" });
            DropIndex("dbo.Customers", new[] { "AspNetUserID" });
            DropColumn("dbo.Employees", "AspNetUserID");
            DropColumn("dbo.Customers", "AspNetUserID");
        }
    }
}
