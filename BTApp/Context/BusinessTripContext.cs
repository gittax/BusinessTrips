using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BTApp.Models
{
    public class BusinessTripContext : DbContext
    {
         public BusinessTripContext(DbContextOptions<BusinessTripContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Request { get; set; }
        public DbSet<EmployeeBase> EmployeeBase { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Subproject> Subproject { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<EmployeeProjectAssign> ProjectAssignment { get; set; }
        public DbSet<EmployeeRouteAssign> RouteAssignment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>().ToTable("Request");
            modelBuilder.Entity<EmployeeBase>().ToTable("EmployeeBase");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Subproject>().ToTable("Subproject");
            modelBuilder.Entity<Route>().ToTable("Route");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<EmployeeRouteAssign>().ToTable("EmployeeRouteAssign");
            modelBuilder.Entity<EmployeeProjectAssign>().ToTable("EmployeeProjectAssign");

            modelBuilder.Entity<EmployeeProjectAssign>()
                .HasKey(c => new { c.EmployeeID, c.ProjectID });
            modelBuilder.Entity<EmployeeRouteAssign>()
                .HasKey(c => new { c.EmployeeID, c.RouteID });
        }
    }
}
