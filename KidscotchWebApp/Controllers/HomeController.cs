using KidscotchWebApp.Data;
using KidscotchWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClothCompanies.ToListAsync());
        }

        public async Task<IActionResult> ViewClothByCompany(int? id)
        {
            var company = await _context.ClothCompanies.FindAsync(id);
            ViewData["CompanyName"] = "None";
            if (company != null)
            {
                ViewData["CompanyName"] = company.ClothCompanyName;
            }
            var applicationDbContext = _context.ClothInfos
                .Include(j => j.ClothCompany)
                .Include(j => j.ShopCategory)
                .Where(m => m.ClothCompanyID == id);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> ViewClothByCategory(int? id)
        {
            var category = await _context.ShopCategories.FindAsync(id);
            ViewData["CategoryName"] = "None";
            if (category != null)
            {
                ViewData["CategoryName"] = category.ShopCategoryName;
            }
            var applicationDbContext = _context.ClothInfos
                .Include(j => j.ClothCompany)
                .Include(j => j.ShopCategory)
                .Where(m => m.ShopCategoryID == id);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> AllCloth()
        {
            var applicationDbContext = _context.ClothInfos
                .Include(j => j.ClothCompany)
                .Include(j => j.ShopCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> ViewDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemInfo = await _context.ClothInfos
                .Include(j => j.ClothCompany)
                .Include(j => j.ShopCategory)
                .FirstOrDefaultAsync(m => m.ClothInfoID == id);
            if (itemInfo == null)
            {
                return NotFound();
            }

            return View(itemInfo);
        }

        // Cart Logic Begins

        [Authorize]
        public async Task<IActionResult> AddToCart(int? id)
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
            string userid = _userManager.GetUserName(this.User);
            var carts = _context.CartInfos
                .Include(m => m.CartCartItems)
                .Where(m => m.UserID == userid && m.CartStatus.Equals("Cart")).FirstOrDefault();
            if (carts != null)
            {
                CartItem cartitem = null;
                foreach (CartItem item in carts.CartCartItems)
                {
                    if (item.ClothInfoID == clothInfo.ClothInfoID)
                    {
                        cartitem = item;
                        break;
                    }
                }
                if (cartitem != null)
                {
                    cartitem.Quantity += 1;
                    _context.Update(cartitem);
                }
                else
                {
                    CartItem item = new CartItem();
                    item.CartID = carts.CartID;
                    item.ClothInfoID = clothInfo.ClothInfoID;
                    item.Price = clothInfo.ClothPrice;
                    item.Quantity = 1;
                    item.Total = item.Price * item.Quantity;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                CartInfo cart = new CartInfo();
                cart.UserID = userid;
                cart.CartDate = DateTime.Now;
                cart.Address = "";
                cart.ContactNo = "";
                cart.OrderDate = DateTime.Now;
                cart.CartStatus = "Cart";
                _context.Add(cart);
                await _context.SaveChangesAsync();
                CartItem item = new CartItem();
                item.CartID = cart.CartID;
                item.ClothInfoID = clothInfo.ClothInfoID;
                item.Price = clothInfo.ClothPrice;
                item.Quantity = 1;
                item.Total = item.Price * item.Quantity;
                _context.Add(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MyCart));
        }

        [Authorize]
        public async Task<IActionResult> DeleteCartItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MyCart));
        }

        [Authorize]
        public async Task<IActionResult> MyCart()
        {
            string userid = _userManager.GetUserName(this.User);
            var cart = await _context.CartInfos
                .Include(m => m.CartCartItems)
                .Where(m => m.UserID == userid && m.CartStatus.Equals("Cart")).FirstOrDefaultAsync();
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

        [Authorize]
        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.CartInfos
                .Include(m => m.CartCartItems)
                .FirstOrDefaultAsync(m => m.CartID == id);
            if (cart == null)
            {
                return NotFound();
            }
            else if (cart.CartCartItems.Count == 0)
            {
                return NotFound();
            }
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
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(int id, [Bind("CartID,UserID,CartDate,CartStatus,OrderDate,Address,ContactNo")] CartInfo cartInfo)
        {
            if (id != cartInfo.CartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cartInfo.CartStatus = "Order";
                    cartInfo.OrderDate = DateTime.Now;
                    _context.Update(cartInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return RedirectToAction(nameof(MyOrders));
        }

        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            string userid = _userManager.GetUserName(this.User);
            var carts = _context.CartInfos
                .Include(m => m.CartCartItems)
                .Where(m => m.UserID == userid && !m.CartStatus.Equals("Cart"));
            return View(await carts.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> OrderDetails(int? id)
        {
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

        [Authorize]
        public async Task<IActionResult> CancelOrder(int? id)
        {
            var cart = await _context.CartInfos
                .Include(m => m.CartCartItems)
                .Where(m => m.CartID == id).FirstOrDefaultAsync();
            if (cart != null)
            {
                cart.CartStatus = "Cancel";
                _context.Update(cart);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MyOrders));
        }

        // Cart Logic Ends


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
