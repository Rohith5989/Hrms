using HRMS.Repository.Models;
using HRMS.Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository.Interfaces
{
   public interface IEmployeeRepository
    {
       Task<IList<Employee>> GetAllEmployees();

      Task  <Employee> PostEmployees(Employee emps);

      Task  <Employee> getEmployeeById(int id);

      Task<IList<EmpDetailsVM>> GetEmpDetails(int? deptid);

      Task< IList<GetEmpByNameVM>> GetEmpByName();
    }
}
