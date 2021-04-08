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
    public class BegenController : ControllerBase
    {
        BegeniManager manager = new BegeniManager();

        [HttpPost("Kaydet")]
        public IActionResult Kaydet(Begeni begen)
        {
            Begeni begeni = manager.GetYaziBegeni(begen.YaziId);
            if (begeni==null)
            {
                manager.Add(begen);
                return Ok(true);
            }
            else
            {
                manager.Delete(begeni);
                return Ok(false);
            }
        }

        [HttpPost("Sil")]
        public IActionResult Sil(Begeni begen)
        {
            manager.Delete(begen);
            return Ok(true);
        }
    }
}
