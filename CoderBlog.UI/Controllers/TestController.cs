﻿using CoderBlog.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderBlog.UI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        
        public IActionResult Kaydet(TestVM testVM)
        {

            return Json("");
        }
    }
}
