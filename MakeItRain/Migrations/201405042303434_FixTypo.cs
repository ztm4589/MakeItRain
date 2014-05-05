namespace MakeItRain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTypo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CalendarEvent", name: "User_Id", newName: "UserID");
            RenameColumn(table: "dbo.ChatLog", name: "User_Id", newName: "UserID");
            RenameColumn(table: "dbo.StockTransaction", name: "User_Id", newName: "UserID");
            DropColumn("dbo.CalendarEvent", "ApplicationUserID");
            DropColumn("dbo.ChatLog", "ApplicationUserID");
            DropColumn("dbo.StockTransaction", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockTransaction", "ApplicationUserID", c => c.String());
            AddColumn("dbo.ChatLog", "ApplicationUserID", c => c.String());
            AddColumn("dbo.CalendarEvent", "ApplicationUserID", c => c.String());
            RenameColumn(table: "dbo.StockTransaction", name: "UserID", newName: "User_Id");
            RenameColumn(table: "dbo.ChatLog", name: "UserID", newName: "User_Id");
            RenameColumn(table: "dbo.CalendarEvent", name: "UserID", newName: "User_Id");
        }
    }
}
