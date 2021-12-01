using HRMS.Repository.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMS.Repository.Models
{
    public partial class MyContext : HrmsDBContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<HrmsDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<EmpDetailsVM> EmpDetails { get; set; }
        public virtual DbSet<GetEmpByNameVM> GetEmpByNames { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmpDetailsVM>().HasNoKey();
            modelBuilder.Entity<GetEmpByNameVM>().HasNoKey();
        }
        
        
        



         
    }
}
