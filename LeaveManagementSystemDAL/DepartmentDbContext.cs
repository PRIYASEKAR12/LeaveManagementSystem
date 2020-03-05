using LeaveManagementSystemEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace LeaveManagementSystemDAL
{
    public class DepartmentDbContext: DbContext
    {
        public DepartmentDbContext() : base("Department")
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}
