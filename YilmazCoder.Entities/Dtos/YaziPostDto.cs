using YilmazCoder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Entities.Dtos
{
    public class YaziPostDto:IDto
    {
        public string yazi { get; set; }
        public string yaziBase64 { get; set; }
    }
}
