using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MakeItRain.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Navigation Properties
        public virtual ICollection<StockTransaction> StockTransactions { get; set; }
        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }
        public virtual ICollection<ChatLog> ChatLogs { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }
        //public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<ChatLog> ChatLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}