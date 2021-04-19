using CoderBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Entities.Dtos
{
    public class YaziDto:IDto
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public int KullaniciId { get; set; }
        public string KullaniciResmi { get; set; }
        public string YaziBaslik { get; set; }
        public string YaziIcerik { get; set; }
        public DateTime YaziTarih { get; set; }
        public string KullaniciAdi { get; set; }
        public string YaziKapakResim { get; set; }
        public int YorumSayisi { get; set; }
        public int BegeniSayisi { get; set; }
    }
}
