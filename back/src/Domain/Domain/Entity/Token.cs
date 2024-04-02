namespace TwoFactorAuthenticator.Models.Entity
{
    public class Token 
    {
        public Token(string tokenName, string value)
        {
            Name = tokenName;
            Value = value;
        }

        public string Name { get;protected set; }
        public string Value { get;protected set; }
    }
}
