using StackExchange.Redis;
using System;
using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Repository;
using TwoFactorAuthenticator.Infra.Redis.Factory;
using TwoFactorAuthenticator.Models.Factory;
using TwoFactorAuthenticator.Models.Response;
using TwoFactorAuthenticator.Models.Services;

namespace Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRedisConnectionFactory _redisConnection;


        public UserService(IUserRepository userRepository, IRedisConnectionFactory redisConnection)
        {
            _userRepository = userRepository;
            _redisConnection = redisConnection;
        }

        public async Task<Response<User>> InsertAsync(User user)
        {
            var existUser = await _userRepository.ExistEmail(user.Email);

            if (existUser)
                return new Response<User>(400, "Email já utilizado.");

            await _userRepository.InsertAsync(user);

            return new Response<User>(200, "Usuário criado com sucesso.");
        }

        public async Task<string> InsertKey(string key)
        {
            var redis = _redisConnection.Connection;
            IDatabase db = redis.GetDatabase();
            db.StringSet("chave", key);

            string valor =  db.StringGet("chave");
            return valor;
        }
    }
}