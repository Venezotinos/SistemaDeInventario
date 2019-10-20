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
    public class ProviderProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProviderProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProviderProducts
        [HttpGet]
        public IEnumerable<ProviderProduct> GetProviderProduct()
        {
            return _context.ProviderProduct;
        }

        // GET: api/ProviderProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProviderProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var providerProduct = await _context.ProviderProduct.FindAsync(id);

            if (providerProduct == null)
            {
                return NotFound();
            }

            return Ok(providerProduct);
        }

        // PUT: api/ProviderProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProviderProduct([FromRoute] int id, [FromBody] ProviderProduct providerProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != providerProduct.ProviderID)
            {
                return BadRequest();
            }

            _context.Entry(providerProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderProductExists(id))
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

        // POST: api/ProviderProducts
        [HttpPost]
        public async Task<IActionResult> PostProviderProduct([FromBody] ProviderProduct providerProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProviderProduct.Add(providerProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProviderProductExists(providerProduct.ProviderID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProviderProduct", new { id = providerProduct.ProviderID }, providerProduct);
        }

        // DELETE: api/ProviderProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProviderProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var providerProduct = await _context.ProviderProduct.FindAsync(id);
            if (providerProduct == null)
            {
                return NotFound();
            }

            _context.ProviderProduct.Remove(providerProduct);
            await _context.SaveChangesAsync();

            return Ok(providerProduct);
        }

        private bool ProviderProductExists(int id)
        {
            return _context.ProviderProduct.Any(e => e.ProviderID == id);
        }
    }
}