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
    public class CategoryProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoryProducts
        [HttpGet]
        public IEnumerable<CategoryProduct> GetCategoryProduct()
        {
            return _context.CategoryProduct;
        }

        // GET: api/CategoryProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryProduct = await _context.CategoryProduct.FindAsync(id);

            if (categoryProduct == null)
            {
                return NotFound();
            }

            return Ok(categoryProduct);
        }

        // PUT: api/CategoryProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryProduct([FromRoute] int id, [FromBody] CategoryProduct categoryProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryProduct.CategoryID)
            {
                return BadRequest();
            }

            _context.Entry(categoryProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryProductExists(id))
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

        // POST: api/CategoryProducts
        [HttpPost]
        public async Task<IActionResult> PostCategoryProduct([FromBody] CategoryProduct categoryProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CategoryProduct.Add(categoryProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryProductExists(categoryProduct.CategoryID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategoryProduct", new { id = categoryProduct.CategoryID }, categoryProduct);
        }

        // DELETE: api/CategoryProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryProduct = await _context.CategoryProduct.FindAsync(id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            _context.CategoryProduct.Remove(categoryProduct);
            await _context.SaveChangesAsync();

            return Ok(categoryProduct);
        }

        private bool CategoryProductExists(int id)
        {
            return _context.CategoryProduct.Any(e => e.CategoryID == id);
        }
    }
}