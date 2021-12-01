using System;
using System.Collections.Generic;
using System.Text;

namespace HRMS.Models
{
  public  class EmployeeViewModel
    {
        public int? EmpId { get; set; }
        public int DeptId { get; set; }
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }
    }
}
