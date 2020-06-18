using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 3, DepartmentName = "Accounting" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 4, DepartmentName = "Sales" });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Ayman",
                LastName = "Shabana",
                Email = "ayman_shabana@outlook.com",
                DateOfBrith = new DateTime(1998, 3, 3),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/ayman.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Mamdouh",
                LastName = "Farag",
                Email = "mamdouh@farag.com",
                DateOfBrith = new DateTime(1951, 12, 22),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/mamdouh.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Ghassan",
                LastName = "Matar",
                Email = "e3mel@elsa7.com",
                DateOfBrith = new DateTime(1949, 11, 11),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/ghassan.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Ahmed",
                LastName = "El Sakka",
                Email = "elrogoola@elgad3ana.com",
                DateOfBrith = new DateTime(1982, 9, 23),
                Gender = Gender.Male,
                DepartmentId = 3,
                PhotoPath = "images/sakka.jpg"
            });
        }
    }
}
