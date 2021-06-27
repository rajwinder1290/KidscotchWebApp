using KidscotchWebApp.Data;
using KidscotchWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.Services
{
    public class CategoryMenuAccessService : ICategoryMenuAccessService
    {
        private readonly ApplicationDbContext _context;

        public CategoryMenuAccessService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShopCategory>> GetCategoryMenu()
        {
            return await _context.ShopCategories.ToListAsync();
        }
    }
}
