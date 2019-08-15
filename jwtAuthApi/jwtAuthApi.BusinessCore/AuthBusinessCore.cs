using System.Runtime.CompilerServices;
using jwtAuthApi.BusinessCore.Interfaces;
using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Domain.ViewModel;
using jwtAuthApi.Repository.Interfaces;

namespace jwtAuthApi.BusinessCore
{
    public sealed class AuthBusinessCore : IAuthBusinessCore
    {
        private readonly IRepository<User> _repository;

        public AuthBusinessCore(IRepository<User> repository)
        {
            _repository = repository;
        }

        public User Auth(UserModel userModel)
        {
            var user = GetUser(userModel.UserName);

            return !Validate(user, userModel) ? null : user;
        }

        private User GetUser(string userName)
        {
            var user = _repository.GetByKey(userName);

            return user;
        }

        private static bool Validate(User user, UserModel userModel)
        {
            if (user == null) return false;
            return user.Password != userModel.Password;
        }
    }
}