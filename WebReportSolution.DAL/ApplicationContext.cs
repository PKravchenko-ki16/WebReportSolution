using Microsoft.EntityFrameworkCore;
using WebReportSolution.Models.Orders;

namespace WebReportSolution.DAL
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-U4JR3LV;Database=OrdersDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().HasKey(u => u.Id);
            modelBuilder.Entity<Order>().HasData(FakeInitializerEntity.Init());
        }
    }
}