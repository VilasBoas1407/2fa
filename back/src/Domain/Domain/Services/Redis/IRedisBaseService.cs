namespace TwoFactorAuthenticator.Models.Services.Redis
{
    public interface IRedisBaseService
    {
        public T GetData<T>(string key);
        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime);
    }
}
