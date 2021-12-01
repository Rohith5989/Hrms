using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business.Interfaces
{
   public interface IDepartmentBusiness
    {
       Task< IList<DepartmentViewModel>> GetAllDepartments();

      Task<  DepartmentViewModel> PostDepartments(DepartmentViewModel depts);

      Task<  DepartmentViewModel> GetDepartmentById(int id);

       
    }
}
