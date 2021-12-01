using AutoMapper;
using HRMS.Business.Interfaces;
using HRMS.Models;
using HRMS.Models.NewFolder;
using HRMS.Repository.Interfaces;
using HRMS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business
{
  public  class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeBusiness(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IList<EmployeeViewModel>> GetAllEmployees()
        {
            var employees =await _employeeRepository.GetAllEmployees();
            return _mapper.Map<IList<EmployeeViewModel>>(employees);
           // IList<EmployeeViewModel> result = new List<EmployeeViewModel>();

           // EmployeeViewModel employee;

            //foreach(Employee emp in employees)
            //{
            //    employee = new EmployeeViewModel()
            //    {
            //        EmpId = emp.EmpId,
            //        EmpName = emp.EmpName,
            //        EmpSalary = emp.EmpSalary,
            //        DeptId= emp.DeptId
            //    };
            //    result.Add(employee);
            //}
            //return result;

        }

        public async Task< IList<EmpByNameSPVM>> GetEmpByName()
        {
            var result =await _employeeRepository.GetEmpByName();
            return _mapper.Map<IList<EmpByNameSPVM>>(result);
            throw new NotImplementedException();
        }

        public async Task< IList<EmpSPVM>> GetEmpDetails(int id)
        {
            var result =await _employeeRepository.GetEmpDetails(id);
            return _mapper.Map<IList<EmpSPVM>>(result);
            throw new NotImplementedException();
        }

        public async Task< EmployeeViewModel> getEmployeeById(int id)
        {
            var result =await _employeeRepository.getEmployeeById(id);
            return _mapper.Map<EmployeeViewModel>(result);



            throw new NotImplementedException();
        }

        public async Task<EmployeeViewModel> PostEmployees(EmployeeViewModel emps)
        {
            var result =await _employeeRepository.PostEmployees(_mapper.Map<Employee>(emps));
            return _mapper.Map<EmployeeViewModel>(result);
            throw new NotImplementedException();
        }

       
    }
}
