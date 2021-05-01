using CoderBlog.Business.Abstract;
using CoderBlog.Business.Concrete;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;

namespace CoderBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private IKullaniciService _kullaniciService;
        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _kullaniciService.GetList();
            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult GetList(int Id)
        {
            var result = _kullaniciService.GetById(Id);
            return Ok(result);
        }

        [HttpPost("Kaydet")]
        public IActionResult KullaniciKaydet(Kullanici kullanici)
        {
            Kullanici kul = _kullaniciService.GetById(kullanici.Id);


            if (kul!=null)
            {
                kul.Ad = kullanici.Ad;
                kul.Soyad = kullanici.Soyad;
                _kullaniciService.Update(kul);
            }
            else
                _kullaniciService.Add(kullanici);

            return Ok(true);
        }

        [HttpPost("Sil")]
        public IActionResult KullaniciSil(Kullanici kullanici)
        {
            _kullaniciService.Delete(kullanici);

            return Ok(true);
        }

        [HttpPost("Duzenle")]
        public IActionResult Duzenle(KullaniciPostDto kulPost)
        {
            Kullanici kullanici = JsonConvert.DeserializeObject<Kullanici>(kulPost.kullanici); //JsonSerializer.Deserialize<Yazi>(yaziForm.yazi);
            kullanici = _kullaniciService.GetById(kullanici.Id);
            _kullaniciService.Update(kullanici);

            var folderName = Path.Combine("Resources", "ProfilResmi");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
       
            if (kulPost.kulResimBase64!="")
            {
                string dosya = Path.Combine(pathToSave, "profilResim_" + kullanici.Id.ToString() + ".jpg");
                string[] base64Data = kulPost.kulResimBase64.Split(',');
                byte[] data = Convert.FromBase64String(base64Data[1]);

                using (var stream = new MemoryStream(data, 0, data.Length))
                {
                    Image image = Image.FromStream(stream);
                    image.Save(dosya, System.Drawing.Imaging.ImageFormat.Jpeg);
                    kullanici.Resim = "profilResim_" + kullanici.Id.ToString() + ".jpg";
                    _kullaniciService.Update(kullanici);
                    return Ok(true);
                }
            }
            return Ok(true);
        }

    }
}
