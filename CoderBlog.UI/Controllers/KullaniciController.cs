using AutoMapper;
using CoderBlog.Business.Abstract;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.UI.Models.Kullanici;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoderBlog.UI.Controllers
{
    public class KullaniciController : Controller
    {
        private IKullaniciService _kullaniciService;
        private readonly IMapper _mapper;


        public KullaniciController(IKullaniciService kullaniciService, IMapper mapper)
        {
            _kullaniciService = kullaniciService;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Profil()
        {
            int kulId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Kullanici kul = _kullaniciService.GetById(kulId);
            KullaniciVM kulVM = _mapper.Map<KullaniciVM>(kul);
            
            return View(kulVM);
        }

        public IActionResult Duzenle(string kullaniciJson)
        {
            int kulId= Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            KullaniciVM kullaniciVM = JsonConvert.DeserializeObject<KullaniciVM>(kullaniciJson);
            Kullanici kul = _kullaniciService.GetById(kulId);
            kul.Ad=kullaniciVM.Ad;
            kul.Soyad = kullaniciVM.Soyad;
            kul.Eposta = kullaniciVM.Eposta;
            kul.KayitTarihi = DateTime.Now;

            var folderName = Path.Combine("Resources", "ProfilResmi");
            if (kullaniciVM.ResimBase64 != "" && kullaniciVM.ResimSecimi == true)
            {
                string dosya = Path.Combine(folderName, "profilResim_" + kul.Id.ToString() + ".jpeg");

                string[] base64Data = kullaniciVM.ResimBase64.Split(',');
                byte[] data = Convert.FromBase64String(base64Data[1]);
                using (var stream = new MemoryStream(data, 0, data.Length))
                {
                    Image image = Image.FromStream(stream);
                    image.Save(dosya, System.Drawing.Imaging.ImageFormat.Jpeg);
                    kul.Resim = "profilResim_" + kul.Id.ToString() + ".jpeg";
                    _kullaniciService.Update(kul);
                }
            }
            else
            {

                _kullaniciService.Update(kul);
            }

            return Json(true);
        }
    }
}
