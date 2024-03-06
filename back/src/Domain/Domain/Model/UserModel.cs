using System.ComponentModel.DataAnnotations;

namespace TwoFactorAuthenticator.Domain.Model
{
    public class UserModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido.")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
