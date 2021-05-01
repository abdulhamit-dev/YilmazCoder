using CoderBlog.Business.Abstract;
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
        private IYaziService _yaziService;
        private IKategoriService _kategoriService;
        public YaziController(IYaziService yaziService,IKategoriService kategoriService)
        {
            _yaziService = yaziService;
            _kategoriService = kategoriService;
        }
        public IActionResult Yeni()
        {
            ViewBag.KategoriList = _kategoriService.GetList();
            
            return View();
        }

        [HttpPost]
        public IActionResult PostTest(string deger)
        {

            return Json(true);
        }
        
    }
}
