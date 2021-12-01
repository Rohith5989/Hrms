using HRMS.Business.Interfaces;
using HRMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentBusiness _departmentBusiness;
        public DepartmentController(IDepartmentBusiness departmentBusiness)
        {
            _departmentBusiness = departmentBusiness;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var Departments =await   _departmentBusiness.GetAllDepartments();
            return Ok(Departments);
        }
        [HttpPost]
        public async Task<IActionResult> PostDepartments(DepartmentViewModel depts)
        {
            var result =await _departmentBusiness.PostDepartments(depts);
            return Ok(result);
        }
        [HttpGet("GetDepartmentById")]
            public async Task< IActionResult> GetDepartmentById(int id)
        {
            var result =await _departmentBusiness.GetDepartmentById(id);
            return Ok(result);
        }
       

    }
}
