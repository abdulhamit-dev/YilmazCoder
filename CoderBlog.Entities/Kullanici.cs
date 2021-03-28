using CoderBlog.Core.Entities;
using System;

namespace CoderBlog.Entities
{
    public class Kullanici:IEntity
    {
        
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string Eposta { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
