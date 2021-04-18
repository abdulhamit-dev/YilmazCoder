using CoderBlog.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Entities.Dtos
{
    public class KullaniciFormFileDto:IDto
    {
        public string kullanici { get; set; }
        public IFormFile kullaniciResmi { get; set; }
    }
}
