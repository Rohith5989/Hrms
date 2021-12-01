using HRMS.Models;
using HRMS.Models.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business.Interfaces
{
   public interface IEmployeeBusiness
    {
       Task< IList<EmployeeViewModel>> GetAllEmployees();

       Task< EmployeeViewModel> PostEmployees(EmployeeViewModel emps);

      Task< EmployeeViewModel> getEmployeeById( int id);

       Task< IList<EmpSPVM>> GetEmpDetails(int id);

      Task<IList<EmpByNameSPVM>> GetEmpByName();
    }
}
