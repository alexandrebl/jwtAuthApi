using System;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using jwtAuthApi.BusinessCore.Interfaces;
using jwtAuthApi.Domain;
using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Repository.Interfaces;

namespace jwtAuthApi.BusinessCore
{
    public sealed class TokenBusinessCore : ITokenBusinessCore
    {
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly IRepository<User> _repository;

        public TokenBusinessCore(TokenConfiguration tokenConfiguration, IRepository<User> repository)
        {
            _tokenConfiguration = tokenConfiguration;
            _repository = repository;
        }

        public string GenerateToken(User user)
        {
            var token = CreateToken(user, _tokenConfiguration);

            return token;
        }

        public bool Validate(string userName, string token, out string message)
        {
            try
            {
                var user = GetUser(userName);

                if(user == null)
                {
                    message = "User not found";
                    return false;
                }

                var json = new JwtBuilder()
                    .WithSecret(user.SercretKey)
                    .MustVerifySignature()
                    .Decode(token);

                message = "Token is valid";

                return true;
            }
            catch (TokenExpiredException)
            {
                message = "Token has expired";

                return false;
            }
            catch (SignatureVerificationException)
            {
                message = "Token has invalid signature";

                return false;
            }
            catch (Exception exception)
            {
                message = exception.Message;

                return false;
            }
        }

        public string RefreshToken(string userName)
        {
            var user = GetUser(userName);
            var token = GenerateToken(user);

            return token;
        }

        private User GetUser(string userName)
        {
            var user = _repository.GetByKey(userName);

            return user;
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
