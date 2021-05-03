using CoderBlog.Business.Abstract;
using CoderBlog.Business.Concrete;
using CoderBlog.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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

        [Authorize]
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

        [HttpPost]
        public ActionResult Kaydet(string yazi, IFormFile yaziKapak)
        {
            Yazi y = JsonConvert.DeserializeObject<Yazi>(yazi);
            y.KullaniciId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            _yaziService.Add(y);

            var folderName = Path.Combine("Resources", "YaziKapakResim");
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


            if (yaziKapak.Length > 0)
            {
                string filePath = Path.Combine(folderName,  "yaziKapakResim_" + y.Id+ ".jpeg");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    yaziKapak.CopyTo(fileStream);
                    using (var ms = new MemoryStream())
                    {
                        yaziKapak.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                    }
                }

                y.YaziKapakResim = "yaziKapakResim_" + y.Id + ".jpeg";
                _yaziService.Update(y);
                
            }

            return Json("ok");
        }

    }
}
