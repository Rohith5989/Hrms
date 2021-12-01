using HRMS.Repository.Interfaces;
using HRMS.Repository.Models;
using HRMS.Repository.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
   public class EmployeeRepository  : IEmployeeRepository

    {
        private readonly MyContext _myContext;
        public EmployeeRepository(MyContext myContext)
        {
            _myContext = myContext; 
        }

        public async Task< IList<Employee>> GetAllEmployees()
        {
            return await _myContext.Employees.ToListAsync();
        }

        public async Task< IList<GetEmpByNameVM>> GetEmpByName()

        {
            IList<GetEmpByNameVM> list =await _myContext.GetEmpByNames.FromSqlRaw("usp_GetEmpByName").ToListAsync();
            return list;
             
        }

        public async Task< IList<EmpDetailsVM>> GetEmpDetails(int? deptid)
        {
            IList<EmpDetailsVM> list =await _myContext.EmpDetails.FromSqlRaw("exec usp_EmpDetails {0}", deptid).ToListAsync();
            return list;
            throw new NotImplementedException();
        }

        public async Task< Employee> getEmployeeById(int id)
        {
            var result =await _myContext.Employees.FindAsync(id);
            return result;
            throw new NotImplementedException();
        }

        public async Task< Employee> PostEmployees(Employee emps)
        {
            var result =await _myContext.Employees.AddAsync(emps);
           await _myContext.SaveChangesAsync();
            return result.Entity;

            throw new NotImplementedException();
        }
    }
}
