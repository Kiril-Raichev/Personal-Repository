using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsWithRouting.Models;
using ProductsWithRouting.Services;
using ProductsWithRouting.Filters;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Http;

namespace ProductsWithRouting.Controllers
{
    [ControllerTimeResultFilter]
    public class ProductsController : Controller
    {
        private List<Product> myProducts;
        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }
        [Route("/items/index/")]
        [Route("/products/index")]
        [Route("/products/")]
        [Route("/items/")]
        public IActionResult Index(int? filterId, string filtername)
        {
            if (filterId != null || filtername != null)
            {
                return View(myProducts.Where(p => p.Id == filterId || p.Name == filtername));
            }
            return View(myProducts);
        }
        [Route("/items/Index/filter/")]
        public IActionResult FilterBoth(int? filterId, string filtername)
        {
            if (filterId != null && filtername != null)
            {
                return View("Index", myProducts.Where(p => p.Name == filtername).Where(p => p.Id == filterId));
            }
            return View("Index", myProducts);
        }
        [Route("products/{id}")]
        public IActionResult View(int id)
        {
            var product = myProducts.Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = myProducts.Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Error", "Home");

        }
        [HttpPost]
        [ProductEditActionFilter]
        public IActionResult Edit(Product productChanges)
        {
            if (!ModelState.IsValid) 
            {
                var modelValue = ModelState["Description"];
                modelValue.Errors.Clear();

                return View(productChanges);
            }
            var product = myProducts.Where(p => p.Id == productChanges.Id).FirstOrDefault();
            product.Name = productChanges.Name;
            product.Description = productChanges.Description;
            return View("Index", myProducts);
        }

        [HttpPost("products/create/")]
        [HttpPost("products/new/")]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            myProducts.Add(product);
            return View("Index", myProducts);
        }
        [Route("products/create/")]
        [Route("products/new/")]
        public IActionResult Create()
        {
            var product = new Product() { Id = myProducts.Count() + 1 };
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = myProducts.Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                var deletedIndex = myProducts.FindIndex(p => p == product);
                for(int i = deletedIndex + 1; i < myProducts.Count(); i++)
                {
                    myProducts[i].Id--;
                }
                myProducts.Remove(product);
                return View("Index", myProducts);
            }
            return RedirectToAction("Error", "Home");

        }
    }
}
