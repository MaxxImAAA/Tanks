using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TanksProject2.Domain.Dtos.UserTankDtos;
using TanksProject2.Domain.Models.Servise;
using TanksProject2.Servise.IServise;

namespace TanksProject2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServise _user;
        public UserController(IUserServise _user)
        {
            this._user = _user;
        }

        [HttpPost("AddTankByUser")]
        public async Task<ActionResult<ServiseResponse<bool>>> AddTank(int userId, int tankId)
        {
            var request = await _user.AddTank(userId, tankId);
            return Ok(request);
        }

        [HttpGet("GetTanksByUser")]
        public async Task<ActionResult<ServiseResponse<UserTankDT>>> GetTanks(int userId)
        {
            var request = await _user.GetTanks(userId);
            return Ok(request);
        }
    }
}
