using CoderBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Entities.Dtos
{
    public class YaziKullaniciDto:IDto
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int KullaniciId { get; set; }
        public string YaziBaslik { get; set; }
        public string YaziIcerik { get; set; }
        public DateTime YaziTarih { get; set; }
        public string KullaniciAdi { get; set; }
        public string YaziKapakResim { get; set; }
    }
}
