using YilmazCoder.Business.Abstract;
using YilmazCoder.Business.Concrete;
using YilmazCoder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace YilmazCoder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private IKategoriService _kategoriService;
        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }


        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _kategoriService.GetList();
            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult GetList(int Id)
        {
            var result = _kategoriService.GetById(Id);
            return Ok(result);
        }

        [HttpPost("Kaydet")]
        public IActionResult KategoriKaydet(Kategori kategori)
        {

            if (kategori.Id > 0)
                _kategoriService.Update(kategori);
            else
                _kategoriService.Add(kategori);

            return Ok(true);
        }

        [HttpPost("Sil")]
        public IActionResult KategoriSil(Kategori kategori)
        {
            _kategoriService.Delete(kategori);

            return Ok(true);
        }
    }
}
