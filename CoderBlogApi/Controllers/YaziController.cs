using CoderBlog.Business.Concrete;
using CoderBlog.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoderBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YaziController : ControllerBase
    {
        YaziManager yaziManager = new YaziManager();
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = yaziManager.GetList();
            return Ok(result);
        }
        [HttpGet("getlistYeniler"), Authorize]
        public IActionResult GetListYeniler()
        {
            var result = yaziManager.GetListYeniler();
            return Ok(result);
        }
        [HttpGet("getlistTrendler")]
        public IActionResult GetListTrendler()
        {
            var result = yaziManager.GetListTrendler();
            return Ok(result);
        }
        [HttpGet("getlistfilter")]
        public IActionResult GetListFilter(int kullaniciId,int kategoriId)
        {
            var result = yaziManager.GetList(kullaniciId,kategoriId);
            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = yaziManager.GetById(id);
            return Ok(result);
        }

        [HttpPost("YaziKaydet")]
        public IActionResult YaziKaydet(Yazi yazi)
        {
            if (yazi.KullaniciId <= 0 || yazi.KategoriId <= 0)
                return Ok(false);

            if (yazi.Id > 0)
                yaziManager.Update(yazi);
            else
                yaziManager.Add(yazi);

            return Ok(true);


        }

        [HttpPost("FileUpload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpPost("Sil")]
        public IActionResult YaziSil(Yazi yazi)
        {
            yaziManager.Delete(yazi);
            return Ok(true);
        }
    }
}
