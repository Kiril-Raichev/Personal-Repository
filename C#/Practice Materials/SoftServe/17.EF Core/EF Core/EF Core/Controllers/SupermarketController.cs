using BAL.Services;
using EF_Core.ViewModels.ModelMapper;
using EF_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BAL.Interfaces;
using BAL.Models;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Controllers
{

    public class SupermarketController : Controller
    {
        private ISupermarketService supermarketService;
        public SupermarketController(ISupermarketService supermarketService)
        {
            this.supermarketService = supermarketService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(
        int? pageNumber)
        {
            int pageSize = 3;
            var supermarkets = supermarketService.GetPages();
            return View(await PaginatedList<SuperMarket>.CreateAsync(supermarkets.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SupermarketCreateAndEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var supermarketToCreate = new SupermarketMapper().ModelToSupermarket(viewModel);

            await this.supermarketService.Create(supermarketToCreate);

            return RedirectToAction("Details", supermarketToCreate);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var supermarketToEdit = await this.supermarketService.GetById(id);

            if (supermarketToEdit == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var viewModel = new SupermarketMapper().SupermarketToModel(supermarketToEdit);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SupermarketCreateAndEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var supermarketToEdit = new SupermarketMapper().ModelToSupermarket(viewModel);

            try
            {
                await this.supermarketService.Edit(supermarketToEdit);
                return RedirectToAction("Details", supermarketToEdit);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var supermarket = await this.supermarketService.GetById(id);

            if (supermarket == null)
            {
                RedirectToAction("Error", "Home");
            }

            return View(supermarket);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.supermarketService.Delete(id);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

            var supermarkets = await supermarketService.GetAll();

            return RedirectToAction("Index", supermarkets);
        }
    }
}
