using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace TPortApi.Security
{
    public class JwtIssuer : IJwtIssuer
    {
        public JwtIssuer(SymmetricSecurityKey key, TimeSpan expirationPeriod)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key));
            _expirationPeriod = expirationPeriod;
        }

        public string IssueJwt(Guid userId)
        {
            var claims = new[]
            {
                new Claim("userId", userId.ToString())
            };
            
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.Add(_expirationPeriod),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        private readonly SymmetricSecurityKey _key;
        private readonly TimeSpan _expirationPeriod;
        
    }
}