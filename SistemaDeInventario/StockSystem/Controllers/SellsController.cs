using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockSystem.Data;
using StockSystem.Models;

namespace StockSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SellsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sells
        [HttpGet]
        public IEnumerable<Sell> GetSells()
        {
            return _context.Sells;
        }

        // GET: api/Sells/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSell([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sell = await _context.Sells.FindAsync(id);

            if (sell == null)
            {
                return NotFound();
            }

            return Ok(sell);
        }

        // PUT: api/Sells/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSell([FromRoute] int id, [FromBody] Sell sell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sell.ID)
            {
                return BadRequest();
            }

            _context.Entry(sell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellExists(id))
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

        // POST: api/Sells
        [HttpPost]
        public async Task<IActionResult> PostSell([FromBody] Sell sell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sells.Add(sell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSell", new { id = sell.ID }, sell);
        }

        // DELETE: api/Sells/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSell([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sell = await _context.Sells.FindAsync(id);
            if (sell == null)
            {
                return NotFound();
            }

            _context.Sells.Remove(sell);
            await _context.SaveChangesAsync();

            return Ok(sell);
        }

        private bool SellExists(int id)
        {
            return _context.Sells.Any(e => e.ID == id);
        }
    }
}