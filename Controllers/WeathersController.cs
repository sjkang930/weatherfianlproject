using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Weather.Hubs;
using Weather.Models;

namespace Weather.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherDataController : ControllerBase
    {
        private readonly DatabaseContext _context;

        private readonly IHubContext<ChatHub> _hub;

        public WeatherDataController(
            DatabaseContext context,
            IHubContext<ChatHub> hub
        )
        {
            _context = context;
            _hub = hub;
        }

        // GET: api/WeatherData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherData>>>
        GetWeatherData()
        {
            return await _context.WeatherDatas.ToListAsync();
        }

        // GET: api/WeatherData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherData>> GetWeatherData(Guid id)
        {
            var weatherData = await _context.WeatherDatas.FindAsync(id);

            if (weatherData == null)
            {
                return NotFound();
            }

            return weatherData;
        }

        // POST: api/WeatherData/{UserId}
        [HttpPost("{UserId}")]
        public async Task<ActionResult<WeatherData>>
        PostWeatherData(string userId, WeatherData weatherData)
        {
            weatherData.UserId = userId;

            _context.WeatherDatas.Add(weatherData);
            await _context.SaveChangesAsync();

            await _hub.Clients.All.SendAsync("ReceiveMessage", weatherData);

            return weatherData;
        }

        // PUT: api/WeatherData/5
        [HttpPut("{id}")]
        public async Task<IActionResult>
        PutWeatherData(Guid id, WeatherData weatherData)
        {
            if (id != weatherData.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/WeatherData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherData(Guid id)
        {
            var weatherData = await _context.WeatherDatas.FindAsync(id);
            if (weatherData == null)
            {
                return NotFound();
            }

            _context.WeatherDatas.Remove (weatherData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherDataExists(Guid id)
        {
            return _context.WeatherDatas.Any(e => e.Id == id);
        }
    }
}
