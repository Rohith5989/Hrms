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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsBusiness _accountsBusiness;
        public AccountsController(IAccountsBusiness accountsBusiness)
        {
            _accountsBusiness = accountsBusiness;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return  BadRequest(ModelState);
            }
            var result = await _accountsBusiness.Register(model);
            return Ok(result);
        }
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _accountsBusiness.LoginUser(model);
            return Ok(result);

        }
        [HttpGet("LoginOTP")]
        public async Task<IActionResult> LoginOTP(string mobile)
        {
            if(string.IsNullOrEmpty(mobile))
            {
                return BadRequest();
            }
            var result = await _accountsBusiness.SendOTP(mobile);
            if (result.Keys.FirstOrDefault() == 2) 
            return Ok(result.Values.FirstOrDefault());
            else
            
                return Ok(result.Values.FirstOrDefault());
            

        }


        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOTP(VerifyOTPViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _accountsBusiness.VerifyOTP(model);
            return Ok(result);
        }
    }
}
