using jwtAuthApi.Domain.Entities;

namespace jwtAuthApi.BusinessCore.Interfaces
{
    public interface ITokenBusinessCore
    {
        string GenerateToken(User user);

        bool Validate(string userName, string token, out string message);

        string RefreshToken(string userName);
    }
}