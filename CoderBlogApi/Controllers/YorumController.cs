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
    public class YorumController : ControllerBase
    {
        YorumManager manager = new YorumManager();

        [HttpPost("Kaydet")]
        public IActionResult Kaydet(Yorum yorum)
        {
            manager.Add(yorum);
            return Ok(true);
        }
    }
}
