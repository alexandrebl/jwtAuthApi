using System;
using JWT.Algorithms;
using JWT.Builder;
using jwtAuthApi.BusinessCore.Interfaces;
using jwtAuthApi.Domain;
using jwtAuthApi.Domain.Entities;

namespace jwtAuthApi.BusinessCore
{
    public sealed class TokenBusinessCore : ITokenBusinessCore
    {
        private readonly TokenConfiguration _tokenConfiguration;
        public TokenBusinessCore(TokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
        }

        public string GenerateToken(User user)
        {
            var token = CreateToken(user, _tokenConfiguration);

            return token;
        }

        private static string CreateToken(User user, TokenConfiguration tokenConfiguration)
        {
            var token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(user.SercretKey)
                .AddClaim("exp", DateTimeOffset.UtcNow
                    .AddSeconds(tokenConfiguration.ExpirationInSeconds).ToUnixTimeSeconds())
                .AddClaim("sub", user.UserName)
                .AddClaim("iss", tokenConfiguration.Issuer)
                .AddClaim("aud", tokenConfiguration.Audience)
                .Build();

            return token;
        }
    }
}
