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
   public class AccountsBusiness : IAccountsBusiness
    {
        private readonly IAccountsRepository _accountsRepository;
        public AccountsBusiness(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async  Task<string> LoginUser(LoginViewModel model)
        {
            AppUser user = null;
            user = await _accountsRepository.GetByUserName(model.UserName);
            if(user == null)
            {
                user = await _accountsRepository.GetByEmail(model.UserName);
            }
            if(user == null)
            {
                user = await _accountsRepository.GetByPhoneNumber(model.UserName);
            }
            if (user == null)
                return "Invalid UserName";
            else
                return await _accountsRepository.ValidatePassword(user, model.Password);
        }

        public async Task<string> Register(UserViewModel model)
        {

            AppUser User = new AppUser()
            {
                 UserName = model.UserName,
                 Email =model.Email,
                 PhoneNumber = model.PhoneNumber

            };
            var result = await _accountsRepository.Register(User, model.Password, "Admin");
            return result;

        }

        public async Task<Dictionary<int, string>> SendOTP(string mobile)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            var user = await _accountsRepository.GetByPhoneNumber(mobile);
            if (user == null)
                result.Add(1, "invalid mobile number");
            else
            {
                var OTP = await _accountsRepository.SendOTP(user);
                result.Add(2, OTP.ToString());
            }
            return result;
        }

        public async Task<string> VerifyOTP(VerifyOTPViewModel model)
        {
            var user = await _accountsRepository.GetByPhoneNumber(model.PhoneNumber);
            var result = await _accountsRepository.VerifyOTP(user,model.OTP);
            if (result)
            {
                return " Otp validated success";
            }
            else
                return "invalid otp";
        }
    }
}
