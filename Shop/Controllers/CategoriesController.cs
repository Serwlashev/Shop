using Microsoft.AspNetCore.Mvc;
using Presentation.Shop.Services.Interfaces;

namespace Presentation.Shop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IWebCategoriesService _categoriesService;

        public CategoriesController(IWebCategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
    }
}
