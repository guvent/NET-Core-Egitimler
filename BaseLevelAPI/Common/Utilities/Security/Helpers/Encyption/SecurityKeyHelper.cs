using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Common.Utilities.Security.Helpers.Encyption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(String securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
