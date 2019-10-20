using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeInventario.Data;
using SistemaDeInventario.Models;

namespace SistemaDeInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuysController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BuysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Buys
        [HttpGet]
        public IEnumerable<Buy> GetBuys()
        {
            return _context.Buys;
        }

        // GET: api/Buys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buy = await _context.Buys.FindAsync(id);

            if (buy == null)
            {
                return NotFound();
            }

            return Ok(buy);
        }

        // PUT: api/Buys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuy([FromRoute] int id, [FromBody] Buy buy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != buy.ID)
            {
                return BadRequest();
            }

            _context.Entry(buy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyExists(id))
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

        // POST: api/Buys
        [HttpPost]
        public async Task<IActionResult> PostBuy([FromBody] Buy buy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Buys.Add(buy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuy", new { id = buy.ID }, buy);
        }

        // DELETE: api/Buys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buy = await _context.Buys.FindAsync(id);
            if (buy == null)
            {
                return NotFound();
            }

            _context.Buys.Remove(buy);
            await _context.SaveChangesAsync();

            return Ok(buy);
        }

        private bool BuyExists(int id)
        {
            return _context.Buys.Any(e => e.ID == id);
        }
    }
}