using CoderBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Entities.Dtos
{
    public class YorumDto:IDto
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public int YaziId { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string KullaniciResmi { get; set; }
    }
}
