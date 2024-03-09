using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class LeaveDataContext : DbContext
    {
        public LeaveDataContext(DbContextOptions option) : base(option)
        {
            

        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<LeaveRequestModel> LeaveRequests { get; set; }
        public DbSet<ManagerModel> Managers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>()
                .HasOne(mm => mm.Manager)
                .WithMany(dd => dd.Employees)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeModel>()
                .HasMany(ee => ee.LeaveRequests)
                .WithOne(ff => ff.Employee)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ManagerModel>()
                .HasMany(ll => ll.LeaveRequests)
                .WithOne(tt => tt.Manager)
                .OnDelete(DeleteBehavior.Restrict);

          
        }

        
    }
}