using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Core.Entities.Concrete
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string Eposta { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Resim { get; set; }
    }
}
