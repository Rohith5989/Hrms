using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business.Interfaces
{
  public  interface IAccountsBusiness
    {
        Task<string> Register(UserViewModel model);

        Task<string> LoginUser(LoginViewModel model);

        Task<Dictionary<int, string>> SendOTP(string mobile);

        Task<string> VerifyOTP(VerifyOTPViewModel model);
    }
}
