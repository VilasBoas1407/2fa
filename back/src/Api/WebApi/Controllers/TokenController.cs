using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Model;
using TwoFactorAuthenticator.Models.Entity;
using TwoFactorAuthenticator.Models.Model;
using TwoFactorAuthenticator.Models.Services;
using TwoFactorAuthenticator.Models.Services.Redis;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ITokenService _tokenService;

        public TokenController(IMapper mapper, ITokenService tokenService)
        {
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] string userId)
        {
            var response = _tokenService.GetTokenByUser(userId);    
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TokenModel tokenModel)
        {
            var token = _mapper.Map<Token>(tokenModel);

            var response = _tokenService.CreateToken(token);

            return Ok(response);
        }
    }
}
