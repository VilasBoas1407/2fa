namespace TwoFactorAuthenticator.Domain.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
    }
}
