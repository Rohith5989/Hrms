using AutoMapper;
using HRMS.Business.Interfaces;
using HRMS.Models;
using HRMS.Repository.Interfaces;
using HRMS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business
{
    public class DepartmentBusiness : IDepartmentBusiness
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentBusiness(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;

        }
        public async Task<IList<DepartmentViewModel>> GetAllDepartments()
        {
            var departments =await _departmentRepository.GetAllDepartments();
            return  _mapper.Map<IList<DepartmentViewModel>>(departments);    
        }

        public async Task<DepartmentViewModel> GetDepartmentById(int id)
        {
            var result =await _departmentRepository.GetDepartmentById(id);
            return _mapper.Map<DepartmentViewModel>(result);
            throw new NotImplementedException();
        }

      

        public async Task< DepartmentViewModel> PostDepartments(DepartmentViewModel depts)
        {
            var result =await _departmentRepository.PostDepartments(_mapper.Map<Department>(depts));
            return _mapper.Map<DepartmentViewModel>(result);
            throw new NotImplementedException();
        }
    }
}
