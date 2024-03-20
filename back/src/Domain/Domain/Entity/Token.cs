namespace TwoFactorAuthenticator.Models.Entity
{
    public class Token 
    {
        public Token(string idUser, string idToken, string tokenName, int value)
        {
            IdUser = idUser;
            IdToken = idToken;
            TokenName = tokenName;
            Value = value;
        }

        public string IdUser { get; protected set; }
        public string IdToken { get;protected set; }
        public string TokenName { get;protected set; }
        public int Value { get;protected set; }
    }
}
