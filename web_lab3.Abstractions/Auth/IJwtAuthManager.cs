using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Abstractions.Auth
{
    public interface IJwtAuthManager
    {
        JwtAuthResult GenerateTokens(string username, IList<Claim> claims, DateTime now);

        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }

    public class JwtAuthResult
    {
        public string AccessToken { get; set; }
    }
}