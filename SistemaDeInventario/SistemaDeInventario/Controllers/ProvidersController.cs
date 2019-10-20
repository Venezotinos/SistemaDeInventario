﻿using System;
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
    public class ProvidersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProvidersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Providers
        [HttpGet]
        public IEnumerable<Provider> GetProviders()
        {
            return _context.Providers;
        }

        // GET: api/Providers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var provider = await _context.Providers.FindAsync(id);

            if (provider == null)
            {
                return NotFound();
            }

            return Ok(provider);
        }

        // PUT: api/Providers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvider([FromRoute] int id, [FromBody] Provider provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != provider.ProviderID)
            {
                return BadRequest();
            }

            _context.Entry(provider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(id))
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

        // POST: api/Providers
        [HttpPost]
        public async Task<IActionResult> PostProvider([FromBody] Provider provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvider", new { id = provider.ProviderID }, provider);
        }

        // DELETE: api/Providers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var provider = await _context.Providers.FindAsync(id);
            if (provider == null)
            {
                return NotFound();
            }

            _context.Providers.Remove(provider);
            await _context.SaveChangesAsync();

            return Ok(provider);
        }

        private bool ProviderExists(int id)
        {
            return _context.Providers.Any(e => e.ProviderID == id);
        }
    }
}