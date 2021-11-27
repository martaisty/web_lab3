using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Abstractions.Auth
{
    public interface IJwtAuthManager
    {
        IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary { get; }

        JwtAuthResult GenerateTokens(string username, IList<Claim> claims, DateTime now);

        JwtAuthResult Refresh(string refreshToken, string accessToken, DateTime now);

        void RemoveExpiredRefreshTokens(DateTime now);

        void RemoveRefreshTokenByUserName(string userName);

        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }

    public class JwtAuthResult
    {
        public string AccessToken { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }

    public class RefreshToken
    {
        public string UserName { get; set; }

        public string TokenString { get; set; }

        public DateTime ExpireAt { get; set; }
    }
}