using System;
using System.Collections.Generic;

#nullable disable

namespace HRMS.Repository.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }
    }
}
