using CoderBlog.Business.Concrete;
using CoderBlog.Entities;
using Microsoft.AspNetCore.Mvc;

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

            if (kullanici.Id > 0)
                kulManager.Update(kullanici);
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
    }
}
