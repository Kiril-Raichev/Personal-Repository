using Microsoft.AspNetCore.Mvc;
using BAL.Interfaces;
using DAL.Models;
using EF_Core.ViewModels;
using System.Security.Claims;
using EF_Core.ViewModels.ModelMapper;
using Microsoft.Data.SqlClient;

namespace EF_Core.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;

        }

        [HttpGet]
        public async Task<IActionResult> Index(string filterInput, string sortInput)
        {
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortInput) ? "nameDesc" : "";
            ViewBag.AddressSortParam = sortInput == "address" ? "addressDesc" : "address";
            var customers = await customerService.GetAll();
            //Filter
            if (filterInput != null)
            {
                var filtered = customers.Where(c => c.LName.Contains(filterInput, StringComparison.InvariantCultureIgnoreCase));

                return View(filtered);
            }

            //Sort
            switch (sortInput)
            {
                case "nameDesc":
                    var sorted = customers.OrderByDescending(c => c.LName);
                    return View(sorted);
                case "address":
                    sorted = customers.OrderBy(c => c.Address);
                    return View(sorted);
                case "addressDesc":
                    sorted = customers.OrderByDescending(c => c.Address);
                    return View(sorted);
                default:
                    sorted = customers.OrderBy(c => c.LName);
                    return View(sorted);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateAndEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var customerToCreate = new CustomerMapper().ModelToCustomer(viewModel);

            await this.customerService.Create(customerToCreate);

            return RedirectToAction("Details", customerToCreate);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var customerToEdit = await this.customerService.GetById(id);

            if (customerToEdit == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var viewModel = new CustomerMapper().CustomerToModel(customerToEdit);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerCreateAndEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var customerToEdit = new CustomerMapper().ModelToCustomer(viewModel);
            try
            {
                await this.customerService.Edit(customerToEdit);
                return RedirectToAction("Details", customerToEdit);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {          
            var customer = await this.customerService.GetById(id);
           
            if (customer == null)
            {
                return RedirectToAction("Error", "Home");
            
            }
            return View(customer);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.customerService.Delete(id);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

            var customers = await customerService.GetAll();

            return RedirectToAction("Index", customers);
        }
    }
}
