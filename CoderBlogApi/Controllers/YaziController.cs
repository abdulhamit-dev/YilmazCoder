using CoderBlog.Business.Concrete;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoderBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YaziController : ControllerBase
    {
        YaziManager yaziManager = new YaziManager();
        YorumManager yorumManager = new YorumManager();
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = yaziManager.GetList();
            return Ok(result);
        }
        [HttpGet("getlistYeniler")]
        [Authorize(Roles = "Admin")]
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
        public IActionResult YeniYaziKaydet([FromForm]YaziFormFileDto yaziForm)
        {

            Yazi yazi = JsonConvert.DeserializeObject<Yazi>(yaziForm.yazi); //JsonSerializer.Deserialize<Yazi>(yaziForm.yazi);

            if (yazi.Id > 0)
                yaziManager.Update(yazi);
            else
                yaziManager.Add(yazi);

            var file = yaziForm.yaziKapakResim;
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = @"C:\Angular\CoderBlog\CoderBlog\src\assets\yaziKapakResim";// Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName =ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                fileName = "yaziKapakResim_" + yazi.Id.ToString() + ".jpg";
                //C:\Angular\CoderBlog\CoderBlog\src\assets\yaziKapakResim
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                yazi.YaziKapakResim = fileName;
                yaziManager.Update(yazi);
                return Ok(new { dbPath });
            }

            return Ok(true);
        }

        [HttpPost("Sil")]
        public IActionResult YaziSil(Yazi yazi)
        {
            yaziManager.Delete(yazi);
            return Ok(true);
        }

        [HttpGet("getlistyaziyorum")]
        public IActionResult GetListYaziYorum(int yaziId)
        {
            var result = yorumManager.GetList(yaziId);
            return Ok(result);
        }

    }
}
