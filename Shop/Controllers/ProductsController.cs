using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWebProductsService _productsService;

        public ProductsController(IWebProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productsService.GetAllAsync();
            
            return View(new ProductIndexModel { 
                Products = products.ToList()
            });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel product)
        {
            await _productsService.CreateAsync(product);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("Product was not found");
            }

            await _productsService.RemoveAsync(id.Value);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(long? id)
        {
            var prodcut = await _productsService.GetAsync(id.Value);

            if (!id.HasValue || prodcut is null)
            {
                return BadRequest("Product not found");
            }

            return View(prodcut);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel product)
        {
            if(!(await _productsService.UpdateAsync(product)))
            {
                return BadRequest("Product was not found");
            }

            return RedirectToAction($"Detail", new { id = product.Id });
        }

        public async Task<IActionResult> Detail(long? id)
        {
            var product = await _productsService.GetAsync(id.Value);
            
            if (product is null)
            {
                return BadRequest("Product was not found");
            }

            return View(product);
        }
    }
}
