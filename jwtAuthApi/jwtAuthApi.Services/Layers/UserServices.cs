using System;
using System.Collections.Generic;
using System.Text;
using jwtAuthApi.BusinessCore.Interfaces;
using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Domain.ViewModel;
using jwtAuthApi.Services.Interfaces;

namespace jwtAuthApi.Services.Layers
{
    public sealed class UserServices: IUserServices
    {
        private readonly IAuthBusinessCore _authBusinessCore;
        private readonly ITokenBusinessCore _tokenBusinessCore;
        public UserServices(IAuthBusinessCore authBusinessCore, ITokenBusinessCore tokenBusinessCore)
        {
            _authBusinessCore = authBusinessCore;
            _tokenBusinessCore = tokenBusinessCore;
        }

        public string Auth(UserModel userModel)
        {
            var user = _authBusinessCore.Auth(userModel);

            if (user == null) return null;

            var token = _tokenBusinessCore.GenerateToken(user);

            return token;
        }
    }
}
