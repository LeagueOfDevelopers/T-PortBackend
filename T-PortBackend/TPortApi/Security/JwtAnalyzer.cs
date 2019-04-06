using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TPortApi.Security
{
    public static class JwtAnalyzer
    {
        public static Guid GetUserId(this HttpRequest request)
        {
            var token = request.Headers["Authorization"].ToString();

            var handler = new JwtSecurityTokenHandler();
            var userId =
                Guid.Parse(handler.ReadJwtToken(token.Substring(7)).Claims.First(c => c.Type == "userId").Value);
            return userId;
        }
    }
}