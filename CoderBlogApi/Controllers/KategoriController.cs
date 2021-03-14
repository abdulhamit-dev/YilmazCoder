using CoderBlog.Business.Concrete;
using CoderBlog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoderBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        KategoriManager kManager = new KategoriManager();

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = kManager.GetList();
            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult GetList(int Id)
        {
            var result = kManager.GetById(Id);
            return Ok(result);
        }

        [HttpPost("Kaydet")]
        public IActionResult KategoriKaydet(Kategori kategori)
        {

            if (kategori.Id > 0)
                kManager.Update(kategori);
            else
                kManager.Add(kategori);

            return Ok(true);
        }

        [HttpPost("Sil")]
        public IActionResult KategoriSil(Kategori kategori)
        {
            kManager.Delete(kategori);

            return Ok(true);
        }
    }
}
