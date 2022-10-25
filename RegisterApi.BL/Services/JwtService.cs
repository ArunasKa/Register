using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RegisterApi.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.BL.Services
{
    public class JwtService : IJWTService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetJwtToken(string userName, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , userName),
                new Claim(ClaimTypes.Role, role)
            };
            var secret = _configuration.GetSection("Jwt:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
