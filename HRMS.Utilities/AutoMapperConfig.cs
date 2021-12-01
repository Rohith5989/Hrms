using AutoMapper;
using HRMS.Models;
using HRMS.Models.NewFolder;
using HRMS.Repository.Models;
using HRMS.Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace HRMS.Utilities
{
    public class AutoMapperConfig:Profile

    {
        public AutoMapperConfig()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<EmpDetailsVM, EmpSPVM>().ReverseMap();
            CreateMap<GetEmpByNameVM, EmpByNameSPVM>().ReverseMap();
        }
    }
}
