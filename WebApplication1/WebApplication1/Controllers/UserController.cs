using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.DAL.Filters;
using WebApplication1.DAL.Repositories;
using WebApplication1.Files;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class UserController: BaseController
    {
        private UserRepository userRepository;        

        public UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
        }

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
                Age = model.Age,
                UserName = model.Login,
                Email = model.Email,
                CreationDate = DateTime.Now,
                BirthDate = model.BirthDate,
                AvatarFile = model.Avatar != null ? model.Avatar.BinaryFile : null
            };
            var res = UserManager.CreateAsync(user, model.Password);
            if (res.Result == IdentityResult.Success)
            { 
                if (model.Avatar != null)
                { 
                    GetFileProvider().Save(model.Avatar.BinaryFile, model.Avatar.PostedFile.InputStream);
                }
                return RedirectToAction("List");
            }
            return View(model);
        }

        public ActionResult List(UserFilter filter)
        {
            var model = new UserListModel 
            {
                Items = userRepository.Find(filter)
            };
            return View(model);
        }        

        public ActionResult Details(long id)
        {
            var user = userRepository.Load(id);
            var model = new UserModel { 
                Entity = user,
                Age = user.Age,
                Avatar = new BinaryFileWrapper { 
                    BinaryFile = user.AvatarFile
                },
                BirthDate = user.BirthDate,
                Email = user.Email,
                FIO = user.FIO,
                Login = user.UserName,
                CreationAutor = user.CreationAuthor
            };
            return View(model);
        }
    }
}