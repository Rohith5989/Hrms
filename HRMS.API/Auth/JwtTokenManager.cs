using HRMS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Auth
{
    public class JwtTokenManager : IJwtTokenManager
    {
        public Task<string> GenertaeToken(AppUser user, string role)
        {
            throw new NotImplementedException();
        }
    }
}
