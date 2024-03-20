namespace TwoFactorAuthenticator.Models.Model
{
    public class TokenModel
    {
        public string IdUser { get; set; }
        public string IdToken { get; set; }
        public string TokenName { get; set; }
        public int Value { get; set; }
    }
}
