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
    public class StoreFrontsController : Controller
    {
        private readonly Vendor_Product_Revenue_DBContext _context;

        public StoreFrontsController(Vendor_Product_Revenue_DBContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: StoreFronts
        public async Task<IActionResult> Index()
        {
            return View(await _context.StoreFront.ToListAsync());
        }
        [Authorize]
        // GET: StoreFronts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeFront = await _context.StoreFront
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeFront == null)
            {
                return NotFound();
            }

            return View(storeFront);
        }
        [Authorize]
        // GET: StoreFronts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoreFronts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StoreFrontName,StoreFrontUrl")] StoreFront storeFront)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeFront);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storeFront);
        }
        [Authorize]
        // GET: StoreFronts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeFront = await _context.StoreFront.FindAsync(id);
            if (storeFront == null)
            {
                return NotFound();
            }
            return View(storeFront);
        }

        // POST: StoreFronts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StoreFrontName,StoreFrontUrl")] StoreFront storeFront)
        {
            if (id != storeFront.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeFront);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreFrontExists(storeFront.Id))
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
            return View(storeFront);
        }
        [Authorize]
        // GET: StoreFronts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeFront = await _context.StoreFront
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeFront == null)
            {
                return NotFound();
            }

            return View(storeFront);
        }

        // POST: StoreFronts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storeFront = await _context.StoreFront.FindAsync(id);
            _context.StoreFront.Remove(storeFront);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreFrontExists(int id)
        {
            return _context.StoreFront.Any(e => e.Id == id);
        }
    }
}
