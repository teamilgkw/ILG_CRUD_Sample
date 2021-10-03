using ILG_CRUD_Sample.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILG_CRUD_Sample.DataAccess.Models
{
    public class ILG_CRUD_SampleContext : DbContext
    {
        public ILG_CRUD_SampleContext(DbContextOptions<ILG_CRUD_SampleContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        //public DbSet<EmployeeTask> EmployeeTasks { get; set; }
    }
}
