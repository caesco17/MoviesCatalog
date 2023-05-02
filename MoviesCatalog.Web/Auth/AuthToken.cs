using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Data;
using Microsoft.IdentityModel.Tokens;

namespace MoviesCatalog.Web.Auth
{
    public class AuthToken : IAuthToken
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthToken(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateToken(int UserId, string Role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var signingKey = Convert.FromBase64String(_configuration["AppSettings:Token"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,
                Audience = null,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.Now.AddDays(1),
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(RoleConstant.USER_CLAIM, UserId.ToString()),
                    new Claim(RoleConstant.ROLE_CLAIM, Role.ToString())
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(jwtToken);
        }
    }
}
