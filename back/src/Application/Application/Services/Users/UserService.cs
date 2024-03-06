using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Model;
using TwoFactorAuthenticator.Domain.Repository;
using TwoFactorAuthenticator.Models.Services;

namespace Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<User>> InsertAsync(User user)
        {
            var existUser = await _userRepository.ExistEmail(user.Email);

            if (existUser)
                return new ServiceResponse<User>(400, "Email já utilizado.");

            await _userRepository.InsertAsync(user);

            return new ServiceResponse<User>(200, "Usuário criado com sucesso.");
        }
    }
}