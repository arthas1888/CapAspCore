using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class JwtSecurityTokenCustom : JwtSecurityToken
    {
        public JwtSecurityTokenCustom(string issuer = null, string audience = null, 
            IEnumerable<Claim> claims = null, DateTime? notBefore = null, 
            DateTime? expires = null, SigningCredentials signingCredentials = null,
            JArray role = null)
            : base(issuer, audience, claims, notBefore, expires, signingCredentials)
        {
            Role = role;
        }


        public JArray Role { get; set; }
    }
}
