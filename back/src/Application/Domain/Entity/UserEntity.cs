namespace TwoFactorAuthenticator.Models.Entity
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
    }
}
