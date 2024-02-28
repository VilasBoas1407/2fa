using Microsoft.AspNetCore.Mvc;
using TwoFactorAuthenticator.Models.Entity;
using TwoFactorAuthenticator.Models.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Service _booksService;

        public AuthController(Service booksService) =>
            _booksService = booksService;

        [HttpPost]
        public IActionResult Post(UserModel user)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<List<UserEntity>> Get() =>
            await _booksService.GetAsync();
    }
}
