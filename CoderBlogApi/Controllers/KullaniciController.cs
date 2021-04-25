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
        KullaniciManager kulManager = new KullaniciManager();

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = kulManager.GetList();
            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult GetList(int Id)
        {
            var result = kulManager.GetById(Id);
            return Ok(result);
        }

        [HttpPost("Kaydet")]
        public IActionResult KullaniciKaydet(Kullanici kullanici)
        {
            Kullanici kul = kulManager.GetById(kullanici.Id);


            if (kul!=null)
            {
                kul.Ad = kullanici.Ad;
                kul.Soyad = kullanici.Soyad;
                kulManager.Update(kul);
            }
            else
                kulManager.Add(kullanici);

            return Ok(true);
        }

        [HttpPost("Sil")]
        public IActionResult KullaniciSil(Kullanici kullanici)
        {
            kulManager.Delete(kullanici);

            return Ok(true);
        }

        [HttpPost("Duzenle")]
        public IActionResult Duzenle(KullaniciPostDto kulPost)
        {
            Kullanici kullanici = JsonConvert.DeserializeObject<Kullanici>(kulPost.kullanici); //JsonSerializer.Deserialize<Yazi>(yaziForm.yazi);
            kullanici = kulManager.GetById(kullanici.Id);
            kulManager.Update(kullanici);

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
                    kulManager.Update(kullanici);
                    return Ok(true);
                }
            }
            return Ok(true);
        }

    }
}
