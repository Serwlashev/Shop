using Microsoft.AspNetCore.Mvc;
using Presentation.Shop.Models;
using Presentation.Shop.Services.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWebProductsService _productsService;

        public ProductsController(IWebProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task<IActionResult> Index(CancellationToken token)
        {
            var products = await _productsService.GetAllAsync(token);
            
            return View(new ProductIndexModel
            { 
                Products = products.ToList()
            });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel product, CancellationToken token)
        {
            await _productsService.CreateAsync(product, token);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long? id, CancellationToken token)
        {
            if (!id.HasValue)
            {
                return BadRequest("Product was not found");
            }

            await _productsService.RemoveAsync(id.Value, token);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(long? id, CancellationToken token)
        {
            var product = await _productsService.GetAsync(id.Value, token);

            if (!id.HasValue || product is null)
            {
                return BadRequest("Product not found");
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel product, CancellationToken token)
        {
            if(!(await _productsService.UpdateAsync(product, token)))
            {
                return BadRequest("Product was not found");
            }

            return RedirectToAction($"Detail", new { id = product.Id });
        }

        public async Task<IActionResult> Detail(long? id, CancellationToken token)
        {
            var product = await _productsService.GetAsync(id.Value, token);
            
            if (product is null)
            {
                return BadRequest("Product was not found");
            }

            return View(product);
        }

        public async Task<IActionResult> FindProducts(string searchText, CancellationToken token)
        {
            var products = await _productsService.FindProductsAsync(searchText, token);

            if(products != null && products.Count() > 0)
            {
                return View("Index", new ProductIndexModel
                {
                    Products = products.ToList()
                });
            }

            return RedirectToAction("Index");
        }
    }
}
