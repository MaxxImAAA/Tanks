using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using TanksProject2.Domain.Dtos.UserDtos;
using TanksProject2.Domain.Models.Servise;
using TanksProject2.Domain.Models.UserModel;
using TanksProject2.Servise.IServise;
using TanksProject2.Servise.Servise;

namespace TanksProject2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountServise _user;
        public UserAccountController(IUserAccountServise _user)
        {
            this._user = _user;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiseResponse<bool>>> Register(UserRegistrationDtos userRegistrationDtos)
        {
            var request = await _user.Register(userRegistrationDtos);
            return Ok(request);
        }

        [HttpGet("Login")]
        public async Task<ActionResult<ServiseResponse<UserDtos>>> Login(string email, string password)
        {
            var request = await _user.Login(email, password);
           
            return Ok(request);
        }

        [HttpPatch]
        public async Task<ActionResult<ServiseResponse<UserDtos>>> EditUserAccount(int id, UserRegistrationDtos userRegistrationDtos)
        {
            var request = await _user.EditUserAccount(id, userRegistrationDtos);
            return Ok(request);
        }
    }
}
