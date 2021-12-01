using HRMS.Repository.Interfaces;
using HRMS.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MyContext _myContext;
        public DepartmentRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<IList<Department>> GetAllDepartments()
        {
            return await _myContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var result = await _myContext.Departments.FindAsync(id);
            return result;
            throw new NotImplementedException();
        }

       
        public  async Task<Department> PostDepartments(Department depts)
        {
            var result =await _myContext.Departments.AddAsync(depts);
            await _myContext.SaveChangesAsync();
            return result.Entity;
            throw new NotImplementedException();
        }
    }
}
