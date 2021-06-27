using KidscotchWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
		private readonly ICategoryMenuAccessService _menuAccessService;

		public CategoryMenuViewComponent(ICategoryMenuAccessService menuAccessService)
		{
			_menuAccessService = menuAccessService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = await _menuAccessService.GetCategoryMenu();

			return View(items);
		}
	}
}
