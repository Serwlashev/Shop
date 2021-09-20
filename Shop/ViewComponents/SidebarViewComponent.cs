﻿using Microsoft.AspNetCore.Mvc;
using Presentation.Shop.Models.Categories;
using Presentation.Shop.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IWebCategoriesService _categoriesService;

        public SidebarViewComponent(IWebCategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoriesService.GetAllAsync();

            CategorySidebarModel model = new CategorySidebarModel()
            {
                Categories = categories.ToList()
            };

            return View();
        }
    }
}
