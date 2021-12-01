using System;
using System.Collections.Generic;

#nullable disable

namespace HRMS.Repository.Models
{
    public partial class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptLocation { get; set; }
    }
}
