using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TanksProject2.Domain.Models.MessageModels;
using TanksProject2.Domain.Models.Servise;
using TanksProject2.Servise.IServise;

namespace TanksProject2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageServis _message;
        public MessageController(IMessageServis _message)
        {
            this._message = _message;
        }

        [HttpPost("SendMessage")]
        public async Task<ActionResult<ServiseResponse<MessageServis>>> SendMessage(string message, int SenderId, int ReciverId)
        {
            var servise = await _message.SendMessage(message, SenderId, ReciverId);
            return Ok(servise);
        }

        [HttpGet("Listenmessage")]
        public async Task<ActionResult<ServiseResponse<List<MessageServis>>>> ListenMessage(int ReciverId)
        {
            var servise = await _message.ListenMessage(ReciverId);
            return Ok(servise);

        }
    }
}
