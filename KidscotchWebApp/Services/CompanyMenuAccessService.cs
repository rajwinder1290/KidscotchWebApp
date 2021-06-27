using KidscotchWebApp.Data;
using KidscotchWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.Services
{
    public class CompanyMenuAccessService : ICompanyMenuAccessService
    {
        private readonly ApplicationDbContext _context;

        public CompanyMenuAccessService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClothCompany>> GetCompanyMenu()
        {
            return await _context.ClothCompanies.ToListAsync();
        }
    }
}
