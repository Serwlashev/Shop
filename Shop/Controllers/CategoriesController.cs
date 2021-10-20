using Microsoft.AspNetCore.Mvc;
using Presentation.Shop.Models.Categories;
using Presentation.Shop.Services.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Shop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IWebCategoriesService _categoriesService;

        public CategoriesController(IWebCategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public async Task<IActionResult> GetSidebar(CancellationToken token)
        {
            var categories = await _categoriesService.GetAllAsync(token);

            CategorySidebarModel model = new CategorySidebarModel()
            {
                Categories = categories.ToList()
            };

            return PartialView("_Sidebar", model);
        }
    }
}
