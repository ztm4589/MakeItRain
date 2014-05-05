namespace MakeItRain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CalendarEvent", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChatLog", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.StockTransaction", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.CalendarEvent", new[] { "ApplicationUserID" });
            DropIndex("dbo.ChatLog", new[] { "ApplicationUserID" });
            DropIndex("dbo.StockTransaction", new[] { "ApplicationUserID" });
            AddColumn("dbo.CalendarEvent", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.ChatLog", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.StockTransaction", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.CalendarEvent", "ApplicationUserID", c => c.String());
            AlterColumn("dbo.ChatLog", "ApplicationUserID", c => c.String());
            AlterColumn("dbo.StockTransaction", "ApplicationUserID", c => c.String());
            CreateIndex("dbo.CalendarEvent", "User_Id");
            CreateIndex("dbo.ChatLog", "User_Id");
            CreateIndex("dbo.StockTransaction", "User_Id");
            AddForeignKey("dbo.CalendarEvent", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ChatLog", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.StockTransaction", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockTransaction", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChatLog", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CalendarEvent", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.StockTransaction", new[] { "User_Id" });
            DropIndex("dbo.ChatLog", new[] { "User_Id" });
            DropIndex("dbo.CalendarEvent", new[] { "User_Id" });
            AlterColumn("dbo.StockTransaction", "ApplicationUserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.ChatLog", "ApplicationUserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.CalendarEvent", "ApplicationUserID", c => c.String(maxLength: 128));
            DropColumn("dbo.StockTransaction", "User_Id");
            DropColumn("dbo.ChatLog", "User_Id");
            DropColumn("dbo.CalendarEvent", "User_Id");
            CreateIndex("dbo.StockTransaction", "ApplicationUserID");
            CreateIndex("dbo.ChatLog", "ApplicationUserID");
            CreateIndex("dbo.CalendarEvent", "ApplicationUserID");
            AddForeignKey("dbo.StockTransaction", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ChatLog", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CalendarEvent", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
    }
}
