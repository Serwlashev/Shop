using Microsoft.AspNetCore.Mvc;
using Presentation.Shop.Models.Categories;
using Presentation.Shop.Services.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.ViewComponents
{
    [ViewComponent(Name = "SidebarItems")]
    public class SidebarItemsComponent : ViewComponent
    {
        private readonly IWebCategoriesService _categoriesService;

        public SidebarItemsComponent(IWebCategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken token)
        {
            var categories = await _categoriesService.GetAllAsync(token);

            CategorySidebarModel model = new CategorySidebarModel()
            {
                Categories = categories.ToList()
            };

            return View("SidebarItems", model);
        }
    }
}
