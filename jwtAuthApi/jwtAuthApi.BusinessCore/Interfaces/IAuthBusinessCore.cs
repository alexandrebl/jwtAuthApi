using System;
using System.Collections.Generic;
using System.Text;
using jwtAuthApi.Domain.Entities;

namespace jwtAuthApi.BusinessCore.Interfaces
{
    public interface IAuthBusinessCore
    {
        bool Auth(User user);
    }
}
