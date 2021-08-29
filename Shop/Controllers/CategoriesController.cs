using Microsoft.AspNetCore.Mvc;
using Shop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
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
