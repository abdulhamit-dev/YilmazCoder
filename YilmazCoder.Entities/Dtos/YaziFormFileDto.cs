using YilmazCoder.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Entities.Dtos
{
    public class YaziFormFileDto:IDto
    {
        public string yazi { get; set; }
        public string yaziBase64 { get; set; }
        public IFormFile yaziKapakResim { get; set; }
    }
}
