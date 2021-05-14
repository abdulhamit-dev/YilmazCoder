using AutoMapper;
using YilmazCoder.Business.Abstract;
using YilmazCoder.Business.Concrete;
using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using YilmazCoder.UI.Models.Yazi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Drawing;

namespace YilmazCoder.UI.Controllers
{
    public class YaziController : Controller
    {
        private IYaziService _yaziService;
        private IKategoriService _kategoriService;
        private IYorumService _yorumService;
        private IBegeniService _begeniService;
        private readonly IMapper _mapper;

        public YaziController(IYaziService yaziService, IKategoriService kategoriService, IYorumService yorumService, IMapper mapper, IBegeniService begeniService)
        {
            _yaziService = yaziService;
            _kategoriService = kategoriService;
            _yorumService = yorumService;
            _begeniService = begeniService;
            _mapper = mapper;
        }

        #region Yazı Detay

        
        public IActionResult Detay(int id, string title)
        {
            YaziDto yazi = _yaziService.GetById(id);
            YaziVM yaziVM = _mapper.Map<YaziVM>(yazi);
            yaziVM.YorumList = _yorumService.GetList(id).ToList();
            return View(yaziVM);
        }
        
        [HttpPost]
        public IActionResult YorumYap(int yaziId,string yorumAciklama)
        {
            Yorum yorum = new Yorum();
            yorum.KayitTarihi = DateTime.Now;
            yorum.KullaniciId = 0;
            if (User.HasClaim(x => x.Type == ClaimTypes.Name))
            {
                var kullaniciAdi = User.FindFirst(ClaimTypes.Name).Value;
                if (!string.IsNullOrEmpty(kullaniciAdi))
                    yorum.KullaniciId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            }

            yorum.Aciklama = yorumAciklama;
            yorum.YaziId = yaziId;

            _yorumService.Add(yorum);

            return PartialView("_YorumListpp",_yorumService.GetList(yaziId));
        }

        [HttpPost]
        public IActionResult Begen(int yaziId,int begeniSayisi)
        {
            int kulId= Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Begeni begeni = _begeniService.GetYaziBegeni(yaziId, kulId);
            if (begeni == null)
            {
                begeni = new Begeni();
                begeni.KayitTarihi = DateTime.Now;
                begeni.KullaniciId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                begeni.YaziId = yaziId;
                _begeniService.Add(begeni);
                return Json(begeniSayisi+1);
            }
            else
            {
                _begeniService.Delete(begeni);
                return Json(begeniSayisi -1);
            }
        }

        #endregion

        #region Yeni Yazi

        [Authorize]
        public IActionResult Yeni()
        {
            YaziVM yazi = new YaziVM();
            ViewBag.KategoriList = _kategoriService.GetList();
            
            return View(yazi);
        }

        [HttpPost]
        public ActionResult Kaydet(string yaziJson)
        {
            YaziVM yaziVM = JsonConvert.DeserializeObject<YaziVM>(yaziJson);
            yaziVM.KullaniciId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Yazi yazi = new Yazi();
            yazi = _mapper.Map<Yazi>(yaziVM);
            _yaziService.Add(yazi);

            var folderName = Path.Combine("Resources", "YaziKapakResim");
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (yaziVM.ResimBase64 != "" && yaziVM.ResimSecimi == true)
            {
                string dosya = Path.Combine(folderName, "yaziKapakResim_" + yazi.Id.ToString() + ".jpeg");

                string[] base64Data = yaziVM.ResimBase64.Split(',');
                byte[] data = Convert.FromBase64String(base64Data[1]);
                using (var stream = new MemoryStream(data, 0, data.Length))
                {
                    Image image = Image.FromStream(stream);
                    image.Save(dosya, System.Drawing.Imaging.ImageFormat.Jpeg);
                    yazi.YaziKapakResim = "yaziKapakResim_" + yazi.Id.ToString() + ".jpeg";

                    _yaziService.Update(yazi);
                    return Ok(true);
                }
            }

            return Json(true);
        }
        #endregion

        #region Yazilarim

       
        [Authorize]
        public IActionResult Yazilarim()
        {
            int kullaniciId= Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Yazi> yaziList = _yaziService.GetList(kullaniciId, 0).ToList();
            List<YaziVM> yaziVMList = _mapper.Map < List<YaziVM>>(yaziList);
            return View(yaziVMList);
        }
        [HttpPost]
        public IActionResult YaziSec(int yaziId)
        {
            Yazi yazi = _yaziService.Get(yaziId);
            YaziVM yaziVM = _mapper.Map<YaziVM>(yazi);
            ViewBag.KategoriList = _kategoriService.GetList();

            return PartialView("_SeciliYazipp", yaziVM);
        }
        [HttpPost]
        public IActionResult Duzenle(string yaziJson)
        {
            YaziVM yaziVM = JsonConvert.DeserializeObject<YaziVM>(yaziJson);
            Yazi yazi = _mapper.Map<Yazi>(yaziVM);
            yazi.KullaniciId= Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            yazi.YaziTarih = DateTime.Now;

            var folderName = Path.Combine("Resources", "YaziKapakResim");

            if (yaziVM.ResimBase64 != "" && yaziVM.ResimSecimi == true)
            {
                string dosya = Path.Combine(folderName, "yaziKapakResim_" + yazi.Id.ToString() + ".jpeg");

                string[] base64Data = yaziVM.ResimBase64.Split(',');
                byte[] data = Convert.FromBase64String(base64Data[1]);
                using (var stream = new MemoryStream(data, 0, data.Length))
                {
                    Image image = Image.FromStream(stream);
                    image.Save(dosya, System.Drawing.Imaging.ImageFormat.Jpeg);
                    yazi.YaziKapakResim = "yaziKapakResim_" + yazi.Id.ToString() + ".jpeg";
                    _yaziService.Update(yazi);
                }
            }
            else
            {
               
                _yaziService.Update(yazi);
            }

            return Json(true);
        }

        public IActionResult Sil(int yaziId)
        {
            Yazi y = _yaziService.Get(yaziId);
            _yaziService.Delete(y);
            return Json(true);
        }
        #endregion

    }
}
