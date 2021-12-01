using System;
using System.Collections.Generic;
using System.Text;

namespace HRMS.Repository.ViewModel
{
   public class EmpDetailsVM
    {
        public string DeptName { get; set; }
        public string DeptLocation { get; set; }
        public int? EmpId { get; set; }
      
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }
    }
}
