using KidscotchWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KidscotchWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<ClothCompany> ClothCompanies { get; set; }
        public DbSet<ClothInfo> ClothInfos { get; set; }
        public DbSet<CartInfo> CartInfos { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
