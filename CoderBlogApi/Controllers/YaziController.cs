using CoderBlog.Business.Concrete;
using CoderBlog.Entities;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("getlistYeniler")]
        public IActionResult GetListYeniler()
        {
            var result = yaziManager.GetListYeniler();
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

        [HttpPost("Sil")]
        public IActionResult YaziSil(Yazi yazi)
        {
            yaziManager.Delete(yazi);
            return Ok(true);
        }
    }
}
