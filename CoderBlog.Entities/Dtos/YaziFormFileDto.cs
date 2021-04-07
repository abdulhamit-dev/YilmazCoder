using CoderBlog.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Entities.Dtos
{
    public class YaziFormFileDto:IDto
    {
        public string yazi { get; set; }
        public IFormFile yaziKapakResim { get; set; }
    }
}
