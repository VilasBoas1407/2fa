using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Model;
using TwoFactorAuthenticator.Domain.Repository;
using TwoFactorAuthenticator.Models.Services;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<User>> InsertAsync(User user)
        {
            var existUser = await _userRepository.ExistEmail(user.Email);

            if (existUser)
                return new ServiceResponse<User>(400, "E-mail já cadastrado");

            return null;
        }

    }
}