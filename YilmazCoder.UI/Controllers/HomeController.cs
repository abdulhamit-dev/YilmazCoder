using YilmazCoder.Business.Abstract;
using YilmazCoder.Business.Concrete;
using YilmazCoder.Entities.Dtos;
using YilmazCoder.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YilmazCoder.UI.Controllers
{
    public class HomeController : Controller
    {
        private IYaziService _yaziService;
        public HomeController(IYaziService yaziService)
        {
            _yaziService = yaziService;
        }
        public IActionResult Index()
        {
            List<YaziDto> yaziList = _yaziService.GetYaziDtoList().ToList();
            foreach (YaziDto yaziDto in yaziList)
            {
                string yol = Path.Combine("Resources", "YaziKapakResim") + "\\" + yaziDto.YaziKapakResim;
                if (!System.IO.File.Exists(Path.Combine("Resources", "YaziKapakResim") + "\\" + yaziDto.YaziKapakResim))
                {
                    yaziDto.YaziKapakResim = "";
                }
            }
            return View(yaziList);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
