using CoderBlog.Business.Abstract;
using CoderBlog.Business.Concrete;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoderBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YaziController : ControllerBase
    {
        private IYaziService _yaziService;
        private IYorumService _yorumService;
        public YaziController(IYaziService yaziService,IYorumService yorumService)
        {
            _yaziService = yaziService;
            _yorumService = yorumService;
        }
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _yaziService.GetList();
            return Ok(result);
        }
        [HttpGet("getlistYeniler")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetListYeniler()
        {
            var result = _yaziService.GetYaziDtoList();
            return Ok(result);
        }
        [HttpGet("getlistTrendler")]
        public IActionResult GetListTrendler()
        {
            var result = _yaziService.GetYaziDtoList();
            return Ok(result);
        }
        [HttpGet("getlistfilter")]
        public IActionResult GetListFilter(int kullaniciId,int kategoriId)
        {
            var result = _yaziService.GetList(kullaniciId,kategoriId);
            return Ok(result);
        }

        [HttpGet("getlistkategoriyazi")]
        public IActionResult GetListKategoriYazi(string kategoriAdi)
        {
            var result = _yaziService.GetListKategoriYazi(kategoriAdi);
            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _yaziService.GetById(id);
            return Ok(result);
        }

        [HttpPost("YaziKaydet")]
        public IActionResult YaziKaydet(YaziPostDto yaziForm)
        {
            try
            {

                Yazi yazi = JsonConvert.DeserializeObject<Yazi>(yaziForm.yazi); 

                if (yazi.Id > 0)
                    _yaziService.Update(yazi);
                else
                    _yaziService.Add(yazi);

                var folderName = Path.Combine("Resources", "YaziKapakResim");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (yaziForm.yaziBase64 != "")
                {
                    string dosya = Path.Combine(pathToSave, "yaziKapakResim_" + yazi.Id.ToString() + ".jpg");

                    string[] base64Data = yaziForm.yaziBase64.Split(',');
                    byte[] data = Convert.FromBase64String(base64Data[1]);
                    using (var stream = new MemoryStream(data, 0, data.Length))
                    {
                        Image image = Image.FromStream(stream);
                        image.Save(dosya, System.Drawing.Imaging.ImageFormat.Jpeg);
                        yazi.YaziKapakResim = "yaziKapakResim_" + yazi.Id.ToString() + ".jpg";
                        _yaziService.Update(yazi);
                        return Ok(true);
                    }
                }
            }
            catch (Exception ex)
            {

                return Ok(ex);
            }


            return Ok(true);
        }


        //BU metod post sonucu gelen(fileupload ile) dosyayı ve json nesnesini karşılamak için
        //[HttpPost("YaziKaydet")]
        //public IActionResult YaziKaydet([FromForm] YaziFormFileDto yaziForm)
        //{
        //    try
        //    {
        //        Yazi yazi = JsonConvert.DeserializeObject<Yazi>(yaziForm.yazi); //JsonSerializer.Deserialize<Yazi>(yaziForm.yazi);

        //        if (yazi.Id > 0)
        //            yaziManager.Update(yazi);
        //        else
        //            yaziManager.Add(yazi);

        //        var file = yaziForm.yaziKapakResim;
        //        var folderName = Path.Combine("Resources", "YaziKapakResim");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        if (file == null)
        //            return Ok(true);
        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            fileName = "yaziKapakResim_" + yazi.Id.ToString() + ".jpg";
        //            //C:\Angular\CoderBlog\CoderBlog\src\assets\yaziKapakResim
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }

        //            yazi.YaziKapakResim = fileName;
        //            yaziManager.Update(yazi);
        //            return Ok(true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return Ok(ex);
        //    }


        //    return Ok(true);
        //}

        [HttpPost("Sil")]
        public IActionResult YaziSil(Yazi yazi)
        {
            _yaziService.Delete(yazi);
            var result = _yaziService.GetList(yazi.KullaniciId, 0);

            return Ok(result);
        }

        [HttpGet("getlistyaziyorum")]
        public IActionResult GetListYaziYorum(int yaziId)
        {
            var result = _yorumService.GetList(yaziId);
            return Ok(result);
        }

    }
}
