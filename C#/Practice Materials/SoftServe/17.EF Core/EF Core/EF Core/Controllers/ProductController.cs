using BAL.Interfaces;
using EF_Core.ViewModels.ModelMapper;
using EF_Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService orderDetailsService)
        {
            this.productService = orderDetailsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await this.productService.GetAll();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateAndEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var productToCreate = new ProductMapper().ModelToProduct(viewModel);

            await this.productService.Create(productToCreate);

            var products = await this.productService.GetAll();
            return RedirectToAction("Index", products);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var productToEdit = await this.productService.GetById(id);

            if (productToEdit == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var viewModel = new ProductMapper().ProductToModel(productToEdit);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductCreateAndEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var productToEdit = new ProductMapper().ModelToProduct(viewModel);

            try
            {
                await this.productService.Edit(productToEdit);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

            var products = await this.productService.GetAll();
            return RedirectToAction("Index", products);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.productService.Delete(id);
                var products = await this.productService.GetAll();
                return RedirectToAction("Index", products);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
