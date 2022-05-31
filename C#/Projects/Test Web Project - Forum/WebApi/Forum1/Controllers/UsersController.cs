using Forum1.Hellper;
using Forum1.Models;
using Forum1.Models.Mappers;
using Forum1.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace Forum1.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly AuthorisationHelper authorisationHelper;
        private readonly UserMapper userMapper;
        private readonly IWebHostEnvironment hostingEnvironment;
        public UsersController(IWebHostEnvironment hostingEnvironment, IUserService userService, AuthorisationHelper authorisationHelper, UserMapper userMapper)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.userService = userService;
            this.authorisationHelper = authorisationHelper;
            this.userMapper = userMapper;
        }
            public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update ()
        {
            UserDto userDto = new UserDto();
            return this.View(model: userDto);
        }

        [HttpPost]  
        public IActionResult Update (UserDto userDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model: userDto);
            }

            string username = TempData["username"].ToString();
            userDto.Username = username;
            this.userService.UpdateUser(username, userDto);
            return this.RedirectToAction(actionName: "Index", controllerName: "Users");

        }

        public IActionResult Create()
        {
            return View(new CreatePost());
        }

        [HttpPost]
        public IActionResult Create(CreatePost model)
        {
            // do other validations on your model as needed
            if (model.MyImage != null)
            {
                string uniqueFileName = GetUniqueFileName(model.MyImage.FileName);
                string uploads = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                string filePath = Path.Combine(uploads, uniqueFileName);

                string username = TempData["username"].ToString();


                using (MemoryStream ms = new MemoryStream())
                {
                    model.MyImage.CopyTo(ms);
                    byte[] fileBytes = ms.ToArray();
                    string convertedPhoto = Convert.ToBase64String(fileBytes);
                    this.userService.AddPhoto(convertedPhoto, username);

                }
                //Byte[] result = (Byte[])new ImageConverter().ConvertTo(model.MyImage, typeof(Byte[]));


                model.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));
                //to do : Save uniqueFileName  to your db table
                //IFormFile myImage = model.MyImage;
            }


            // to do  : Return something
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

    }
    }
