using System;
using System.Collections.Generic;
using System.Text;
using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Domain.ViewModel;

namespace jwtAuthApi.BusinessCore.Interfaces
{
    public interface ITokenBusinessCore
    {
        string GenerateToken(User user);
        bool Validate(string userName, string token, out string message);
        string RefreshToken(string userName);
    }
}
