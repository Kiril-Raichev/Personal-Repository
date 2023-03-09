using BAL.Interfaces;
using EF_Core.ViewModels.ModelMapper;
using EF_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailsService orderDetailsService;
        public OrderDetailsController(IOrderDetailsService orderDetailsService, IOrderService orderService)
        {
            this.orderDetailsService = orderDetailsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var orderDetails = await this.orderDetailsService.GetByOrderId(id);
            return View(orderDetails);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderDetailCreateAndEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var orderDetailToCreate = new OrderDetailsMapper().ModelToOrderDetails(viewModel);

            try
            {
                await this.orderDetailsService.Create(orderDetailToCreate);
                
                return RedirectToAction("Index", orderDetailToCreate.OrderId);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var orderToEdit = await this.orderDetailsService.GetById(id);

            if (orderToEdit == null)
            {
                RedirectToAction("Error", "Home");
            }

            var viewModel = new OrderDetailsMapper().OrderDetailsToModel(orderToEdit);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OrderDetailCreateAndEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var orderToEdit = new OrderDetailsMapper().ModelToOrderDetails(viewModel);

            try
            {
                await this.orderDetailsService.Edit(orderToEdit);
      
                return RedirectToAction("Index", orderToEdit.OrderId);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var toDelete= await this.orderDetailsService.Delete(id);
                var ordersDetails = await this.orderDetailsService.GetByOrderId(toDelete.OrderId);
                return RedirectToAction("Index", ordersDetails);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
