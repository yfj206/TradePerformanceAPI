using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradePerformanceAPI.dtos.Trader;
using TradePerformanceAPI.Models;

namespace TradePerformanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradersController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public TradersController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Traders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trader>>> GetTraders()
        {
            if (_context.Traders == null)
            {
                return NotFound();
            }
            return await _context.Traders.ToListAsync();
        }

        // GET: api/Traders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trader>> GetTrader(Guid id)
        {
            if (_context.Traders == null)
            {
                return NotFound();
            }
            var trader = await _context.Traders.FindAsync(id);

            if (trader == null)
            {
                return NotFound();
            }

            return trader;
        }

        // PUT: api/Traders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrader(Guid id, [FromBody] TraderUpdateDto traderUpdateDto)
        {
            // Fetch the existing trader from the database
            var trader = await _context.Traders.FindAsync(id);

            if (trader == null)
            {
                return NotFound();
            }

            // Update the properties of the existing trader
            trader.Name = traderUpdateDto.Name;
            trader.Email = traderUpdateDto.Email;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception if necessary
                if (!TraderExists(id))
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


        // POST: api/Traders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trader>> PostTrader(TraderCreateDto trader)
        {
            if (_context.Traders == null)
            {
                return Problem("Entity set 'DataBaseContext.Traders'  is null.");
            }
            var traderval = new Trader()
            {
                Id = new Guid(),
                Name = trader.Name,
                Email = trader.Email
            };
            _context.Traders.Add(traderval);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrader", new { id = traderval.Id }, trader);

        }

        // DELETE: api/Traders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrader(Guid id)
        {
            if (_context.Traders == null)
            {
                return NotFound();
            }
            var trader = await _context.Traders.FindAsync(id);
            if (trader == null)
            {
                return NotFound();
            }

            _context.Traders.Remove(trader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraderExists(Guid id)
        {
            return (_context.Traders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
