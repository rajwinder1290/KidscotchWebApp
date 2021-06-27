using KidscotchWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.Services
{
    public interface ICompanyMenuAccessService
    {
        Task<List<ClothCompany>> GetCompanyMenu();
    }
}
