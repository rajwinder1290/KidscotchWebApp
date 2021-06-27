using KidscotchWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.ViewComponents
{
    public class CompanyMenuViewComponent : ViewComponent
    {
		private readonly ICompanyMenuAccessService _menuAccessService;

		public CompanyMenuViewComponent(ICompanyMenuAccessService menuAccessService)
		{
			_menuAccessService = menuAccessService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = await _menuAccessService.GetCompanyMenu();

			return View(items);
		}
	}
}
