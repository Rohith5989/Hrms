using HRMS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository.Interfaces
{
  public  interface IAccountsRepository
    {
         Task<string> Register(AppUser user,string Password, string Role);

        Task<AppUser> GetByEmail(string Email);

        Task<AppUser> GetByUserName(string UserName);

        Task<AppUser> GetByPhoneNumber(string PhoneNumber);

        Task<string?> ValidatePassword(AppUser user ,string Password);

        Task<string> SendOTP(AppUser user);

        Task<bool> VerifyOTP(AppUser user, string OTP);
    }
}
