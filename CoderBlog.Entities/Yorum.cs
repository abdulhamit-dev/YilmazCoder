using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Entities
{
    public class Yorum
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int YaziId { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
