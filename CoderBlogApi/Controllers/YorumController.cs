using CoderBlog.Business.Abstract;
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
        private IYorumService _yorumService;
        public YorumController(IYorumService yorumService)
        {
            _yorumService = yorumService;
        }

        [HttpPost("Kaydet")]
        public IActionResult Kaydet(Yorum yorum)
        {
            _yorumService.Add(yorum);
            return Ok(true);
        }
    }
}
