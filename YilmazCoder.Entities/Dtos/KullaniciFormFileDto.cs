using YilmazCoder.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Entities.Dtos
{
    public class KullaniciFormFileDto:IDto
    {
        public string kullanici { get; set; }
        public IFormFile kullaniciResmi { get; set; }
    }
}
