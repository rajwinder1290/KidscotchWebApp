using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KidscotchWebApp.Data;
using KidscotchWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace KidscotchWebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class ShopCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShopCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShopCategories.ToListAsync());
        }

        // GET: ShopCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCategory = await _context.ShopCategories
                .FirstOrDefaultAsync(m => m.ShopCategoryID == id);
            if (shopCategory == null)
            {
                return NotFound();
            }

            return View(shopCategory);
        }

        // GET: ShopCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopCategoryID,ShopCategoryName")] ShopCategory shopCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopCategory);
        }

        // GET: ShopCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCategory = await _context.ShopCategories.FindAsync(id);
            if (shopCategory == null)
            {
                return NotFound();
            }
            return View(shopCategory);
        }

        // POST: ShopCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopCategoryID,ShopCategoryName")] ShopCategory shopCategory)
        {
            if (id != shopCategory.ShopCategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopCategoryExists(shopCategory.ShopCategoryID))
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
            return View(shopCategory);
        }

        // GET: ShopCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCategory = await _context.ShopCategories
                .FirstOrDefaultAsync(m => m.ShopCategoryID == id);
            if (shopCategory == null)
            {
                return NotFound();
            }

            return View(shopCategory);
        }

        // POST: ShopCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopCategory = await _context.ShopCategories.FindAsync(id);
            _context.ShopCategories.Remove(shopCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopCategoryExists(int id)
        {
            return _context.ShopCategories.Any(e => e.ShopCategoryID == id);
        }
    }
}
