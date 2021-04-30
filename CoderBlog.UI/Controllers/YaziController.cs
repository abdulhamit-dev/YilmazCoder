using CoderBlog.Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderBlog.UI.Controllers
{
    public class YaziController : Controller
    {
        KategoriManager kategoriManager = new KategoriManager();
        public IActionResult Yeni()
        {
            ViewBag.KategoriList = kategoriManager.GetList();
            return View();
        }

        [HttpPost]
        public IActionResult PostTest(string deger)
        {

            return Json(true);
        }
        
    }
}
