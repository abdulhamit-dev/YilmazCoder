using YilmazCoder.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YilmazCoder.Entities
{
    public class Yazi : IEntity
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int KullaniciId { get; set; }
        [Required]
        public string YaziBaslik { get; set; }
        public string YaziIcerik { get; set; }
        public DateTime YaziTarih { get; set; } = DateTime.Now;
        public string YaziKapakResim { get; set; } = "";
    }
}
