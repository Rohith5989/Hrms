using HRMS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository.Interfaces
{
   public interface IDepartmentRepository
    {
      Task < IList<Department>> GetAllDepartments();

      Task <Department> PostDepartments(Department depts);

       Task<Department> GetDepartmentById(int id);

       
    }
}
