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
    public class BranchProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BranchProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BranchProducts
        [HttpGet]
        public IEnumerable<BranchProduct> GetBranchProduct()
        {
            return _context.BranchProduct;
        }

        // GET: api/BranchProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranchProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var branchProduct = await _context.BranchProduct.FindAsync(id);

            if (branchProduct == null)
            {
                return NotFound();
            }

            return Ok(branchProduct);
        }

        // PUT: api/BranchProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranchProduct([FromRoute] int id, [FromBody] BranchProduct branchProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branchProduct.BranchID)
            {
                return BadRequest();
            }

            _context.Entry(branchProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchProductExists(id))
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

        // POST: api/BranchProducts
        [HttpPost]
        public async Task<IActionResult> PostBranchProduct([FromBody] BranchProduct branchProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BranchProduct.Add(branchProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BranchProductExists(branchProduct.BranchID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBranchProduct", new { id = branchProduct.BranchID }, branchProduct);
        }

        // DELETE: api/BranchProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranchProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var branchProduct = await _context.BranchProduct.FindAsync(id);
            if (branchProduct == null)
            {
                return NotFound();
            }

            _context.BranchProduct.Remove(branchProduct);
            await _context.SaveChangesAsync();

            return Ok(branchProduct);
        }

        private bool BranchProductExists(int id)
        {
            return _context.BranchProduct.Any(e => e.BranchID == id);
        }
    }
}