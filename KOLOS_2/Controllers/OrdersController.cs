// Controllers/OrdersController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KOLOS_2.Services;
using KOLOS_2.DTOs;
using System.Linq;

namespace KOLOS_2.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrdersController : ControllerBase
    {
        private readonly IUserRaces _userRaces;
        public OrdersController(IUserRaces userRaces) => _userRaces = userRaces;

        [HttpGet("racers/{id}/participations")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var orders = await _userRaces.GetUserRaces(id);
            if (orders == null)
                return NotFound(new { message = "Patient not found" });
            return Ok(orders);
        }
        
        
        [HttpPost("track-races/participants")]
        public async Task<IActionResult> AddOrder(int id, [FromBody] AddRacerToRaceDTO req)
        {
            var orders = await _userRaces.AddRacersToRace(req);
            if (orders == null)
                return NotFound(new { message = "Patient not found" });
            return Ok(orders);
        }

    }
}