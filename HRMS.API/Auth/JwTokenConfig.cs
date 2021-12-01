using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Auth
{
    public class JwTokenConfig
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string AccessTokenExpiration { get; set; }
        public string RefreshTokenExpiration { get; set; }
    }
}
