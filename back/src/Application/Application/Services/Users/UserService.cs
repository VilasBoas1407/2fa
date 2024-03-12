using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Repository;
using TwoFactorAuthenticator.Models.Response;
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

        public async Task<Response<User>> InsertAsync(User user)
        {
            var existUser = await _userRepository.ExistEmail(user.Email);

            if (existUser)
                return new Response<User>(400, "Email já utilizado.");

            await _userRepository.InsertAsync(user);

            return new Response<User>(200, "Usuário criado com sucesso.");
        }
    }
}