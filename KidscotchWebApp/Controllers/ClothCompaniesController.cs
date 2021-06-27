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
    public class ClothCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClothCompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClothCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClothCompanies.ToListAsync());
        }

        // GET: ClothCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothCompany = await _context.ClothCompanies
                .FirstOrDefaultAsync(m => m.ClothCompanyID == id);
            if (clothCompany == null)
            {
                return NotFound();
            }

            return View(clothCompany);
        }

        // GET: ClothCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClothCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClothCompanyID,ClothCompanyName,About")] ClothCompany clothCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clothCompany);
        }

        // GET: ClothCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothCompany = await _context.ClothCompanies.FindAsync(id);
            if (clothCompany == null)
            {
                return NotFound();
            }
            return View(clothCompany);
        }

        // POST: ClothCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClothCompanyID,ClothCompanyName,About")] ClothCompany clothCompany)
        {
            if (id != clothCompany.ClothCompanyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothCompanyExists(clothCompany.ClothCompanyID))
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
            return View(clothCompany);
        }

        // GET: ClothCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothCompany = await _context.ClothCompanies
                .FirstOrDefaultAsync(m => m.ClothCompanyID == id);
            if (clothCompany == null)
            {
                return NotFound();
            }

            return View(clothCompany);
        }

        // POST: ClothCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothCompany = await _context.ClothCompanies.FindAsync(id);
            _context.ClothCompanies.Remove(clothCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothCompanyExists(int id)
        {
            return _context.ClothCompanies.Any(e => e.ClothCompanyID == id);
        }
    }
}
