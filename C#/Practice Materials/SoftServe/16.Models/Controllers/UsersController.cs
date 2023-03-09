﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ProductsValidation.Models;
using ProductsValidation.Services;

namespace ProductsValidation.Controllers
{
    public class UsersController : Controller
    {
        private List<User> users;

        public UsersController(Data data)
        {
            users = data.Users;
        }
        
        public IActionResult Index(string id)
        {
            return View("Index", users);
        }
        [HttpGet]
        public ActionResult CreateUser([FromQuery]string name, [FromQuery]string email, [FromQuery]string role)
        {
            User user = new User()
            {
                Id = users.Count() + 1,
                Name = name,
                Email = email,
                Role = role
            };
            return View(user);
        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            users.Add(user);
            return View("Index", users);
        }
    }
}