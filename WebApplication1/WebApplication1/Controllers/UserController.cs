using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.DAL.Repositories;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController: Controller
    {
        private UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Create()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var user = new User 
            {
                FIO = model.FIO,
                Password = model.Password
            };
            userRepository.Save(user);

            return RedirectToAction("Index", "Home");
        }
    }
}