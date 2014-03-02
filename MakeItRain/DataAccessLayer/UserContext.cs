using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakeItRain.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MakeItRain.DataAccessLayer
{
    /*
    public class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
        {

        }
        //public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<ChatLog> ChatLogs { get; set; }
        public DbSet<UserLogger> UserLogger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
     * */
}