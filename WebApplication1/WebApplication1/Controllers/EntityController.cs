﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class EntityController: Controller
    {
        public ActionResult Select(string term, string modelType)
        {
            return Json(new  { result = "ok" }, JsonRequestBehavior.AllowGet);
        }
    }
}