using YilmazCoder.Business.Abstract;
using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YilmazCoder.UI.Controllers
{
    public class KategoriController : Controller
    {
        private IKategoriService _kategoriService;
        private IYaziService _yaziService;
        public KategoriController(IKategoriService kategoriService,IYaziService yaziService)
        {
            _yaziService = yaziService;
            _kategoriService = kategoriService;
        }
        public IActionResult Liste()
        {
            return View(_kategoriService.GetListKategoriYazi());
        }
        public IActionResult Detay(string Id)
        {
            List<YaziDto> ylist = _yaziService.GetListKategoriYazi(Id).ToList();
            foreach (YaziDto yaziDto in ylist)
            {
                string yol = Path.Combine("Resources", "YaziKapakResim") + "\\" + yaziDto.YaziKapakResim;
                if (!System.IO.File.Exists(Path.Combine("Resources", "YaziKapakResim") + "\\" + yaziDto.YaziKapakResim))
                {
                    yaziDto.YaziKapakResim = "";
                }
            }
            return View(ylist);
        }
    }
}
