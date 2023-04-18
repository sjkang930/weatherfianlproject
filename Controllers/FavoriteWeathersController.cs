using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weather.Models;

namespace Weather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoriteWeatherController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FavoriteWeatherController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteWeather
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteWeather>>> GetFavoriteWeathers()
        {
            return await _context.FavoriteWeathers.ToListAsync();
        }

        // GET: api/FavoriteWeather/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteWeather>> GetFavoriteWeather(Guid id)
        {
            var favoriteWeather = await _context.FavoriteWeathers.FindAsync(id);

            if (favoriteWeather == null)
            {
                return NotFound();
            }

            return favoriteWeather;
        }

        // POST: api/FavoriteWeather
        [HttpPost]
        public async Task<ActionResult<FavoriteWeather>> PostFavoriteWeather(FavoriteWeather favoriteWeather)
        {
            _context.FavoriteWeathers.Add(favoriteWeather);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavoriteWeather), new { id = favoriteWeather.Id }, favoriteWeather);
        }

        // PUT: api/FavoriteWeather/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteWeather(Guid id, FavoriteWeather favoriteWeather)
        {
            if (id != favoriteWeather.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteWeather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteWeatherExists(id))
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

        // DELETE: api/FavoriteWeather/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteWeather(Guid id)
        {
            var favoriteWeather = await _context.FavoriteWeathers.FindAsync(id);
            if (favoriteWeather == null)
            {
                return NotFound();
            }

            _context.FavoriteWeathers.Remove(favoriteWeather);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteWeatherExists(Guid id)
        {
            return _context.FavoriteWeathers.Any(e => e.Id == id);
        }
    }
}
