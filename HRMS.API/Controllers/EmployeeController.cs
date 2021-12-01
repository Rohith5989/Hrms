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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;
        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;    
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees =await _employeeBusiness.GetAllEmployees();
            return Ok(employees);
        }
        [HttpPost]
        public async Task< IActionResult> PostEmployees(EmployeeViewModel emps)
        {
            var result =await _employeeBusiness.PostEmployees(emps);
            return Ok(result);
        }
        [HttpGet("GetElementById")]
        public async Task<IActionResult> GetElementById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result =await _employeeBusiness.getEmployeeById(id);
            return Ok(result);
        }
        [HttpGet("GetEmployees")]

        public async Task<IActionResult> GetEmpDetails(int deptid)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result =await _employeeBusiness.GetEmpDetails(deptid);
            return Ok(result);

        }
        [HttpGet("GetEmpByName")]
        public async Task<IActionResult> GetEmpByName()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result =await _employeeBusiness.GetEmpByName();
            return Ok(result);
        }
        
    }
}
