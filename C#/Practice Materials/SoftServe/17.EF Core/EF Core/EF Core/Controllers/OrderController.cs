using BAL.Services;
using EF_Core.ViewModels.ModelMapper;
using EF_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BAL.Interfaces;

namespace EF_Core.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IOrderDetailsService orderDetailsService;
        public OrderController(IOrderService orderService, IOrderDetailsService orderDetailsService) 
        {
            this.orderService = orderService;
            this.orderDetailsService = orderDetailsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await this.orderService.GetAll();
            return View(orders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateAndEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var orderToCreate = new OrderMapper().ModelToOrder(viewModel);

            try
            {
                await this.orderService.Create(orderToCreate);
            }
            catch (Exception)
            {
                return RedirectToAction("Error","Home");
            }


            var orders = await this.orderService.GetAll();
            return RedirectToAction("Index", orders);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var orderToEdit = await this.orderService.GetById(id);

            if (orderToEdit == null)
            {
                RedirectToAction("Error", "Home");
            }

            var viewModel = new OrderMapper().OrderToModel(orderToEdit);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OrderCreateAndEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var orderToEdit = new OrderMapper().ModelToOrder(viewModel);
       
            try
            {
                await this.orderService.Edit(orderToEdit);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

            var orders = await this.orderService.GetAll();
            return RedirectToAction("Index", orders);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var orderDetails = await this.orderDetailsService.GetByOrderId(id);
            if (orderDetails == null)
            {
                RedirectToAction("Error", "Home");
            }


            return View(orderDetails);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.orderService.Delete(id);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

            var orders = await orderService.GetAll();

            return RedirectToAction("Index", orders);
        }
    }
}
