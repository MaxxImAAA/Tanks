using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TanksProject2.Domain.Dtos.TankDtos;
using TanksProject2.Domain.Models.Servise;
using TanksProject2.Servise.IServise;

namespace TanksProject2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TankController : ControllerBase
    {
        private readonly ITankServise _tank;
        public TankController(ITankServise _tank)
        {
            this._tank = _tank;
            
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiseResponse<TankDtos>>> AddTank(TankDtos tankDtos)
        {
            var servise = await _tank.AddTank(tankDtos);
            return Ok(servise);
        }

        [HttpGet("Get{id}")]
        public async Task<ActionResult<ServiseResponse<TankDtos>>> GetTank(int id)
        {
            var servise = await _tank.GetTank(id);
            return Ok(servise);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiseResponse<List<TankDtos>>>> GetAllTank()
        {
            var servise = await _tank.GetAllTank();
            return Ok(servise);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ServiseResponse<bool>>> DeleteTank(int id)
        {
            var servise = await _tank.DeleteTank(id);
            return Ok(servise);
        }

        [HttpPatch("Update")]
        public async Task<ActionResult<ServiseResponse<TankDtos>>> UpdateTank(int id, TankDtos tankDtos)
        {
            var servise = await _tank.UpdateTank(id, tankDtos);
            return Ok(servise);
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<ServiseResponse<List<TankDtos>>>> GetTankByName(string name)
        {
            var servise = await _tank.GetTankByName(name);
            return Ok(servise);
        }

        [HttpGet("GetByType")]
        public async Task<ActionResult<ServiseResponse<List<TankDtos>>>> GetTanksByType(string type)
        {
            var servise = await _tank.GetTanksByType(type);
            return Ok(servise);
        }

        [HttpGet("GetByNation")]
        public async Task<ActionResult<ServiseResponse<List<TankDtos>>>> GetTanksByNation(string nation)
        {
            var servise = await _tank.GetTanksByNation(nation);
            return Ok(servise);
        }

    }
}
