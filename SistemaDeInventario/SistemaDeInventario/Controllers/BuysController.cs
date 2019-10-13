using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeInventario.Data;
using SistemaDeInventario.Models;

namespace SistemaDeInventario.Controllers
{
    public class BuysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Buys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Buys.Include(b => b.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Buys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buy = await _context.Buys
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (buy == null)
            {
                return NotFound();
            }

            return View(buy);
        }

        // GET: Buys/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Name");
            return View();
        }

        // POST: Buys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BuyDate,Quantity,ProductID")] Buy buy)
        {
            if (ModelState.IsValid)
            {
                buy.BuyDate = DateTime.Now;

                var product = _context.Products.Find(buy.ProductID);
                buy.Ammount = product.BuyPrice * buy.Quantity;
                
                _context.Add(buy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Name", buy.ProductID);
            return View(buy);
        }

        // GET: Buys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buy = await _context.Buys.FindAsync(id);
            if (buy == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Name", buy.ProductID);
            return View(buy);
        }

        // POST: Buys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BuyDate,Quantity,ProductID")] Buy buy)
        {
            if (id != buy.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyExists(buy.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Name", buy.ProductID);
            return View(buy);
        }

        // GET: Buys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buy = await _context.Buys
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (buy == null)
            {
                return NotFound();
            }

            return View(buy);
        }

        // POST: Buys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buy = await _context.Buys.FindAsync(id);
            _context.Buys.Remove(buy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyExists(int id)
        {
            return _context.Buys.Any(e => e.ID == id);
        }
    }
}
