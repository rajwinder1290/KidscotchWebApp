using KidscotchWebApp.Data;
using KidscotchWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CartInfos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.CartInfos
                .Include(m => m.CartCartItems)
                .Where(m => m.CartID == id).FirstOrDefaultAsync();
            if (cart != null)
            {
                int quantity = 0;
                float total = 0.0F;
                foreach (CartItem item in cart.CartCartItems)
                {
                    item.ClothInfo = await _context.ClothInfos.Where(m => m.ClothInfoID == item.ClothInfoID).FirstOrDefaultAsync();
                    quantity += item.Quantity;
                    total += item.Total;
                }
                ViewData["Total"] = total;
                ViewData["Quantity"] = quantity;
            }
            return View(cart);
        }
    }
}
