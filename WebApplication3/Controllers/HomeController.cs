﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = " Hi GAFI";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Hello world";

            return View();
        }
    }
}