using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Domain.ViewModel;

namespace jwtAuthApi.BusinessCore.Interfaces
{
    public interface IAuthBusinessCore
    {
        User Auth(UserModel userModel);
    }
}