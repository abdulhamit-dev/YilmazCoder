using YilmazCoder.Business.Abstract;
using YilmazCoder.Business.Concrete;
using YilmazCoder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YilmazCoderApi.Controllers
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
