using CoderBlog.Business.Concrete;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult YaziKaydet([FromForm] KullaniciFormFileDto kullaniciForm)
        {

            Kullanici kullanici = JsonConvert.DeserializeObject<Kullanici>(kullaniciForm.kullanici); //JsonSerializer.Deserialize<Yazi>(yaziForm.yazi);

            kullanici = kulManager.GetById(kullanici.Id);

            kulManager.Update(kullanici);


            var file = kullaniciForm.kullaniciResmi;
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = @"C:\GitRepo\CoderBlog\src\assets\profilResmi";// Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file == null)
                return Ok(true);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                fileName = "profilResim_" + kullanici.Id.ToString() + ".jpg";
                //C:\Angular\CoderBlog\CoderBlog\src\assets\yaziKapakResim
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                kullanici.Resim = fileName;
                kulManager.Update(kullanici);
                return Ok(new { dbPath });
            }

            return Ok(true);
        }
    }
}
