﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.DAL.Repositories;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {     

        public HomeController()
        {

        }

        // GET: Home
        public ActionResult Index()
        {
            var model = new HomeModel 
            { 
                Title = "Крутое приложение!",
                Time = DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeModel model)
        { 
            model.Time = DateTime.Now;
            return View(model);
        }
    }
}