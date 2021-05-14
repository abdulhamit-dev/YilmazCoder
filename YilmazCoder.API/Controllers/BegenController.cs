using YilmazCoder.Business.Abstract;
using YilmazCoder.Business.Concrete;
using YilmazCoder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YilmazCoder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BegenController : ControllerBase
    {
        private IBegeniService _begeniService;
        public BegenController(IBegeniService begeniService)
        {
            _begeniService = begeniService;
        }

        [HttpPost("Kaydet")]
        public IActionResult Kaydet(Begeni begen)
        {
            Begeni begeni = _begeniService.GetYaziBegeni(begen.YaziId,begen.KullaniciId);
            if (begeni==null)
            {
                _begeniService.Add(begen);
                return Ok(true);
            }
            else
            {
                _begeniService.Delete(begeni);
                return Ok(false);
            }
        }

        [HttpPost("Sil")]
        public IActionResult Sil(Begeni begen)
        {
            _begeniService.Delete(begen);
            return Ok(true);
        }
    }
}
