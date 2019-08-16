using jwtAuthApi.Domain.ViewModel;

namespace jwtAuthApi.Services.Interfaces
{
    public interface IUserServices
    {
        string Auth(UserModel userModel);

        bool Validate(string userName, string token, out string message);

        string RefreshToken(string userName, string token, out string message);
    }
}