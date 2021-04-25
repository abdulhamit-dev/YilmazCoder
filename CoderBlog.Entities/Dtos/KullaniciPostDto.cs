using CoderBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Entities.Dtos
{
    public class KullaniciPostDto:IDto
    {
        public string kullanici { get; set; }
        public string kulResimBase64 { get; set; }
    }
}
