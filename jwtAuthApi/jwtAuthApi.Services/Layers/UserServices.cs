using System;
using System.Collections.Generic;
using System.Text;
using jwtAuthApi.BusinessCore.Interfaces;
using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Services.Interfaces;

namespace jwtAuthApi.Services.Layers
{
    public sealed class UserServices: IUserServices
    {
        private readonly IAuthBusinessCore _authBusinessCore;
        public UserServices(IAuthBusinessCore authBusinessCore)
        {
            _authBusinessCore = authBusinessCore;
        }

        public bool Auth(User user)
        {
            var result = _authBusinessCore.Auth(user);

            return result;
        }
    }
}
