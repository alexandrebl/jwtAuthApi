using jwtAuthApi.BusinessCore.Interfaces;
using jwtAuthApi.Domain.Entities;
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

        public bool Auth(User user)
        {
            var userFromRepository = GetUser(user.UserName);

            return Validate(userFromRepository, user);
        }

        private User GetUser(string userName)
        {
            var user = _repository.GetByKey(userName);

            return user;
        }

        private static bool Validate(User userFromRepository, User user)
        {
            if (userFromRepository == null) return false;
            return userFromRepository.Password != user.Password;
        }
    }
}