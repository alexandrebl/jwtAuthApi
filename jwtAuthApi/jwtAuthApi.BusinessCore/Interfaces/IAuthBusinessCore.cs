using jwtAuthApi.Domain.Entities;

namespace jwtAuthApi.BusinessCore.Interfaces
{
    public interface IAuthBusinessCore
    {
        bool Auth(User user);
    }
}