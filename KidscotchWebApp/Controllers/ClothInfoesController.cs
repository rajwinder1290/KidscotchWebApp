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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace KidscotchWebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class ClothInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ClothInfoesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: ClothInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClothInfos.Include(c => c.ClothCompany).Include(c => c.ShopCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClothInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothInfo = await _context.ClothInfos
                .Include(c => c.ClothCompany)
                .Include(c => c.ShopCategory)
                .FirstOrDefaultAsync(m => m.ClothInfoID == id);
            if (clothInfo == null)
            {
                return NotFound();
            }

            return View(clothInfo);
        }

        // GET: ClothInfoes/Create
        public IActionResult Create()
        {
            ViewData["ClothCompanyID"] = new SelectList(_context.ClothCompanies, "ClothCompanyID", "ClothCompanyName");
            ViewData["ShopCategoryID"] = new SelectList(_context.ShopCategories, "ShopCategoryID", "ShopCategoryName");
            return View();
        }

        // POST: ClothInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClothInfoID,Name,ClothPrice,SizeChart,Feature,ShopCategoryID,ClothCompanyID,File")] ClothInfo clothInfo)
        {
            using (var memoryStream = new MemoryStream())
            {
                await clothInfo.File.FormFile.CopyToAsync(memoryStream);

                string photoname = clothInfo.File.FormFile.FileName;
                clothInfo.Extension = Path.GetExtension(photoname);
                if (!".jpg.jpeg.png.gif.bmp".Contains(clothInfo.Extension.ToLower()))
                {
                    ModelState.AddModelError("File.FormFile", "Only Images Allowed");
                }
                else
                {
                    ModelState.Remove("Extension");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(clothInfo);
                await _context.SaveChangesAsync();
                var rootFolder = Path.Combine(_environment.WebRootPath, "cloths");
                if (!Directory.Exists(rootFolder))
                {
                    Directory.CreateDirectory(rootFolder);
                }
                string filename = clothInfo.ClothInfoID + clothInfo.Extension;
                var filePath = Path.Combine(rootFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await clothInfo.File.FormFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClothCompanyID"] = new SelectList(_context.ClothCompanies, "ClothCompanyID", "ClothCompanyName", clothInfo.ClothCompanyID);
            ViewData["ShopCategoryID"] = new SelectList(_context.ShopCategories, "ShopCategoryID", "ShopCategoryName", clothInfo.ShopCategoryID);
            return View(clothInfo);
        }

        // GET: ClothInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothInfo = await _context.ClothInfos.FindAsync(id);
            if (clothInfo == null)
            {
                return NotFound();
            }
            ViewData["ClothCompanyID"] = new SelectList(_context.ClothCompanies, "ClothCompanyID", "ClothCompanyName", clothInfo.ClothCompanyID);
            ViewData["ShopCategoryID"] = new SelectList(_context.ShopCategories, "ShopCategoryID", "ShopCategoryName", clothInfo.ShopCategoryID);
            return View(clothInfo);
        }

        // POST: ClothInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClothInfoID,Name,ClothPrice,SizeChart,Feature,ShopCategoryID,ClothCompanyID,Extension")] ClothInfo clothInfo)
        {
            if (id != clothInfo.ClothInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothInfoExists(clothInfo.ClothInfoID))
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
            ViewData["ClothCompanyID"] = new SelectList(_context.ClothCompanies, "ClothCompanyID", "ClothCompanyName", clothInfo.ClothCompanyID);
            ViewData["ShopCategoryID"] = new SelectList(_context.ShopCategories, "ShopCategoryID", "ShopCategoryName", clothInfo.ShopCategoryID);
            return View(clothInfo);
        }

        // GET: ClothInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothInfo = await _context.ClothInfos
                .Include(c => c.ClothCompany)
                .Include(c => c.ShopCategory)
                .FirstOrDefaultAsync(m => m.ClothInfoID == id);
            if (clothInfo == null)
            {
                return NotFound();
            }

            return View(clothInfo);
        }

        // POST: ClothInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothInfo = await _context.ClothInfos.FindAsync(id);
            _context.ClothInfos.Remove(clothInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothInfoExists(int id)
        {
            return _context.ClothInfos.Any(e => e.ClothInfoID == id);
        }
    }
}
