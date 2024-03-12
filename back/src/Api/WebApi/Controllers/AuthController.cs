using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services_.Utils;
using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Model;
using TwoFactorAuthenticator.Models.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IUserService _userService;

        public AuthController(IMapper mapper,IUserService userService) {
            _userService = userService;
            _mapper = mapper;
        } 

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel userModel)
        {
            userModel.Password = CryptographyUtil.Encrypt(userModel.Password);
            var user = _mapper.Map<User>(userModel);
            var response = await _userService.InsertAsync(user);
            return StatusCode(response.StatusCode,response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _userService.InsertKey("Olá mundo!");

            return Ok(response);
        }
    }
}
