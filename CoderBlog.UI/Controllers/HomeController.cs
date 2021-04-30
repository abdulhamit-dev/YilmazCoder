using CoderBlog.Business.Concrete;
using CoderBlog.Entities.Dtos;
using CoderBlog.UI.Models;
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

namespace CoderBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        YaziManager yaziManager = new YaziManager();

        public async Task<IActionResult> IndexAsync()
        {
            List<YaziDto> yaziList = new List<YaziDto>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.yilmazcoder.online/api/yazi/getlistyeniler");
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    yaziList=  JsonConvert.DeserializeObject<List<YaziDto>>(jsonString);

                }
            }
            return View(yaziList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
