using CoderBlog.Business.Abstract;
using CoderBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderBlog.UI.Controllers
{
    public class KategoriController : Controller
    {
        private IKategoriService _kategoriService;
        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }
        public IActionResult Liste()
        {
            return View(_kategoriService.GetList());
        }
    }
}
