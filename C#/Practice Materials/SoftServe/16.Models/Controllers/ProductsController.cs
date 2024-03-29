﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ProductsValidation.Models;
using ProductsValidation.Models.Custom;
using ProductsValidation.Services;
using static ProductsValidation.Models.Product;

namespace ProductsValidation.Controllers
{
    
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }
        
        public IActionResult Index(int filterId, string filtername)
        {
            return View(myProducts);
        }
        
        public IActionResult View(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        } 
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;
            return View("View",product);
        }

        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            myProducts.Add(product);
            return View("View", product);
        }

        public IActionResult Create()
        {
            return View(new Product(){Id = myProducts.Last().Id + 1});
        }

        public IActionResult Delete(int id)
        {
            myProducts.Remove( myProducts.Find(product => product.Id == id));
            return View("Index", myProducts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult EditAll(Category type)
        {

            var products = myProducts.Where(prod => prod.Type == type).ToList();
            if (products != null)
            {
                return View(products);
            }

            return View("Index");
        }
        [HttpPost]
        public IActionResult EditAll(List<Product> products)
        {
            ProductValidator pv = new ProductValidator();
            foreach (var product in products)
            {
                ValidationResult result = pv.Validate(product);
                if (!result.IsValid)
                {
                    return View(products);
                }
            }
            foreach (var product in products)
            {
                myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;
            }
            return View("Index", myProducts);
        }
    }
}
