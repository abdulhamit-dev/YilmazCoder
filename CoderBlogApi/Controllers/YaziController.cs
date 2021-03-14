using CoderBlog.Business.Concrete;
using CoderBlog.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("get")]
        public IActionResult GetList(int Id)
        {
            var result = yaziManager.GetById(Id);
            return Ok(result);
        }

        [HttpPost("YaziKaydet")]
        public IActionResult YaziKaydet(Yazi yazi)
        {
            if(yazi.KullaniciId<=0 || yazi.KategoriId<=0)
                return Ok(false);

            if (yazi.Id > 0)
                yaziManager.Update(yazi);
            else
                yaziManager.Add(yazi);

            return Ok(true);

            
        }

        [HttpPost("Sil")]
        public IActionResult YaziSil(Yazi yazi)
        {
            yaziManager.Delete(yazi);
            return Ok(true);
        }
    }
}
