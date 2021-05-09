using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderBlog.UI.Models.Kullanici
{
    public class KullaniciVM
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string Eposta { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Resim { get; set; }
        public string ResimBase64 { get; set; }
        public bool ResimSecimi { get; set; }
    }
}
