using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vendor_Product_Revenue_MVC.Data;
using Vendor_Product_Revenue_MVC.Models;

namespace Vendor_Product_Revenue_MVC.Controllers
{
    public class RevenuesController : Controller
    {
        private readonly Vendor_Product_Revenue_DBContext _context;

        public RevenuesController(Vendor_Product_Revenue_DBContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Revenues
        public async Task<IActionResult> Index()
        {
            var vendor_Product_Revenue_DBContext = _context.Revenue.Include(r => r.Product).Include(r => r.StoreFront);
            return View(await vendor_Product_Revenue_DBContext.ToListAsync());
        }
        [Authorize]
        // GET: Revenues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revenue = await _context.Revenue
                .Include(r => r.Product)
                .Include(r => r.StoreFront)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revenue == null)
            {
                return NotFound();
            }

            return View(revenue);
        }
        [Authorize]
        // GET: Revenues/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            ViewData["StoreFrontId"] = new SelectList(_context.Set<StoreFront>(), "Id", "Id");
            return View();
        }

        // POST: Revenues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,StoreFrontId,Quantity")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(revenue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", revenue.ProductId);
            ViewData["StoreFrontId"] = new SelectList(_context.Set<StoreFront>(), "Id", "Id", revenue.StoreFrontId);
            return View(revenue);
        }
        [Authorize]
        // GET: Revenues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revenue = await _context.Revenue.FindAsync(id);
            if (revenue == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", revenue.ProductId);
            ViewData["StoreFrontId"] = new SelectList(_context.Set<StoreFront>(), "Id", "Id", revenue.StoreFrontId);
            return View(revenue);
        }

        // POST: Revenues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,StoreFrontId,Quantity")] Revenue revenue)
        {
            if (id != revenue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revenue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevenueExists(revenue.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", revenue.ProductId);
            ViewData["StoreFrontId"] = new SelectList(_context.Set<StoreFront>(), "Id", "Id", revenue.StoreFrontId);
            return View(revenue);
        }
        [Authorize]
        // GET: Revenues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revenue = await _context.Revenue
                .Include(r => r.Product)
                .Include(r => r.StoreFront)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revenue == null)
            {
                return NotFound();
            }

            return View(revenue);
        }

        // POST: Revenues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var revenue = await _context.Revenue.FindAsync(id);
            _context.Revenue.Remove(revenue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevenueExists(int id)
        {
            return _context.Revenue.Any(e => e.Id == id);
        }
    }
}
