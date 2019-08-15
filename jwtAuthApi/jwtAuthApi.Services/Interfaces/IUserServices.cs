using System;
using System.Collections.Generic;
using System.Text;
using jwtAuthApi.Domain.Entities;

namespace jwtAuthApi.Services.Interfaces
{
    public interface IUserServices
    {
        bool Auth(User user);
    }
}
